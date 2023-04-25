using Antlr4.Runtime.Tree;
using Lattice.CommonElements.Expressions;

namespace Lattice.CommonElements;

public class LatticeVariable : ICloneable
{
    public readonly LatticeType Type;
    public readonly string Id;


    private dynamic _value;
    public dynamic Value
    {
        get => _value;
        set
        {
            var newValueType = value.GetType();
            if (
                    (newValueType == typeof(string) && Type == LatticeType.Str) ||
                    (newValueType == typeof(int) && Type == LatticeType.Int) ||
                    (newValueType == typeof(float) && Type == LatticeType.Float) ||
                    (newValueType == typeof(double) && Type == LatticeType.Float) ||
                    (newValueType == typeof(bool) && Type == LatticeType.Bool) ||
                    (newValueType == typeof(BooleanExpression) && Type == LatticeType.Bool)
            )
            {
                _value = value;
            }
            else
            {
                throw new InvalidCastException($"Can't convert from {newValueType} to {Type}");
            }
        }

    }

    public LatticeVariable(string id, LatticeType type)
    {
        Id = id;
        Type = type;
        _value = LatticeTypeHelper.GetDefaultValueOfLatticeType(type);
    }

    public object Clone()
    {
        var cloned = new LatticeVariable(Id, Type);
        cloned.Value = _value;
        return cloned;
    }
}