using System;

public static class FunctionalExtension
{
    public static Action Compose(this Action func1, Action func2)
    {
        return (Action)Delegate.Combine(func1, func2);
    }
}
