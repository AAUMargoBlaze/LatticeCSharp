namespace Lattice.Listeners;

public class IfElseBlockListener : LatticeBaseListener
{
    public override void EnterIfheader(LatticeParser.IfheaderContext context)
    {
        GlobalFileManager.Write("if ");
    }

    public override void ExitIfheader(LatticeParser.IfheaderContext context)
    {
        var expression = ListenerHelper.SharedListenerStack.Pop();
        OpenNewIfElseContext();
        GlobalFileManager.Write($"{expression}:{Program.NewLine}");
        GlobalFileManager.Indent();
    }

    public override void ExitIfblock(LatticeParser.IfblockContext context)
    {
        ExitIfElseContext();

    }

    public override void EnterElseblock(LatticeParser.ElseblockContext context)
    {
        OpenNewIfElseContext();
        GlobalFileManager.Outdent();
        GlobalFileManager.Write($"else:{Program.NewLine}");
        GlobalFileManager.Indent();
    }

    public override void ExitElseblock(LatticeParser.ElseblockContext context)
    {
        ContextManager.ExitSubContext();
    }
    
    private void OpenNewIfElseContext()
    {
        string key = Guid.NewGuid().ToString();
        var ifContext = new IfBlockContext(key);
        ContextManager.OpenNewSubContext(ifContext);
    }

    private void ExitIfElseContext()
    {
        ContextManager.ExitSubContext();
        GlobalFileManager.Outdent();
        GlobalFileManager.Write(Program.NewLine);
    }

}