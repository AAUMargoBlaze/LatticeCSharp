namespace Lattice;

public static class ContextManager
{
    private static readonly Stack<Context> ContextStack = new Stack<Context>(new []{  new Context("Global") { GlobalContext = true } });

    public static Context GetCurrentContext()
    {
        return ContextStack.Peek();
    }
    public static Context OpenNewSubContext(string name)
    {
        var newContext = new Context(name);
        GetCurrentContext().DeclareContext(name, newContext);
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
        return ContextStack.Pop();
        
    }
}