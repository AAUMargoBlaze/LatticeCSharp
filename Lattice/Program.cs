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
            
            using Stream stream = new FileStream(sourceFile, FileMode.Open);
            var inputStream = new AntlrInputStream(stream);
            var latticeLexer = new LatticeLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(latticeLexer);
            var latticeParser = new LatticeParser(commonTokenStream);


            GlobalFileManager.Initialize(outFile);
            
            latticeParser.AddParseListener(new VariableListener());
            latticeParser.AddParseListener(new StdLibListener());
            latticeParser.AddParseListener(new GraphListener());
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