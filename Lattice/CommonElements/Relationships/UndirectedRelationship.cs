namespace Lattice.CommonElements.Relationships;

public class UndirectedRelationship : Relationship, ICloneable
{
    public (Node, Node) Neighbors { get; set; }
    public UndirectedRelationship(Node first, Node second)
    {
        Neighbors = (first, second);
    }
    public new object Clone()
    {
        return new UndirectedRelationship((Node)Neighbors.Item1.Clone(), (Node)Neighbors.Item2.Clone())
        {
            Label = this.Label,
            Cost = this.Cost
        };
    }
}