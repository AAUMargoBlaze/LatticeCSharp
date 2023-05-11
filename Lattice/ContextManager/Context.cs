using Lattice.CommonElements;
using Lattice.CommonElements.Expressions;

namespace Lattice;

public abstract class Context : ICloneable
{
    private static bool _globalContextSet = false;

    private readonly bool _globalContext = false;
    public readonly string Name;
    
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
    
    private Dictionary<string, LatticeVariable> _variables = new ();
    private Dictionary<string, Context> _subContexts = new ();

    public Context(string name)
    {
        Name = name;
    }
    
    public void DeclareVariable(string key, LatticeVariable value)
    {
        if (_variables.ContainsKey(key))
        {
            throw new ArgumentException($"Variable with name {key} already declared in context");
        }
        _variables.Add(key, value);
    }

    public void AssignValueToVariable<T>(string key, LatticeExpression newValue)
    {
        if (_variables.TryGetValue(key, out var oldValue))
        {
            try
            {
                oldValue.SetValue(newValue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            throw new ArgumentException($"Variable with name {key} never declared in context");
        }
    }

    public LatticeVariable GetVariable(string key)
    {
        if (_variables.TryGetValue(key, out var value))
        {
            return value;
        }
        throw new ArgumentException($"Variable with name {key} never declared in context");
    }

    public void DeclareContext(string key, Context subGraphContext)
    {
        if (_subContexts.ContainsKey(key))
        {
            throw new ArgumentException($"Subcontext with name {subGraphContext.Name} already declared inside");
        }
        _subContexts.Add(key, subGraphContext);
    }

    public Context GetSubContext(string key)
    {
        if (_subContexts.TryGetValue(key, out var value))
        {
            return value;
        }
        throw new ArgumentException($"Subcontext with name: {key} never declared inside");
    }
    
    public object Clone()
    {
        throw new NotImplementedException();
    }

    protected Context ContextClone(Context clone)
    {
        IterateVariablesToNewContext(clone);
        IterateSubContextsToNewContext(clone);
        return clone;
    }
    
    private void IterateVariablesToNewContext(Context newGraphContext)
    {
        _variables.ToList().ForEach(kvp => newGraphContext.DeclareVariable(kvp.Key, (LatticeVariable)kvp.Value.Clone()));
    }

    private void IterateSubContextsToNewContext(Context newGraphContext)
    {
        _subContexts.ToList().ForEach(kvp => newGraphContext.DeclareContext(kvp.Key, (GraphContext)kvp.Value.Clone()));
    }

    public Dictionary<string, LatticeVariable>  ReturnAllDeclaredVariables()
    {
        return _variables;
    }

}