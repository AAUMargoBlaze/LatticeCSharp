using Lattice.CommonElements;

namespace Lattice;

public class FunctionContext : Context
{
    public readonly  LatticeType ReturnType;
    public FunctionContext(string name, LatticeType returnType) : base(name)
    {
        var parentContext = ContextManager.GetCurrentContext();
        if (!parentContext.GlobalContext)
        {
            throw new Exception("Functions can only be declared in the global scope");
        }

        ReturnType = returnType;
    }
}