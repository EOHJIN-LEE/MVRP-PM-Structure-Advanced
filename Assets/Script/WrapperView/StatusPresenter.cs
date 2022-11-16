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
        #region 理想
        // var setButtonCallback = new Method(SetButtonsCallback);
        // var setSelectCallback = new Method(SetSelectCallback);
        // var setButtonInitialValue = new Method(SetButtonInitialValue);
        // (setButtonInitialValue * (setButtonCallback + setSelectCallback)).Execute();
        #endregion

        Action setCallback = () =>
        {
            SetButtonsCallback();
            SetSelectCallback();
        };
        Action setInitialValue = () =>
        {
            SetButtonInitialValue();
        };

        var orderlyInitialize = setCallback.Compose(setInitialValue);
        orderlyInitialize();

        #region Method
        void SetButtonsCallback()
        {
            _characterButtons = CreateButton(_database.StatusModels);
            _characterButtons.ForEach(button =>
            {
                button.GetButtonAsObservable().Subscribe(model =>
                {
                    _selectedStatusModel.OnNext(model);
                }).AddTo(this);
            });
            
            List<CharacterButton> CreateButton(List<StatusModel> statusModels)
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
        
        void SetSelectCallback()
        {
            _selectedStatusModel.Subscribe(model =>
            {
                title.text = model.name;
                description.text = model.description;
            }).AddTo(this);
        }
        
        void SetButtonInitialValue()
        {
            _characterButtons.FirstOrDefault()?.Click();
        }
        #endregion
    }
}
