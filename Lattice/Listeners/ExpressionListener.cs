using Lattice.CommonElements;
using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public class ExpressionListener : LatticeBaseListener
{
    public override void ExitOutmostexpr(LatticeParser.OutmostexprContext context)
    {
        if (!(context.Parent is LatticeParser.AssignvalContext))
        {
            //we don't want to dump it if it's not a var assign
            GlobalFileManager.Write(PopExpressionFromStack().ToString());
        }
    }

    public override void ExitIDCASE(LatticeParser.IDCASEContext context)
    {
        var id = context.ID().GetText();
        var variable = ContextManager.GetCurrentContext().GetVariable(id);
        var expression = new LatticeExpression(id, variable.Type);
        ListenerHelper.SharedListenerStack.Push(expression);

    }

    public override void ExitUMINUS(LatticeParser.UMINUSContext context)
    {
        var expression = PopExpressionFromStack();
        if (!(expression.EvaluationType is LatticeType.Float or LatticeType.Int))
        {
            throw new Exception("Invalid operation on non-numeric expression");
        }
        var negExpression =
            new LatticeExpression($"-{expression.ExpressionText}", expression.EvaluationType);
        ListenerHelper.SharedListenerStack.Push(negExpression);    
    }

    public override void ExitDOUBLE(LatticeParser.DOUBLEContext context)
    {
        var val = context.number().INTEGER().GetText();
        LatticeType type;
        if (val != null)
        {
            type = LatticeType.Int;
        }
        else
        {
            val = context.number().FLOAT_LIT().GetText();
            type = LatticeType.Float;
        }
        var expression = new LatticeExpression(val, type);
        ListenerHelper.SharedListenerStack.Push(expression);
    }

    public override void ExitSTRINGEXPR(LatticeParser.STRINGEXPRContext context)
    {
        var expression = new LatticeExpression(context.STRING().GetText(), LatticeType.Str);
        ListenerHelper.SharedListenerStack.Push(expression);
    }

    public override void ExitPARENGRP(LatticeParser.PARENGRPContext context)
    {
        var expression = PopExpressionFromStack();
        var parenExpression =
            new LatticeExpression($"({expression.ExpressionText})", expression.EvaluationType);
        ListenerHelper.SharedListenerStack.Push(parenExpression);
    }

    public override void ExitADDOPGRP(LatticeParser.ADDOPGRPContext context)
    {
        NumericExpression(context.addop().OP_ADD() != null ? "+" : "-");
    }

    public override void ExitMULOPGRP(LatticeParser.MULOPGRPContext context)
    {
        if (context.mulop().OP_MULT() != null)
        {
            NumericExpression("*");
            return;
        }

        if (context.mulop().OP_DIV() != null)
        {
            NumericExpression("/");
            return;
        }

        if (context.mulop().OP_REM() != null)
        {
            NumericExpression("rem");
            return;
        }

    }

    private void NumericExpression(string pythonOperator)
    {
        var right = PopExpressionFromStack();
        var left = PopExpressionFromStack();

        if (!(left.EvaluationType is LatticeType.Float or LatticeType.Int &&
              right.EvaluationType is LatticeType.Float or LatticeType.Int))
        {
            throw new Exception("Invalid operation on non-numeric expression");
        }

        
        LatticeType type = left.EvaluationType == LatticeType.Float || right.EvaluationType == LatticeType.Float
            ? LatticeType.Float
            : LatticeType.Int;
        
        var expression = new LatticeExpression($"{left} {pythonOperator} {right}", type);
        ListenerHelper.SharedListenerStack.Push(expression);

    }
    private LatticeExpression PopExpressionFromStack()
    {
        if (!ListenerHelper.SharedListenerStack.TryPeek(out var expression)) return null;
        if (expression.EvaluationType != LatticeType.Bool)
        {
            return ListenerHelper.SharedListenerStack.Pop();
        }
        throw new Exception("Invalid boolean expression");
    }
}