using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public class ExpressionListener : LatticeBaseListener
{
    public override void ExitIDCASE(LatticeParser.IDCASEContext context)
    {
        var id = context.ID().GetText();
        var expression = new ClassicalExpression(id);
        ListenerHelper.SharedListenerStack.Push((expression, typeof(ClassicalExpression)));

    }
}