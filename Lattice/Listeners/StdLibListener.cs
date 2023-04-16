namespace Lattice.Listeners;

public class StdLibListener : LatticeBaseListener
{
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