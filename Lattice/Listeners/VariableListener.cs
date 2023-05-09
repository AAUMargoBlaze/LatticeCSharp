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
            latticeVar.Value = expression.ReturnExpressionInNativeType();
            AssignVarValueAndPrintPythonCode(ref latticeVar, expression);
        }
    }

    public override void ExitAssignval(LatticeParser.AssignvalContext context)
    {
        //TODO: probably there is a nicer solution here
        var temp = context.number()?.INTEGER()?.GetText();
        if (temp != null)
        {
            ListenerHelper.SharedListenerStack.Push(new LatticeExpression(temp, LatticeType.Int));
            return;
        }
        
        temp = context.number()?.FLOAT_LIT()?.GetText();
        if (temp != null)
        {
            ListenerHelper.SharedListenerStack.Push(new LatticeExpression(temp, LatticeType.Float));
            return;
        }
        
        temp = context.STRING()?.GetText();
        
        if (temp != null)
        {
            ListenerHelper.SharedListenerStack.Push(new LatticeExpression(temp, LatticeType.Str));
            return;
        }
        //bool handled in BooleanListener
    }
    
    private void AssignVarValueAndPrintPythonCode(ref LatticeVariable targetVar, LatticeExpression expression)
    {
        targetVar.Value = expression.ReturnExpressionInNativeType();
        GlobalFileManager.Write($"{targetVar.Id} = {targetVar.Value} {Program.NewLine}");
    }
}