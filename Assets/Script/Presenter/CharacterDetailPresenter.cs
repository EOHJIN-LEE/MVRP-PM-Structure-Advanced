using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CharacterDetailPresenter : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button gearButton;

    [Inject] private CharacterDetailStateModel characterDetailStateModel;
    
    private void Awake()
    {
        statusButton.OnClickAsObservable().Subscribe(_ =>
        {
            characterDetailStateModel.state.OnNext(CharacterDetailState.Status);
        }).AddTo(this);
        
        gearButton.OnClickAsObservable().Subscribe(_ =>
        {
            characterDetailStateModel.state.OnNext(CharacterDetailState.Skill);
        }).AddTo(this);
        
        //初期設定
        characterDetailStateModel.state.OnNext(CharacterDetailState.Status);
    }
}
