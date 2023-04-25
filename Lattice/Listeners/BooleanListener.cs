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

    public override void ExitCOMPGRP(LatticeParser.COMPGRPContext context)
    {
        var right = ListenerHelper.SharedListenerStack.Pop();
        var left = ListenerHelper.SharedListenerStack.Pop();
        
        var compOp = context.compop().OP_B_EQ()?.GetText() ?? context.compop().OP_B_NEQ()?.GetText() ?? context.compop().OP_GRT()?.GetText()
            ?? throw new Exception("Invalid comparison operator");

        var expression = new BooleanExpression($"{left.value} {compOp} {right.value}");
        ListenerHelper.SharedListenerStack.Push((expression, typeof(BooleanExpression)));

    }

    public override void ExitBOOLOP(LatticeParser.BOOLOPContext context)
    {
        var left = PopBooleanExpressionFromStack();
        var right = PopBooleanExpressionFromStack();

        var boolOp = "";
        if (context.boolop().OP_B_OR() != null)
        {
            boolOp = "or";
        }

        else if (context.boolop().OP_B_AND() != null)
        {
            boolOp = " and ";
        }
        else
        {
            throw new Exception($"Invalid boolean operator {context.GetText()}");
        }
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