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

    public override void EnterEveryRule(ParserRuleContext context)
    {
        while (ListenerHelper.LexerInterjects.Count > 0)
        {
            var interject = ListenerHelper.LexerInterjects.Dequeue();
            GlobalFileManager.Write(interject);
        }
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
        //todo check if variable exists;
        if (id != null)
        {
            GlobalFileManager.Write($"print({id}) {Program.NewLine}");
            return;
        }
        if (outVal != null)
        {
            GlobalFileManager.Write($"print({outVal}) {Program.NewLine}");
            return;
        }
        throw new Exception("Invalid print statement");
    }
}