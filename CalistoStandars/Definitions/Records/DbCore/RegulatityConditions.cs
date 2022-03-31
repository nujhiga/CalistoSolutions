namespace CalistoStandars.Definitions.Records.DbCore;

public abstract record RegularityCondition(string Regular, string Curing);
public sealed record DisableCond() : RegularityCondition("B", string.Empty);
public sealed record LicenceCond() : RegularityCondition("L", string.Empty);
public sealed record RegularCond() : RegularityCondition("R", string.Empty);
public sealed record IngressCond() : RegularityCondition("I", "T");
