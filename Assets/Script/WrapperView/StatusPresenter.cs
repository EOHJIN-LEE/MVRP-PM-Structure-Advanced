using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class StatusPresenter : CharacterDetailPresenterBase
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private CharacterButton characterButtonPrefab;
    [SerializeField] private Transform characterButtonsParent;

    [Inject] private Database _database;

    private readonly Subject<StatusModel> _selectedStatusModel = new();
    private List<CharacterButton> _characterButtons;

    protected override CharacterDetailState PresenterState => CharacterDetailState.Status;

    protected override void Initialize()
    {
        Action setCallback = () =>
        {
            Debug.LogError(1);
            SetButtonsCallback();
            SetSelectCallback();
        };
        Action setInitialValue = () =>
        {
            Debug.LogError(2);
            SetButtonInitialValue();
        };

        var orderlyInitialize = setCallback.Compose(setInitialValue);
        orderlyInitialize();
    }

    private void SetButtonsCallback()
    {
        _characterButtons = CreateButton(_database.StatusModels);
        _characterButtons.ForEach(button =>
        {
            button.GetButtonAsObservable().Subscribe(model =>
            {
                _selectedStatusModel.OnNext(model);
            }).AddTo(this);
        });
    }

    private void SetSelectCallback()
    {
        _selectedStatusModel.Subscribe(model =>
        {
            title.text = model.name;
            description.text = model.description;
        }).AddTo(this);
    }

    private void SetButtonInitialValue()
    {
        _characterButtons.FirstOrDefault()?.Click();
    }

    private List<CharacterButton> CreateButton(List<StatusModel> statusModels)
    {
        var characterButtons = new List<CharacterButton>();
        foreach (var statusModel in statusModels)
        {
            var characterButton = Instantiate(characterButtonPrefab, characterButtonsParent);
            characterButton.Set(statusModel);
            characterButtons.Add(characterButton);
        }
        return characterButtons;
    }
}
