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
        if (ListenerHelper.SharedListenerStack.TryPop(out var valueTuple))
        {
            AssignVarValueAndPrintPythonCode(ref newLatticeVar, valueTuple);
        }
        ContextManager.GetCurrentContext().DeclareVariable(id, newLatticeVar);
    }

    public override void ExitVarassignorgraphmanip(LatticeParser.VarassignorgraphmanipContext context)
    {
        var id = context.ID().GetText();
        try
        {
            //if this exists we must be in a var assign
            var ltVar = ContextManager.GetCurrentContext().GetVariable(id);
            
            //pushed in ExitAssignval()
            var pair = ListenerHelper.SharedListenerStack.Pop();
            AssignVarValueAndPrintPythonCode(ref ltVar, pair);

        }
        catch (ArgumentException) { } //it can be a graph
        //todo, if neither graph nor var assign catches it throw exception
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