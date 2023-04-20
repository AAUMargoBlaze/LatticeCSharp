using Lattice.CommonElements;
using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public class BooleanListener : LatticeBaseListener
{
    public override void ExitBoolval(LatticeParser.BoolvalContext context)
    {
        var value = context.GetText();
        ListenerHelper.SharedListenerStack.Push((bool.Parse(value), typeof(bool)));
    }

    public override void ExitOutmostboolexpr(LatticeParser.OutmostboolexprContext context)
    {
        GlobalFileManager.Write(PopBooleanExpressionFromStack().ToString());
    }

    public override void ExitNOT(LatticeParser.NOTContext context)
    {
        var expression = PopBooleanExpressionFromStack();
        expression = new BooleanExpression($"not {expression}");
        ListenerHelper.SharedListenerStack.Push((expression, typeof(BooleanExpression)));
    }

    public override void ExitPARENGRPBOOL(LatticeParser.PARENGRPBOOLContext context)
    {
        var expression = PopBooleanExpressionFromStack();
        expression = new BooleanExpression($"({expression})");
        ListenerHelper.SharedListenerStack.Push((expression, typeof(BooleanExpression)));
    }

    public override void ExitIDBOOL(LatticeParser.IDBOOLContext context)
    {
        var id = context.ID().ToString();
        
        if (id == null) return;
        
        var ltVar = ContextManager.GetCurrentContext().GetVariable(id);
        if (ltVar.Type == LatticeType.Bool)
        {
            var expression = ltVar.Id;
            ListenerHelper.SharedListenerStack.Push((expression, typeof(BooleanExpression)));
        }
        else
        {
            throw new Exception($"{ltVar.Value} name is not a boolean variable");
        }

    }

    public override void ExitCompop(LatticeParser.CompopContext context)
    {
        var left = ListenerHelper.SharedListenerStack.Pop();
        var right = ListenerHelper.SharedListenerStack.Pop();
        var compOp = context.OP_B_EQ()?.GetText() ?? context.OP_B_NEQ()?.GetText() ?? context.OP_GRT()?.GetText()
            ?? throw new Exception("Invalid comparison operator");

        var expression = new BooleanExpression($"{left} {compOp} {right}");
        ListenerHelper.SharedListenerStack.Push((expression, typeof(BooleanExpression)));

    }

    public override void ExitBoolop(LatticeParser.BoolopContext context)
    {
        var left = PopBooleanExpressionFromStack();
        var right = PopBooleanExpressionFromStack();
        var boolOp = context.OP_B_OR()?.GetText() ?? context.OP_B_AND()?.GetText()
            ?? throw new Exception("Invalid comparison operator");

        var expression = new BooleanExpression($"{left} {boolOp} {right}");
        ListenerHelper.SharedListenerStack.Push((expression, typeof(BooleanExpression)));
        
    }

    private BooleanExpression PopBooleanExpressionFromStack()
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
        throw new Exception("Invalid boolean expression");
    }
}