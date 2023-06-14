using System.Text;
using Lattice.CommonElements;
using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public class ExpressionListener : LatticeBaseListener
{
    public override void ExitIDCASE(LatticeParser.IDCASEContext context)
    {
        var id = context.ID().GetText();
        LatticeExpression expression = null;
        try
        {
            var variable = ContextManager.GetCurrentContext().GetVariable(id);
            expression = new LatticeExpression(id, variable.Type);
        }
        catch (Exception e)
        {
            var graph = (GraphContext)ContextManager.GetCurrentContext();
            var node = graph.GetNode(id);
            // expression = new LatticeExpression($"get_node_from_list('{node.Id}', '{graph.Name}')", node.Type);
            expression = new LatticeExpression($"{graph.Name}.get_node(str({node.Id}))", node.Type);
        }

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
        var typeval = context.number().INTEGER();
        var val = "";
        LatticeType type;
        if (typeval != null)
        {
            val = context.number().INTEGER().GetText();
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

    public override void ExitFunccall(LatticeParser.FunccallContext context)
    {
        var name = context.ID().GetText();
        StringBuilder expressionText = new StringBuilder();
        if (!ContextManager.DeclaredFunctions.TryGetValue(name, out var function))
        {
            throw new Exception($"Undeclared function: {name}");
        }

        expressionText.Append($"{name}(");
        
        //reversed because the rightmost expression is pushed last in the stack
        var reversedClone = new Queue<(string name, LatticeType type)>(function.Parameters.Reverse());
        var functionCallExpressionStack = new Stack<LatticeExpression>();
        while (0 < reversedClone.Count)
        {
            var param = reversedClone.Dequeue();
            var expr = ListenerHelper.SharedListenerStack.Pop();
            if (param.type != expr.EvaluationType)
            {
                throw new Exception($"Invalid function call. {param.name} is of type {param.type}, instead called" +
                                    $"with type {expr.EvaluationType} - {expr.ExpressionText}");
            }
            functionCallExpressionStack.Push(expr);
        }

        while (0 < functionCallExpressionStack.Count)
        {
            var expr = functionCallExpressionStack.Pop();
            expressionText.Append(expr.ExpressionText);
            if (0 < functionCallExpressionStack.Count)
            {
                expressionText.Append(", ");
            }
        }
        
        expressionText.Append(")");

        //print it if statement, otherwise push on stack
        if (context.Parent is LatticeParser.StatementContext)
        {
            GlobalFileManager.Write(expressionText.ToString());
            GlobalFileManager.Write(Program.NewLine);
        }
        else
        {
            var newExpr = new LatticeExpression(expressionText.ToString(), function.ReturnType);
            ListenerHelper.SharedListenerStack.Push(newExpr);
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