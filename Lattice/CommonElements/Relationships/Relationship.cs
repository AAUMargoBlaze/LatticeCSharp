namespace Lattice.CommonElements.Relationships;

public abstract class Relationship : ICloneable
{
    public string Label { get; set; }
    public double Cost { get; set; }
    
    protected Relationship()
    {
        Label = "";
        Cost = 0;
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }
}