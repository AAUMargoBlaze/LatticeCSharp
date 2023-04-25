using Lattice.CommonElements;
using Lattice.CommonElements.Relationships;

namespace Lattice;

public class GraphContext : Context
{
    private Dictionary<string, Node> _nodes = new ();
    private Dictionary<string, Relationship> _relationships = new ();

    
    //todo add subcontexts
    public GraphContext(string name) : base(name)
    {
    }

    public void DeclareNode(string key, Node value)
    {
        _nodes.Remove(key); //node immutability
        _nodes.Add(key, value);
    }
    
    public Node GetNode(string key)
    {
        if (_nodes.TryGetValue(key, out var value))
        {
            return value;
        }
        throw new ArgumentException($"Node with name {key} never declared in context {Name}");
    }
    
    public string DeclareRelationship(Relationship value)
    {
        string key = Guid.NewGuid().ToString();
        DeclareRelationship(key, value);
        return key;
    }
    
    public void DeclareRelationship(string key, Relationship value)
    {
        if (_relationships.ContainsKey(key))
        {
            throw new ArgumentException($"Relationship with name {key} already declared in context {Name}");
        }
        _relationships.Add(key, value);
    }
    public Relationship GetRelationship(string key)
    {
        if (_relationships.TryGetValue(key, out var value))
        {
            return value;
        }
        throw new ArgumentException($"Relationship with name {key} never declared in context {Name}");
    }

    


    public new object Clone()
    {
        var newContext = new GraphContext(Name) { GlobalContext = false };
        IterateNodesToNewContext(newContext);
        IterateRelationshipsToNewContext(newContext);

        newContext = (GraphContext)ContextClone(newContext);
        
        return newContext;
    }
    
    private void IterateNodesToNewContext(GraphContext newGraphContext)
    {
        _nodes.ToList().ForEach(kvp => newGraphContext.DeclareNode(kvp.Key, (Node)kvp.Value.Clone()));
    }

    private void IterateRelationshipsToNewContext(GraphContext newGraphContext)
    {
        _relationships.ToList().ForEach(kvp => newGraphContext.DeclareRelationship(kvp.Key, (Relationship)kvp.Value.Clone()));
    }
}