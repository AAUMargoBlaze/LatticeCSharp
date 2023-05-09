namespace Lattice;

public static class ContextManager
{
    private static readonly Stack<Context> ContextStack = new Stack<Context>(new []{  new GraphContext("Global") { GlobalContext = true } });

    public static Context GetCurrentContext()
    {
        return ContextStack.Peek();
    }

    public static GraphContext GetCurrentGraphContext()
    {
        var stackCopy = new Stack<Context>(ContextStack.Reverse());
        Context found = null;
        
        while (found == null)
        {
            var investigated = stackCopy.Pop();
            if (investigated is GraphContext)
            {
                found = investigated;
            }
        }
        return (GraphContext)found;
    }
    public static Context OpenNewSubContext(Context newContext)
    {
        PushDownVariablesToSubContext(ref newContext);
        ContextStack.Push(newContext);
        GetCurrentContext().DeclareContext(newContext.Name, newContext);
        return GetCurrentContext();
    }

    public static Context EnterSubContext(string name)
    {
        ContextStack.Push(GetCurrentContext().GetSubContext(name));
        return GetCurrentContext();
    }

    public static Context ExitSubContext()
    {
        if (GetCurrentContext().GlobalContext)
        {
            throw new Exception("Can't exit global context");
        }
        return ContextStack.Pop();
        
    }

    private static void PushDownVariablesToSubContext(ref Context newContext)
    {
        var parentVars = GetCurrentContext().ReturnAllDeclaredVariables();
        foreach (var kvp in parentVars)
        {
            newContext.DeclareVariable(kvp.Key, kvp.Value);
        }
    }
}

