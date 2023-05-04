namespace Lattice.CommonElements;

public class LatticeTypeHelper
{
    public static LatticeType StringToLatticeType(string typeName)
    {
        //TODO: see if you can hijack some nice ANTLR token instead of string
        return typeName switch
        {
            "str" => LatticeType.Str,
            "int" => LatticeType.Int,
            "float" => LatticeType.Float,
            "bool" => LatticeType.Bool,
            "graph" => LatticeType.Graph,
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
public enum LatticeType
{
    Int,
    Str,
    Float,
    Bool,
    Graph
}