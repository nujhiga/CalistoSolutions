namespace CalistoDbCore.Services.Builders.Interfaces;

public interface IAcademicEntityBuilder<TBuild, TCommon, TSource> : IDisposable
{
    TCommon?                   CommonValue { get; }
    public IEnumerable<TBuild> Build(in         IEnumerable<TSource> source);
    public IEnumerable<TBuild> ParallelBuild(in IEnumerable<TSource> source);
}