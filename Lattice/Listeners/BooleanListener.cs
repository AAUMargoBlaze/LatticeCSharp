using Lattice.CommonElements;
using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public class BooleanListener : LatticeBaseListener
{
    public override void ExitBoolval(LatticeParser.BoolvalContext context)
    {
        var value = context.GetText();
        ListenerHelper.SharedListenerStack.Push(new LatticeExpression(bool.Parse(value).ToString(), LatticeType.Bool)); //type check for lazy people
    }

    public override void ExitOutmostboolexpr(LatticeParser.OutmostboolexprContext context)
    {
        GlobalFileManager.Write(PopBooleanExpressionFromStack().ToString());
    }

    public override void ExitNOT(LatticeParser.NOTContext context)
    {
        var expression = PopBooleanExpressionFromStack();
        expression = new LatticeExpression($"not {expression}", LatticeType.Bool);
        ListenerHelper.SharedListenerStack.Push(expression);
    }

    public override void ExitPARENGRPBOOL(LatticeParser.PARENGRPBOOLContext context)
    {
        var expression = PopBooleanExpressionFromStack();
        expression = new LatticeExpression($"({expression})", LatticeType.Bool);
        ListenerHelper.SharedListenerStack.Push(expression);
    }

    public override void ExitIDBOOL(LatticeParser.IDBOOLContext context)
    {
        var id = context.ID().ToString();
        
        if (id == null) return;
        
        var ltVar = ContextManager.GetCurrentContext().GetVariable(id);
        if (ltVar.Type == LatticeType.Bool)
        {
            ListenerHelper.SharedListenerStack.Push(new LatticeExpression(id, LatticeType.Bool));
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

        //type check
        if (right.EvaluationType == left.EvaluationType)
        {
            
        }
        else
        {
            throw new Exception("Type mismatch in comparison operator");
        }

            var expression = new LatticeExpression($"{left} {compOp} {right}", LatticeType.Bool);
        ListenerHelper.SharedListenerStack.Push(expression);

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
        var expression = new LatticeExpression($"{left} {boolOp} {right}", LatticeType.Bool);
        ListenerHelper.SharedListenerStack.Push(expression);
    }

    private LatticeExpression PopBooleanExpressionFromStack()
    {
        if (!ListenerHelper.SharedListenerStack.TryPeek(out var expression)) return null;
        if (expression.EvaluationType == LatticeType.Bool)
        {
            return ListenerHelper.SharedListenerStack.Pop();
        }
        throw new Exception("Invalid boolean expression");
    }
}