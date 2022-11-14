using Zenject;

public class DescriptionChangePresenter : CharacterDetailPresenterBase
{
    [Inject] private Database _database;
    [Inject] private CharacterDetailStateModel _characterDetailStateModel;

    protected override CharacterDetailState PresenterState => CharacterDetailState.DescriptionChange;
    protected override void Initialize()
    {
        
    }
}
