using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Lattice.AST;
using Lattice.CommonElements;
using Lattice.Listeners;

namespace Lattice
{
    public class Program
    {
        public static string NewLine = "\r\n";
        public static void Main(string[] args)
        {
            string sourceFile = args[0];
            string outFile = args[1];
            //GlobalFileManager.Initialize(outFile);

            string fileContents = File.ReadAllText(sourceFile);
            var inputStream = new CodePointCharStream(fileContents);
            var latticeLexer = new CustomLatticeLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(latticeLexer);
            var latticeParser = new LatticeParser(commonTokenStream);


            
            latticeParser.AddParseListener(new StdLibListener(commonTokenStream));
            latticeParser.AddParseListener(new VariableListener());
            latticeParser.AddParseListener(new GraphListener());
            latticeParser.AddParseListener(new BooleanListener());
            latticeParser.AddParseListener(new IfElseBlockListener());
            latticeParser.AddParseListener(new WhileBlockListener());
            latticeParser.AddParseListener(new ExpressionListener());
            latticeParser.start();



//            var startContext = latticeParser.start();
//            var visitor = new ASTGenerator();
//            visitor.Visit(startContext);


            // foreach (var statement in visitor.Statements)
            // {
            //     Console.WriteLine("{0}", statement.Text);
            // }
        }
    }
}