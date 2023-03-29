namespace Lattice.AST;

public record TypeNode: BaseNode
{
    public override T Accept<T>(NodeVisitor<T> visitor)
    {
        return visitor.VisitType(this);
    }
}