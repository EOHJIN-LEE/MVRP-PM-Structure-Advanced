using UniRx;
using UnityEngine;
using Zenject;

public abstract class CharacterDetailPresenterBase : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [Inject] private CharacterDetailStateModel _characterDetailStateModel;
    protected abstract CharacterDetailState PresenterState { get; }

    private void Awake()
    {
        SubscribeState();
        Initialize();
    }
    
    private void Open()
    {
        content.SetActive(true);
    }

    private void Close()
    {
        content.SetActive(false);
    }

    private void SubscribeState()
    {
        var stateObservable = _characterDetailStateModel.state.Publish();
        stateObservable.Where(state => state == PresenterState).Subscribe(_ =>
        {
            Open();
        }).AddTo(this);
        
        stateObservable.Where(state => state != PresenterState).Subscribe(_ =>
        {
            Close();
        }).AddTo(this);
        stateObservable.Connect();
    }

    protected abstract void Initialize();
}
