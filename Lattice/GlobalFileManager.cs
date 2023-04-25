namespace Lattice;

public static class GlobalFileManager
{
    private static string? _path = null;
    private static bool _startedANewLine = false;
    private static int offsetCounter = 0;

    public static void Initialize(string filename)
    {
        try
        {
            filename = NormalizeOutFileName(filename);
            File.Create(filename).Close();
            _path = filename;
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error generating python target file: {e.Message} Defaulting to Stdout");
        }
    }

    public static void Write(string outString)
    {

        if (_startedANewLine)
        {
            outString = ApplyOffset(outString);
        }
        
        if (_path == null)
            WriteToStdout(outString);
        else
            WriteToPyFile(outString);
        
        _startedANewLine = outString.EndsWith(Program.NewLine);
    }

    public static void Indent()
    {
        offsetCounter++;
    }

    public static void Outdent()
    {
        offsetCounter--;
    }

    private static string ApplyOffset(string text)
    {
        return new string('\t', offsetCounter)+text;
    }

    private static void WriteToStdout(string outString)
    {
        Console.Write(outString);
    }

    private static void WriteToPyFile(string outString)
    {
        using var streamWriter = File.AppendText(_path!);
        streamWriter.Write(outString);
    }
    private static string NormalizeOutFileName(string filename)
    {
        return filename.EndsWith(".py") ? filename : $"{filename}.py";
    }
}