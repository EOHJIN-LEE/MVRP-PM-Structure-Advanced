using Zenject;

public class SkillPresenter : CharacterDetailPresenterBase
{
    [Inject] private Database _database;
    [Inject] private CharacterDetailStateModel _characterDetailStateModel;

    protected override CharacterDetailState PresenterState => CharacterDetailState.Skill;
    protected override void Initialize()
    {
        
    }
}
