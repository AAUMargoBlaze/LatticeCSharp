using Antlr4.Runtime.Tree;

namespace Lattice.CommonElements;

public class LatticeVariable
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
                    (newValueType == typeof(bool) && Type == LatticeType.Bool)
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
        _value = GetDefaultValueOfLatticeType(type);
    }

    public static LatticeType StringToLatticeType(string typeName)
    {
        //TODO: see if you can hijack some nice ANTLR token instead of string
        return typeName switch
        {
            "str" => LatticeType.Str,
            "int" => LatticeType.Int,
            "float" => LatticeType.Float,
            "bool" => LatticeType.Bool,
            _ => throw new ArgumentOutOfRangeException($"Invalid type name: {typeName}")
        };
    }
    public static dynamic GetDefaultValueOfLatticeType(LatticeType type)
    {
        return type switch
        {
            LatticeType.Int => default(int),
            LatticeType.Str => "",
            LatticeType.Float => default(float),
            LatticeType.Bool => default(bool),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
    
}

//TODO move all the helper variables away from the Variable class
public enum LatticeType
{
    Int,
    Str,
    Float,
    Bool
}