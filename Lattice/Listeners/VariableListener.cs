using Lattice.CommonElements;
using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public class VariableListener : LatticeBaseListener
{
    public override void ExitVardecl(LatticeParser.VardeclContext context)
    {
        var type = LatticeTypeHelper.StringToLatticeType(context.type().GetText());
        if (type == LatticeType.Graph) return;
        
        var id = context.ID().GetText();
        var newLatticeVar = new LatticeVariable(id, type);
        if (ListenerHelper.SharedListenerStack.TryPop(out var latticeExpression))
        {
            AssignVarValueAndPrintPythonCode(ref newLatticeVar, latticeExpression);
        }
        ContextManager.GetCurrentContext().DeclareVariable(id, newLatticeVar);
    }

    public override void ExitTailvarassign(LatticeParser.TailvarassignContext context)
    {
        var granny = context.Parent.Parent;
        if (granny is LatticeParser.VarassignorgraphmaniporaddrelContext)
        {
            var id = ((LatticeParser.VarassignorgraphmaniporaddrelContext)granny).ID().GetText();
            var latticeVar = ContextManager.GetCurrentContext().GetVariable(id);
            var expression = ListenerHelper.SharedListenerStack.Pop();
            latticeVar.SetValue(expression);
            AssignVarValueAndPrintPythonCode(ref latticeVar, expression);
        }
    }

    private void AssignVarValueAndPrintPythonCode(ref LatticeVariable targetVar, LatticeExpression expression)
    {
        try
        {
            var node = ContextManager.GetCurrentGraphContext().GetNode(expression.ToString());
            targetVar.SetValue(new LatticeExpression(node.PythonId, node.Type));
        }
        catch (Exception e)
        {
            targetVar.SetValue(expression);
        }
        GlobalFileManager.Write($"{targetVar.Id} = {targetVar.Value} {Program.NewLine}");

    }
}