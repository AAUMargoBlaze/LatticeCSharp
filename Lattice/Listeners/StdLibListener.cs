namespace Lattice.Listeners;

public class StdLibListener : LatticeBaseListener
{
    public override void ExitPrintstatement(LatticeParser.PrintstatementContext context)
    {
        var outVal = context.STRING()?.GetText();
        var id = context.ID()?.GetText();
        if (id != null)
        {
            var currentGraph = ContextManager.GetCurrentContext();
            try
            {
                outVal = currentGraph.GetVariable(id).Value.ToString();
            }
            catch (ArgumentException e)
            {
                outVal = currentGraph.GetSubContext(id).Name;
            }
        }

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