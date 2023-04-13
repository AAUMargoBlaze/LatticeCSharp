using Antlr4.Runtime.Tree;
using Lattice.CommonElements;

namespace Lattice;

public class LatticeListener : LatticeBaseListener
{
    private Stack<(object value, Type type)>  _stack = new ();
    public override void ExitVardecl(LatticeParser.VardeclContext context)
    {
        var currentContext = ContextManager.GetCurrentContext();
        var id = context.ID().GetText();
        var type = context.type().GetText();

        var newLatticeVar = new LatticeVariable(id, LatticeVariable.StringToLatticeType(type));
        ContextManager.GetCurrentContext().DeclareVariable(id, newLatticeVar);
        //GlobalFileManager.Write($"{id} {Program.NewLine}");
    }

    public override void ExitVarassignorgraphmanip(LatticeParser.VarassignorgraphmanipContext context)
    {
        var id = context.ID().GetText();
        try
        {
            //if this exists we must be in a var assign
            var ltVar = ContextManager.GetCurrentContext().GetVariable(id);
            
            //pushed in ExitAssignval()
            var pair = _stack.Pop();
            ltVar.Value = Convert.ChangeType(pair.value, pair.type);
            
            GlobalFileManager.Write($"{ltVar.Id} = {ltVar.Value} {Program.NewLine}");
        }
        catch (ArgumentException _) { } //it can be a graph
    }

    public override void ExitAssignval(LatticeParser.AssignvalContext context)
    {
        //TODO: probably there is a nicer solution here
        var temp = context.INTEGER()?.GetText();
        if (temp != null)
        {
            _stack.Push((temp, typeof(int)));
            return;
        }
        temp = context.STRING()?.GetText();
        
        if (temp != null)
        {
            _stack.Push((temp, typeof(string)));
            return;
        }
        
    }

    public override void ExitPrintstatement(LatticeParser.PrintstatementContext context)
    {
        var outVal = context.STRING()?.GetText();
        var id = context.ID()?.GetText();
        if (id != null)
            outVal = ContextManager.GetCurrentContext().GetVariable(id).Value.ToString();

        if (outVal != null)
        {
            GlobalFileManager.Write($"print({outVal}) {Program.NewLine}");
        }
        else
        {
            throw new Exception("Invalid print statement");
        }
    }
}