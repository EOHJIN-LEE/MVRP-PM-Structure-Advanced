using UniRx;

public class CharacterDetailStateModel
{
    public readonly Subject<CharacterDetailState> state = new ();
}

public enum CharacterDetailState
{
    Status,
    Skill
}
