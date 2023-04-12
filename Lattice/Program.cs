using Antlr4.Runtime;
using Lattice.AST;

namespace Lattice
{
    public class Program
    {
        public static void Main()
        {
            using Stream stream = new FileStream("testfile", FileMode.Open);
            var inputStream = new AntlrInputStream(stream);
            var latticeLexer = new LatticeLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(latticeLexer);
            var latticeParser = new LatticeParser(commonTokenStream);

            
            
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