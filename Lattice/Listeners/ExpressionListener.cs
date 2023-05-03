using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public class ExpressionListener : LatticeBaseListener
{
    public override void ExitIDCASE(LatticeParser.IDCASEContext context)
    {
        var id = context.ID().GetText();
        var variable = ContextManager.GetCurrentContext().GetVariable(id);
        var expression = new LatticeExpression(id, variable.Type);
        ListenerHelper.SharedListenerStack.Push((expression, typeof(LatticeExpression)));

    }
}