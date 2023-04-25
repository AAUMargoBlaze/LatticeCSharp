namespace Lattice.CommonElements.Expressions;

public abstract class Expression
{
    public readonly string ExpressionText;
    public Expression(string expressionText)
    {
        ExpressionText = expressionText;
    }
    public override string ToString()
    {
        return ExpressionText.ToString();
    }
}