namespace CalistoStandards.Definitions.Structures.Cls;

public readonly struct CampusTarget : IEquatable<CampusTarget>, IEquatable<ClCampus>, IEquatable<string>
{
    public readonly ClCampus Source;
    public readonly Uri CampusUri;

    public string SourceStr => Source switch
    {
        ClCampus.U3F => nameof(ClCampus.U3F),
        ClCampus.ULP => nameof(ClCampus.ULP),
        ClCampus.U3P => nameof(ClCampus.U3P),
        _ => string.Empty
    };

    public string SourceName => Source switch
    {
        ClCampus.U3F => ClConsts.ClCampus.ClCampusU3F,
        ClCampus.ULP => ClConsts.ClCampus.ClCampusULP,
        ClCampus.U3P => ClConsts.ClCampus.ClCampusU3P,
        _                                                          => string.Empty
    };

    public CampusTarget(in ClCampus cSource, in string campusUrl)
    {
        CampusUri = new Uri(campusUrl); 
        Source = cSource;
    }

    public override string ToString() => SourceName;

    #region Equality

    public override int GetHashCode() => Source.GetHashCode();

    public override bool Equals(object? obj) => obj is CampusTarget other && Equals(other.Source);

    public bool Equals(CampusTarget other) => other.Source.Equals(Source);

    public bool Equals(ClCampus other) => Source.Equals(other);

    public bool Equals(string? other)
    {
        if (string.IsNullOrWhiteSpace(other)) return false;

        return other is {Length: 3} str &&
               str.Equals(SourceStr, StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool operator ==(CampusTarget left, CampusTarget right) => left.Equals(right);

    public static bool operator !=(CampusTarget left, CampusTarget right) => !(left == right);

    public static bool operator ==(ClCampus left, CampusTarget right) => left.Equals(right.Source);

    public static bool operator !=(ClCampus left, CampusTarget right) => !(left == right);

    public static bool operator ==(string left, CampusTarget right) => right.Equals(left);

    public static bool operator !=(string left, CampusTarget right) => !(left == right);

    #endregion
}