using System;
using System.Collections.Generic;

public static class FunctionalExtension
{
    public static Action Compose(this Action func1, Action func2)
    {
        return (Action)Delegate.Combine(func1, func2);
    }
}

public class Method
{
    private Method _beforeMethod;
    public List<Action> actions = new List<Action>();

    public Method(Action action1)
    {
        actions.Add(action1);
    }

    public static Method operator +(Method a, Method b)
    {
        a.actions.AddRange(b.actions);
        return a;
    }
    
    public static Method operator *(Method a, Method b)
    {
        b._beforeMethod = a;
        return b;
    }

    public void Execute()
    {
        foreach (var VARIABLE in actions)
        {
            VARIABLE();
        }
        _beforeMethod?.Execute();
    }
}
