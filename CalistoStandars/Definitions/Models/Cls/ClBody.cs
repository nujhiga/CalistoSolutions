namespace CalistoStandards.Definitions.Models;

public  class ClBody : IClBody
{
    public BodySign Sign { get; set; }
    public ClMessagePattern ClMessagePattern { get; set; }
    public bool IsValidBody { get; set; }
    public bool IsMassive { get; set; }
    public bool IsContainer { get; set; }


    public ClBody()
    {
       
    }

    protected ClBody(ClMessagePattern clMessagePattern)
    {
        ClMessagePattern = clMessagePattern;
    }

    protected ClBody(BodySign sign, ClMessagePattern clMessagePattern)
    {
        Sign = sign;
        ClMessagePattern = clMessagePattern;
    }

    protected ClBody(BodySign sign)
    {
        Sign = sign;
    }

    public object? Value { get; set; }
    public Enum? ComponentType { get; set; }
}