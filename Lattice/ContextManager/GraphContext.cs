using Lattice.CommonElements;
using Lattice.CommonElements.Expressions;
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

    public Node DeclareNode(string key, Node value)
    {
        _nodes.Remove(key); //node immutability
        _nodes.Add(key, value);
        return value;
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

    public bool CheckFmapTypeSafety(FunctionContext functionContext)
    {
        return functionContext.Parameters.Count == 1 && _nodes.All(kvp => kvp.Value.Type == functionContext.Parameters.Peek().type);
    }

    public void ApplyFmap(FunctionContext functionContext)
    {
        //5 => funcname(5)
        foreach (var kvp in _nodes.ToList())
        {
            var newNode = new Node(kvp.Value.Id, functionContext.ReturnType);
            newNode.SetValue(new LatticeExpression($"{functionContext.Name}({kvp.Value.Value})", functionContext.ReturnType));
            _nodes.Remove(kvp.Key);
            _nodes.Add(kvp.Key, newNode);
        }
    }
    public new object Clone()
    {
        var newContext = new GraphContext(Name) { GlobalContext = false };
        IterateToNewContext(newContext);

        newContext = (GraphContext)ContextClone(newContext);
        
        return newContext;
    }
    
    public void IterateToNewContext(GraphContext newGraphContext)
    {
        foreach (var nodeKVP in _nodes)
        {
            var clonedNode = (Node)nodeKVP.Value.Clone();
            newGraphContext.DeclareNode(nodeKVP.Key, clonedNode);
        }

        foreach (var relKVP in _relationships)
        {
            var oldRel = relKVP.Value;
            if (oldRel is DirectedRelationship)
            {
                var oldDirRel = (DirectedRelationship)oldRel;
                var predCloneNode = newGraphContext.GetNode(oldDirRel.Predecessor.Id);
                var sucCloneNode = newGraphContext.GetNode(oldDirRel.Successor.Id);

                var rel = new DirectedRelationship(predCloneNode, sucCloneNode);
                rel.Cost = oldDirRel.Cost;
                rel.Label = oldDirRel.Label;

                newGraphContext.DeclareRelationship(rel);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    public void Reset()
    {
        _nodes = new ();
        _relationships = new ();
        _variables = new();
        _subContexts = new();
    }
    public Dictionary<string, Node>  ReturnAllDeclaredNodes()
    {
        return _nodes;
    } 
}