namespace Lattice.AST;

public record AssignmentNode(TypeNode NodeType) : BaseNode
{
    public override T Accept<T>(NodeVisitor<T> visitor)
    {
        return visitor.VisitAssignment(this);
    }
}