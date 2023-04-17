using Antlr4.Runtime;

namespace Lattice;

public class CustomLatticeLexer : LatticeLexer
{
    public CustomLatticeLexer(ICharStream input) : base(input)
    {
    }

    public override IToken Emit()
    {
        if (Channel == 99)
        {
            var tokenText = Text;
            Text = null; // clear the buffer
            var token = base.Emit();
            Console.WriteLine(tokenText);
            return token;
        }
        else
        {
            return base.Emit();
        }
    }
}