using System.Collections;
using Lattice.CommonElements;

namespace Lattice;

public class Context
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
    //todo add subcontexts
    public Context(string name)
    {
        Name = name;
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
}