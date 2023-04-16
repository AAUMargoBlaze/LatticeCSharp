using Lattice.CommonElements;
using Lattice.CommonElements.Relationships;

namespace Lattice.Listeners;

public class GraphListener : LatticeBaseListener
{
    public override void ExitVardecl(LatticeParser.VardeclContext context)
    {
        var type = LatticeTypeHelper.StringToLatticeType(context.type().GetText());
        if (type != LatticeType.Graph) return;
        
        var id = context.ID().GetText();

        
        //Because of how enter and exit works, a context may have already been created before the exit has been reached
        //This may happen in the EnterTailgraphmanip
        //In this situation the context is put on the stack, so it's not created twice.
        var valueTuple = ListenerHelper.SharedListenerStack.Peek();
        if (valueTuple.type == typeof(Context) && ((Context)valueTuple.value).Name == id)
        {
            ListenerHelper.SharedListenerStack.Pop();
        }
        else
        {
            OpenNewContext(id);
        }
    }

    public override void EnterTailgraphmanip(LatticeParser.TailgraphmanipContext context)
    {
        //I really despise this solution, please don't judge
        var greatGranny = context.Parent.Parent.Parent;
        var granny = context.Parent.Parent;
        if (greatGranny is LatticeParser.VardeclContext)
        {
            var id = ((LatticeParser.VardeclContext)greatGranny).ID().GetText();
            OpenNewContext(id);
            
            var currentGraphContext = ContextManager.GetCurrentContext();
            ListenerHelper.SharedListenerStack.Push((currentGraphContext, typeof(Context)));
        }
        else if (granny is LatticeParser.VarassignorgraphmanipContext)
        {
            var id = ((LatticeParser.VarassignorgraphmanipContext)granny).ID().GetText();
            ContextManager.EnterSubContext(id);
        }
    }

    public override void ExitTailgraphmanip(LatticeParser.TailgraphmanipContext context)
    {
        ContextManager.ExitSubContext();
    }

    public override void ExitAddref(LatticeParser.AddrefContext context)
    {
        var currentGraphContext = ContextManager.GetCurrentContext();
        var id = context.ID().GetText();
        var ltVar = currentGraphContext.GetVariable(id);


        var node = new Node(id, ltVar.Type);
        node.Value = ltVar.Value;
            
        currentGraphContext.DeclareNode(id, node);
            
        GlobalFileManager.Write($"{currentGraphContext.Name}.add_nodes({id}=Node({node.Value}))");
        GlobalFileManager.Write(Program.NewLine);
    }

    public override void ExitAddrel(LatticeParser.AddrelContext context)
    {
        var ids = context.ID();
        var currentGraph = ContextManager.GetCurrentContext();
        GlobalFileManager.Write($"{currentGraph.Name}.add_edge(");

        var predecessor = currentGraph.GetNode(ids[0].GetText());
        GlobalFileManager.Write($"{currentGraph.Name}.get_node('{predecessor.Id}'), ");
        
        var successor = currentGraph.GetNode(ids[1].GetText());
        GlobalFileManager.Write($"{currentGraph.Name}.get_node('{successor.Id}'), ");
        
        var cost = Convert.ToInt32(context.number().GetText());
        GlobalFileManager.Write($"CEdge({cost}, ");

        
        var label = context.STRING().GetText().Replace("\"", string.Empty);
        GlobalFileManager.Write($"\"{label}\"");

        var relationship = new DirectedRelationship(predecessor, successor)
        {
            Cost = cost,
            Label = label
        };
        ContextManager.GetCurrentContext().DeclareRelationship(relationship);

        GlobalFileManager.Write($")) {Program.NewLine}");

        //graph1.add_edge(graph1.get_node('mynode'), graph1.get_node('a'), CEdge(5, "drive"))

    }

    private void OpenNewContext(string id)
    {
        ContextManager.OpenNewSubContext(id);
        GlobalFileManager.Write($"{id} = Graph() {Program.NewLine}");
    }
}