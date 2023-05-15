namespace Lattice.CommonElements;

//Right now I'll leave Nodes as a simple wrapper around LatticeVariable, just in case we want to take it further
public class Node : LatticeVariable, ICloneable
{
    public Node(string id, LatticeType type) : base(id, type) { }
    public new object Clone()
    {
        string unique = Guid.NewGuid().ToString();
        return new Node($"{Id}-{unique}", Type);
    }
}