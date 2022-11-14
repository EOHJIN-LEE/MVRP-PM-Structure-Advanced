using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CharacterButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;

    private StatusModel _statusModel;
    public void Set(StatusModel statusModel)
    {
        _statusModel = statusModel;
        text.text = statusModel.name;
    }

    public IObservable<StatusModel> GetButtonAsObservable()
    {
        return button.OnClickAsObservable().Select(_ => _statusModel);
    }

    public void Click()
    {
        button.onClick.Invoke();
    }
}
