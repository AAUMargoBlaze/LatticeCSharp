using System.Configuration;
using Antlr4.Runtime.Tree;
using Lattice.CommonElements.Expressions;

namespace Lattice.CommonElements;

public class LatticeVariable : ICloneable
{
    public readonly LatticeType Type;
    public readonly string Id;


    private string _value;
    public string Value
    {
        get => _value;
    }
    
    public LatticeVariable(string id, LatticeType type)
    {
        Id = id;
        Type = type;
        _value = LatticeTypeHelper.GetDefaultValueOfLatticeType(type);
    }

    public void SetValue(LatticeExpression expression)
    {
        if (expression.EvaluationType != Type)
        {
            throw new Exception($"Can't assign {expression.EvaluationType} to {Type}");
        }

        _value = expression.ExpressionText;
    }
    public object Clone()
    {
        var cloned = new LatticeVariable(Id, Type);
        cloned.SetValue(new LatticeExpression(_value, Type));
        return cloned;
    }
}