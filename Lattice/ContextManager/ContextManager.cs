namespace Lattice;

public static class ContextManager
{
    private static Context _currentContext = new Context("Global") {GlobalContext = true};

    public static Context GetCurrentContext()
    {
        return _currentContext;
    }
    public static Context OpenNewContext()
    {
        throw new NotImplementedException();
    }

    public static Context EnterSubContext()
    {
        throw new NotImplementedException();
    }

    public static Context ExitSubContext()
    {
        throw new NotImplementedException();

        if (_currentContext.GlobalContext)
        {
            throw new Exception("Can't exit global context");
        }
        else
        {
            //Enter new context
        }
    }
}