namespace Lattice.AST;

public abstract record BaseNode
{
    public abstract T Accept<T>(NodeVisitor<T> visitor); 
}