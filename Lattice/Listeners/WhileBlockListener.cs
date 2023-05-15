namespace Lattice.Listeners;

public class WhileBlockListener : LatticeBaseListener
{
    public override void EnterWhileblockheader(LatticeParser.WhileblockheaderContext context)
    {
        GlobalFileManager.Write("while ");
    }

    public override void ExitWhileblockheader(LatticeParser.WhileblockheaderContext context)
    {
        var expression = ListenerHelper.SharedListenerStack.Pop();
        
        string key = Guid.NewGuid().ToString();
        var whileContext = new WhileBlockContext(key);
        ContextManager.OpenNewSubContext(whileContext);
        
        GlobalFileManager.Write($"{expression}:{Program.NewLine}");
        GlobalFileManager.Indent();
    }

    public override void ExitWhileblock(LatticeParser.WhileblockContext context)
    {
        ContextManager.ExitSubContext();
        GlobalFileManager.Outdent();
        GlobalFileManager.Write(Program.NewLine);
    }
}