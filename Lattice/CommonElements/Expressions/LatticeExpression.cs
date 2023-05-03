namespace Lattice.CommonElements.Expressions;

public class LatticeExpression
{
    public readonly string ExpressionText;
    public readonly LatticeType EvaluationType;
    public LatticeExpression(string expressionText, LatticeType evaluationType)
    {
        ExpressionText = expressionText;
        EvaluationType = evaluationType;
    }
    public override string ToString()
    {
        return ExpressionText.ToString();
    }
}