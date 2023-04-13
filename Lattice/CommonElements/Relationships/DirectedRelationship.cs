namespace Lattice.CommonElements.Relationships;

public class DirectedRelationship : Relationship, ICloneable
{
    public Node Successor { get; set; }
    public Node Predecessor { get; set; }
    public DirectedRelationship(Node successor, Node predecessor) : base()
    {
        Successor = successor;
        Predecessor = predecessor;
    }

    public new object Clone()
    {
        return new DirectedRelationship((Node)Successor.Clone(), (Node)Predecessor.Clone())
        {
            Label = this.Label,
            Cost = this.Cost
        };
    }

}