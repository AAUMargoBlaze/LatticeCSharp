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
    public dynamic ReturnExpressionInNativeType()
    {
        return EvaluationType switch
        {
            LatticeType.Int => Convert.ToInt32(ExpressionText),
            LatticeType.Str => ExpressionText,
            LatticeType.Float => Convert.ToDouble(ExpressionText),
            LatticeType.Bool => bool.Parse(ExpressionText),
            LatticeType.Graph => throw new Exception("Blame Balazs if this isn't fixed"),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}