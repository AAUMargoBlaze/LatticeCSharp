using Antlr4.Runtime.Tree;
using Lattice.CommonElements;

namespace Lattice.Listeners;

public class FunctionListener : LatticeBaseListener
{
    public override void ExitFuncdefheader(LatticeParser.FuncdefheaderContext context)
    {
        var name = context.ID().GetText();
        var args = ExtractFunctionArgumentsFromContext(context);
        
        var returnType = LatticeTypeHelper.StringToLatticeType(context.type().GetText());
        //cloning the queue because I don't want to dequeue a referenced version
        var funcContext = new FunctionContext(name, returnType, new Queue<(string name, LatticeType type)>(args));
        ContextManager.OpenNewSubContext(funcContext);
        
        GlobalFileManager.Write($"def {name}(");
        while (0 < args.Count)
        {
            var arg = args.Dequeue();
            GlobalFileManager.Write(arg.name);
            if (0 < args.Count)
            {
                GlobalFileManager.Write(", ");
            }
        }
        GlobalFileManager.Write($"): {Program.NewLine}");
        GlobalFileManager.Indent();
    }

    public override void ExitFuncdef(LatticeParser.FuncdefContext context)
    {
        GlobalFileManager.Write($"return None {Program.NewLine}");
        ContextManager.ExitSubContext();
        GlobalFileManager.Outdent();
    }

    public override void ExitReturnstatement(LatticeParser.ReturnstatementContext context)
    {
        var expression = ListenerHelper.SharedListenerStack.Pop();
        if (expression.EvaluationType != ContextManager.CurrentFunctionContext.ReturnType)
        {
            throw new Exception($"Invalid return type, function should return {ContextManager.CurrentFunctionContext.ReturnType}, instead it " +
                                $"returns {expression.EvaluationType}");
        }
        GlobalFileManager.Write($"return {expression.ExpressionText} {Program.NewLine}");
    }

    private Queue<(string name, LatticeType type)> ExtractFunctionArgumentsFromContext(LatticeParser.FuncdefheaderContext context)
    {
        var parameters = new Queue<(string name, LatticeType type)>();
        var args = context.listargs()?.children ?? new List<IParseTree>();
        if (1 <= args.Count)
        {
            var firstParam = (LatticeParser.ArgContext)args[0];
            parameters.Enqueue((firstParam.ID().GetText(), LatticeTypeHelper.StringToLatticeType(firstParam.type().GetText())));
        }

        if (args.Count != 2) return parameters;
        var rest = (LatticeParser.TaillistargContext)args[1];
        foreach (var child in rest.children ?? Array.Empty<LatticeParser.ArgContext>())
        {
            if (child is TerminalNodeImpl)
            {
                continue;
            }

            var arg = (LatticeParser.ArgContext)child; 
            parameters.Enqueue((arg.ID().GetText(), LatticeTypeHelper.StringToLatticeType(arg.type().GetText())));
                
        }
        return parameters;

    }
     
}