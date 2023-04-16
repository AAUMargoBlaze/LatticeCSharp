namespace Lattice.Listeners;

public static class ListenerHelper
{
    public static readonly Stack<(object value, Type type)>  SharedListenerStack = new ();
}