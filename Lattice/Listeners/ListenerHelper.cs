using Lattice.CommonElements.Expressions;

namespace Lattice.Listeners;

public static class ListenerHelper
{
    public static readonly Stack<LatticeExpression>  SharedListenerStack = new ();
    public static readonly Queue<string> LexerInterjects = new();
}