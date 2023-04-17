using System.Text.RegularExpressions;
using Antlr4.Runtime;

namespace Lattice.Listeners;

public class StdLibListener : LatticeBaseListener
{
    private CommonTokenStream _tokenStream;

    public StdLibListener(CommonTokenStream tokenStream)
    {
        _tokenStream = tokenStream;
    }

    public override void EnterStart(LatticeParser.StartContext context)
    {
        GlobalFileManager.Write($"from lattice import Node {Program.NewLine}");
        GlobalFileManager.Write($"from lattice import TraverseEdge {Program.NewLine}");
        GlobalFileManager.Write($"from lattice import BBTree, Graph {Program.NewLine}");
    }

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