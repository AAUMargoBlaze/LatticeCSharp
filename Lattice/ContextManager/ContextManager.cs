namespace Lattice;

public static class ContextManager
{
    private static readonly Stack<Context> ContextStack = new Stack<Context>(new []{  new GraphContext("Global") { GlobalContext = true } });

    public static readonly Dictionary<string,FunctionContext> DeclaredFunctions = new();

    public static FunctionContext? CurrentFunctionContext { get; private set; }

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
        if (newContext is FunctionContext context)
        {
            DeclaredFunctions.Add(context.Name, context);
            CurrentFunctionContext = context;
        }
        else
        {
            PushDownVariablesToSubContext(ref newContext);
            PushDownGraphsToSubContext(ref newContext);
        }
        GetCurrentContext().DeclareContext(newContext.Name, newContext);
        ContextStack.Push(newContext);
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

        if (GetCurrentContext() is FunctionContext)
        {
            CurrentFunctionContext = null;
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
    private static void PushDownGraphsToSubContext(ref Context newContext)
    {
        var parentContexts = GetCurrentContext().ReturnAllDeclaredGraphs();
        foreach (var kvp in parentContexts)
        {
            newContext.DeclareContext(kvp.Key, kvp.Value);
        }
    }
}

