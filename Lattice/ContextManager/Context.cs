using System.Collections;
using Lattice.CommonElements;
using Lattice.CommonElements.Relationships;

namespace Lattice;

public class Context : ICloneable
{
    private static bool _globalContextSet = false;

    private readonly bool _globalContext = false;
    public bool GlobalContext
    {
        get => _globalContext;
        init
        {
            _globalContextSet = value switch
            {
                true when _globalContextSet => throw new Exception("Only a single context can be set as global"),
                true => true,
                _ => _globalContextSet
            };
            _globalContext = value;
        }
    }

    public readonly string Name;

    private Dictionary<string, Node> _nodes = new ();
    private Dictionary<string, Relationship> _relationships = new ();
    private Dictionary<string, LatticeVariable> _variables = new ();
    private Dictionary<string, Context> _subContexts = new ();
    
    //todo add subcontexts
    public Context(string name)
    {
        Name = name;
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

    
    public void DeclareVariable(string key, LatticeVariable value)
    {
        if (_variables.ContainsKey(key))
        {
            throw new ArgumentException($"Variable with name {key} already declared in context {Name}");
        }
        _variables.Add(key, value);
    }

    public void AssignValueToVariable<T>(string key, T newValue)
    {
        if (_variables.TryGetValue(key, out var oldValue))
        {
            try
            {
                oldValue.Value = newValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            throw new ArgumentException($"Variable with name {key} never declared in context {Name}");
        }
    }

    public LatticeVariable GetVariable(string key)
    {
        if (_variables.TryGetValue(key, out var value))
        {
            return value;
        }
        throw new ArgumentException($"Variable with name {key} never declared in context {Name}");
    }

    public void DeclareContext(string key, Context subContext)
    {
        if (_subContexts.ContainsKey(key))
        {
            throw new ArgumentException($"Subcontext with name {subContext.Name} already declared inside {Name}");
        }
        _subContexts.Add(key, subContext);
    }

    public Context GetSubContext(string key)
    {
        if (_subContexts.TryGetValue(key, out var value))
        {
            return value;
        }
        throw new ArgumentException($"Subcontext with name: {key} never declared inside {Name}");
    }

    public object Clone()
    {
        var newContext = new Context(Name) { GlobalContext = false };
        IterateNodesToNewContext(newContext);
        IterateRelationshipsToNewContext(newContext);
        IterateVariablesToNewContext(newContext);
        IterateSubContextsToNewContext(newContext);
        return newContext;
    }
    
    private void IterateNodesToNewContext(Context newContext)
    {
        _nodes.ToList().ForEach(kvp => newContext.DeclareNode(kvp.Key, (Node)kvp.Value.Clone()));
    }

    private void IterateRelationshipsToNewContext(Context newContext)
    {
        _relationships.ToList().ForEach(kvp => newContext.DeclareRelationship(kvp.Key, (Relationship)kvp.Value.Clone()));
    }

    private void IterateVariablesToNewContext(Context newContext)
    {
        _variables.ToList().ForEach(kvp => newContext.DeclareVariable(kvp.Key, (LatticeVariable)kvp.Value.Clone()));
    }

    private void IterateSubContextsToNewContext(Context newContext)
    {
        _subContexts.ToList().ForEach(kvp => newContext.DeclareContext(kvp.Key, (Context)kvp.Value.Clone()));
    }
}