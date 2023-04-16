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
        public static void Main()
        {
            using Stream stream = new FileStream("/Users/balazsagardi/Non-Sync Docs/repos/LatticeCSharp/Lattice/testfile.ltt", FileMode.Open);
            var inputStream = new AntlrInputStream(stream);
            var latticeLexer = new LatticeLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(latticeLexer);
            var latticeParser = new LatticeParser(commonTokenStream);


            //GlobalFileManager.Initialize("out");
            
            latticeParser.AddParseListener(new VariableListener());
            latticeParser.AddParseListener(new StdLibListener());
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