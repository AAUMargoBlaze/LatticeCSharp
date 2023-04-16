using Lattice.CommonElements;

namespace Lattice.Listeners;

public class GraphListener : LatticeBaseListener
{
    public override void ExitVardecl(LatticeParser.VardeclContext context)
    {
        var type = LatticeTypeHelper.StringToLatticeType(context.type().GetText());
        if (type != LatticeType.Graph) return;
        
        var id = context.ID().GetText();
        ContextManager.OpenNewSubContext(id);
        GlobalFileManager.Write($"{id} = Graph()");
    }
}