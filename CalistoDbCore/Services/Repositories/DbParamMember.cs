namespace CalistoDbCore.Services.Repositories;



public sealed record DbParamMember<TMember>(TMember? Member, Type MemberType) 
{
    public bool HasValue => Member is { };
    public bool IsArray => HasValue && Member is TMember[] {Length: > 1};

}
