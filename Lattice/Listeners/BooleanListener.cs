using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public class BooleanListener : LatticeBaseListener
{
    public override void ExitBoolval(LatticeParser.BoolvalContext context)
    {
        var value = context.GetText();
        ListenerHelper.SharedListenerStack.Push((bool.Parse(value), typeof(bool)));
    }

    public override void ExitNOT(LatticeParser.NOTContext context)
    {
        base.ExitNOT(context);
    }

    private BooleanExpression? TryPopBooleanExpressionFromStack()
    {
        if (!ListenerHelper.SharedListenerStack.TryPeek(out var valueTuple)) return null;
        if (valueTuple.type == typeof(bool))
        {
            ListenerHelper.SharedListenerStack.Pop();
            return new BooleanExpression(valueTuple.value.ToString());
        }
        if (valueTuple.type == typeof(BooleanExpression))
        {
            return (BooleanExpression)ListenerHelper.SharedListenerStack.Pop().value;
        }
        return null;
    }
}