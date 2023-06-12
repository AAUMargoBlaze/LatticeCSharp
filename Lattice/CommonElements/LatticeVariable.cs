using System.Configuration;
using Antlr4.Runtime.Tree;
using Lattice.CommonElements.Expressions;

namespace Lattice.CommonElements;

public class LatticeVariable : ICloneable
{
    public readonly LatticeType Type;
    public readonly string Id;
    public readonly string PythonId;
    public bool Referential = false;
    
    private string _value;
    public string Value
    {
        get => _value;
    }
    
    public LatticeVariable(string id, LatticeType type, string? pythonId = null)
    {
        Id = id;
        PythonId = pythonId ?? Id;
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
        string unique = Guid.NewGuid().ToString().Replace('-', '_');
        var cloned = new LatticeVariable(Id, Type, $"{Id}-{unique}");
        cloned.SetValue(new LatticeExpression(_value, Type));
        return cloned;
    }
}