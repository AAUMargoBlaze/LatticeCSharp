using Lattice.CommonElements;

namespace Lattice;

public class FunctionContext : Context
{
    public readonly  LatticeType ReturnType;
    public readonly Queue<(string name, LatticeType type)> Parameters = new ();

    public FunctionContext(string name, LatticeType returnType, Queue<(string name, LatticeType type)> parameters) : base(name)
    {
        var parentContext = ContextManager.GetCurrentContext();
        if (!parentContext.GlobalContext)
        {
            throw new Exception("Functions can only be declared in the global scope");
        }

        Parameters = parameters;
        ReturnType = returnType;
        DeclareParametersAsVariables(parameters.ToList());
    }

    private void DeclareParametersAsVariables(List<(string name, LatticeType type)> parameterList)
    {
        foreach (var pair in parameterList)
        {
            DeclareVariable(pair.name, new LatticeVariable(pair.name, pair.type));
        }
    }
    

}