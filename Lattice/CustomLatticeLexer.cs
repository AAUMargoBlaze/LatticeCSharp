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
            
            //write out type python code
            GlobalFileManager.Write(StripPythonTag(tokenText));
            
            return token;
        }
        else
        {
            return base.Emit();
        }
    }
    private string StripPythonTag(string input)
    {
        string[] pythonTags = { "<PYTHON>", "</PYTHON>", "🐍" , "🦅"};
        string output = input;

        foreach (string tag in pythonTags)
        {
            if (output.StartsWith(tag))
            {
                output = output.Substring(tag.Length);
                break;
            }
        }

        foreach (string tag in pythonTags.Reverse())
        {
            if (output.EndsWith(tag))
            {
                output = output.Substring(0, output.Length - tag.Length);
                break;
            }
        }

        return output;
    }
}