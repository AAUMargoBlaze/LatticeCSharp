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
        set => _value = value;
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