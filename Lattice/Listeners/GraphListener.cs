using Lattice.CommonElements;
using Lattice.CommonElements.Expressions;
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
        var graphContext = ListenerHelper.SharedListenerStack.Peek();
        if (graphContext.EvaluationType == LatticeType.Graph && graphContext.ToString() == id)
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
            ListenerHelper.SharedListenerStack.Push(new LatticeExpression(currentGraphContext.Name, LatticeType.Graph));
        }
        else if (granny is LatticeParser.VarassignorgraphmaniporaddrelContext)
        {
            var id = ((LatticeParser.VarassignorgraphmaniporaddrelContext)granny).ID().GetText();
            ContextManager.EnterSubContext(id);
        }
    }

    public override void ExitTailgraphmanip(LatticeParser.TailgraphmanipContext context)
    {
        ContextManager.ExitSubContext();
    }

    public override void ExitAddref(LatticeParser.AddrefContext context)
    {
        var currentGraphContext = ContextManager.GetCurrentGraphContext();
        var id = context.ID().GetText();
        var ltVar = currentGraphContext.GetVariable(id);


        var node = new Node(id, ltVar.Type);
        node.SetValue(new LatticeExpression(ltVar.Value, ltVar.Type));
            
        currentGraphContext.DeclareNode(id, node);
        
        GlobalFileManager.Write($"{currentGraphContext.Name}.add_nodes({id}=Node({node.Value}))");
        GlobalFileManager.Write(Program.NewLine);
    }

    public override void ExitAddclone(LatticeParser.AddcloneContext context)
    {
        var currentGraphContext = ContextManager.GetCurrentGraphContext();
        var id = context.ID().GetText();
        var oldNode = currentGraphContext.GetNode(id);
        
        var newNode = (Node)oldNode.Clone();
        currentGraphContext.DeclareNode(newNode.Id, newNode);
        
        GlobalFileManager.Write($"{newNode.Id} = {oldNode.Id}.copy() {Program.NewLine}");
        GlobalFileManager.Write($"{currentGraphContext}.add_nodes({newNode.Id} = {newNode.Id}) {Program.NewLine}");
    }

    public override void ExitTailaddrel(LatticeParser.TailaddrelContext context)
    {
        var parentContext = (LatticeParser.VarassignorgraphmaniporaddrelContext)context.Parent;
        var ids = context.ID();
        var currentGraph = ContextManager.GetCurrentGraphContext();

        var predecessor = currentGraph.GetNode(parentContext.ID().GetText());
        GlobalFileManager.Write($"{currentGraph.Name}.get_node('{predecessor.Id}').add_edge(");
        
        var cost = Convert.ToInt32(context.number().GetText());
        var label = context.STRING().GetText().Replace("\"", string.Empty);
        GlobalFileManager.Write($"Edge(\"{label}\"), ");
        
        var successor = currentGraph.GetNode(context.ID().GetText());
        GlobalFileManager.Write($"{currentGraph.Name}.get_node('{successor.Id}')");

        var relationship = new DirectedRelationship(predecessor, successor)
        {
            Cost = cost,
            Label = label
        };
        ContextManager.GetCurrentGraphContext().DeclareRelationship(relationship);

        GlobalFileManager.Write($") {Program.NewLine}");
    }

    private void OpenNewContext(string id)
    {
        var newContext = new GraphContext(id);
        ContextManager.OpenNewSubContext(newContext);
        GlobalFileManager.Write($"{id} = Graph() {Program.NewLine}");
    }
}