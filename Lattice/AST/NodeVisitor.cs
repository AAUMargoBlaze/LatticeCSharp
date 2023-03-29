namespace Lattice.AST;

public class NodeVisitor<T>
{
    public virtual T Default => default;
    public virtual T VisitAssignment(AssignmentNode assignment) => Default;
    public virtual T VisitType(TypeNode type) => Default;
}