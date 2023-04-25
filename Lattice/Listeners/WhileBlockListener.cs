namespace Lattice.Listeners;

public class WhileBlockListener : LatticeBaseListener
{
    public override void EnterWhileblockheader(LatticeParser.WhileblockheaderContext context)
    {
        GlobalFileManager.Write("while ");
    }

    public override void ExitWhileblockheader(LatticeParser.WhileblockheaderContext context)
    {
        string key = Guid.NewGuid().ToString();
        var ifContext = new WhileBlockContext(key);
        ContextManager.OpenNewSubContext(ifContext);
        
        GlobalFileManager.Write($":{Program.NewLine}");
        GlobalFileManager.Indent();
    }

    public override void ExitWhileblock(LatticeParser.WhileblockContext context)
    {
        ContextManager.ExitSubContext();
        GlobalFileManager.Outdent();
        GlobalFileManager.Write(Program.NewLine);
    }
}