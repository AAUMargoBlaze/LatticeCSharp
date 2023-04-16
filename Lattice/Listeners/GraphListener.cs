namespace Lattice.Listeners;

public class GraphListener : LatticeBaseListener
{
    public override void ExitGraphdecl(LatticeParser.GraphdeclContext context)
    {
        var id = context.ID().GetText();
        ContextManager.OpenNewSubContext(id);
        GlobalFileManager.Write($"{id} = Graph()");
        base.ExitGraphdecl(context);
    }
}