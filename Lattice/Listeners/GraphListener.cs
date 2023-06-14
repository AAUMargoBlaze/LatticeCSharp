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
            try
            {
                OpenNewContext(id);
                var currentGraphContext = ContextManager.GetCurrentContext();
                ListenerHelper.SharedListenerStack.Push(new LatticeExpression(currentGraphContext.Name, LatticeType.Graph));
            }
            catch (ArgumentException e)
            {
                var reopened = ContextManager.ResetGraphContext(id);
                ContextManager.EnterSubContext(reopened.Name);
                GlobalFileManager.Write($"{reopened.Name} = Graph() {Program.NewLine}");
                ListenerHelper.SharedListenerStack.Push(new LatticeExpression(reopened.Name, LatticeType.Graph));
            }
           
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
        var id = context.ID().First().GetText();
        var asId = 1 < context.ID().Length ? context.ID()[1].GetText() : null;
        Node oldNode;
        
        //as you can tell, I gave up code cleanliness about here
        try
        {
            try
            {
                oldNode = currentGraphContext.GetNode(id);
                var newNode = (Node)oldNode.Clone();
                currentGraphContext.DeclareNode(asId ?? newNode.Id, newNode);
                GlobalFileManager.Write($"name, node = clone({asId ?? oldNode.Id},'{currentGraphContext.Name}'){Program.NewLine}");
                GlobalFileManager.Write("kwargs = {name: node}"+Program.NewLine);
                GlobalFileManager.Write($"{currentGraphContext.Name}.add_nodes(**kwargs) {Program.NewLine}");

            }
            catch (Exception e)
            {
                var cloneVar = (LatticeVariable)currentGraphContext.GetVariable(id).Clone();
                var node = new Node(asId ?? cloneVar.Id, cloneVar.Type, cloneVar.PythonId);
                currentGraphContext.DeclareNode(asId ?? node.Id, node);
                GlobalFileManager.Write($"{asId} = uuid.uuid4() {Program.NewLine}");
                GlobalFileManager.Write($"{currentGraphContext.Name}." +
                                        $"add_nodes(**{{str({asId ?? cloneVar.Id}): " +
                                        $"Node({cloneVar.Id}" + 
                                        $")}}){Program.NewLine}");
            }
        }
        catch (Exception e)
        {
            var graphToBeCloned = (GraphContext)ContextManager.GetContext(id);
            var parentVars = graphToBeCloned.ReturnAllDeclaredVariables();
            
            foreach (var kvp in parentVars)
            {
                try
                {
                    currentGraphContext.DeclareVariable(kvp.Key, kvp.Value);
                }
                catch(Exception _) {}
            }
            
            
            var parentContexts = graphToBeCloned.ReturnAllDeclaredGraphs();

            foreach (var kvp in parentContexts)
            {
                try
                {
                    currentGraphContext.DeclareContext(kvp.Key, kvp.Value);
                }
                catch(Exception _) {}
            }
            
            
            var parentNodes = graphToBeCloned.ReturnAllDeclaredNodes();

            foreach (var kvp in parentNodes)
            {
                try
                {
                    currentGraphContext.DeclareNode(kvp.Key, kvp.Value);
                }
                catch(Exception _) {}
            }
            
            GlobalFileManager.Write($"{graphToBeCloned.Name}.deepcopy({currentGraphContext.Name}) {Program.NewLine}");
        }
        
    }

    public override void ExitTailaddrel(LatticeParser.TailaddrelContext context)
    {
        var parentContext = (LatticeParser.VarassignorgraphmaniporaddrelContext)context.Parent;
        var ids = context.ID();
        var currentGraph = ContextManager.GetCurrentGraphContext();

        Node predecessor = null;
        try
        {
            predecessor = currentGraph.GetNode(parentContext.ID().GetText());
            // GlobalFileManager.Write($"(get_node_from_list('{predecessor.Id}', '{currentGraph.Name}') or {currentGraph.Name}.get_node('{predecessor.Id}')).add_edge(");
            GlobalFileManager.Write($"{currentGraph.Name}.get_node(str({predecessor.Id})).add_edge(");
        }
        catch (Exception e)
        {
            var variable = currentGraph.GetVariable(parentContext.ID().GetText());
            predecessor = new Node(variable.Id, variable.Type);
            GlobalFileManager.Write($"(get_node_from_list('{variable.Id}', '{currentGraph.Name}') or {variable.Id}).add_edge(");
        }

        
        var cost = Convert.ToInt32(context.number().GetText());
        var label = context.STRING().GetText().Replace("\"", string.Empty);
        GlobalFileManager.Write($"Edge(\"{label}\"), ");

        Node successor = null;
        try
        {
            successor = currentGraph.GetNode(context.ID().GetText());
        }
        catch (Exception e)
        {
            var variable = currentGraph.GetVariable(context.ID().GetText());
            successor = new Node(variable.Id, variable.Type);
            GlobalFileManager.Write($"{variable.Id})");
            var rel = new DirectedRelationship(predecessor, successor)
            {
                Cost = cost,
                Label = label
            };
            ContextManager.GetCurrentGraphContext().DeclareRelationship(rel);
            GlobalFileManager.Write($"{Program.NewLine}");
            return;
        }

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