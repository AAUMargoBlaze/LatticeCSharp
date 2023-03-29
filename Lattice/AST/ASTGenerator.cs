namespace Lattice.AST
{
    public class ASTGenerator : LatticeBaseVisitor<object>
    {

        public override object VisitStatements(LatticeParser.StatementsContext context)
        {
            // Statements.Add(new Statement(context.GetText()));
            // Console.WriteLine(context.GetText());
            return VisitChildren(context);
        }

        public override object VisitVardecl(LatticeParser.VardeclContext context)
        {
            // Console.WriteLine(context.type().GetText());
            // Console.WriteLine(context.ID());
            // Console.WriteLine(context.vardecltail().tailvarassign().assignval().GetText());
            // var assign = AssignmentNode(context.type(), context.vardecltail());
            // LatticeParser.VardecltailContext children = (LatticeParser.VardecltailContext)VisitChildren(context);
            // var assigntype = new TypeNode(context.type());
            // var assignNode = new AssignmentNode(TypeNode);
            
            return VisitChildren(context);
        }

        public override LatticeParser.VardecltailContext VisitVardecltail(LatticeParser.VardecltailContext context)
        {
            return context;
        }
    }
}