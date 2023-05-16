using System.Security.Cryptography.X509Certificates;
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
        GlobalFileManager.Write($"from lattice import VisualEdge as Edge {Program.NewLine}");
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

    public override void ExitFmapstatement(LatticeParser.FmapstatementContext context)
    {
        var graphName = context.ID()[0].GetText();
        var functionName = context.ID()[1].GetText();

        if (!ContextManager.DeclaredFunctions.TryGetValue(functionName, out var function))
        {
            throw new Exception($"Function not found {functionName}");
        }

        GraphContext graph;
        try
        {
             graph = (GraphContext)ContextManager.GetCurrentContext().GetSubContext(graphName);
        }
        catch (Exception e)
        {
            throw new Exception($"{graphName} is not a graph");
        }

        if (graph.CheckFmapTypeSafety(function))
        {
            graph.ApplyFmap(function);
            GlobalFileManager.Write($"{graphName}.apply({functionName}){Program.NewLine}");
        }
        else
        {
            throw new Exception(
                "Fmap function must take exactly one parameter, and that parameter must match the type of every node");
        }
        
    }
}