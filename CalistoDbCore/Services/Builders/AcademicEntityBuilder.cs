using CalistoDbCore.Services.Builders.Interfaces;

namespace CalistoDbCore.Services.Builders;

public abstract class AcademicEntityBuilder<TBuild, TCommon, TSource> : IAcademicEntityBuilder<TBuild, TCommon, TSource>
{
    public TCommon? CommonValue { get; protected set; }

    protected AcademicEntityBuilder(TCommon commonValue) => CommonValue = commonValue;

    public abstract IEnumerable<TBuild> Build(in IEnumerable<TSource> source);

    public virtual IEnumerable<TBuild> ParallelBuild(in IEnumerable<TSource> source) => Build(in source);


    public virtual void Dispose()
    {
        if (CommonValue is not { }) return;

        if (!typeof(TCommon).GetInterfaces().Contains(typeof(IDisposable))) return;

        if (CommonValue is IDisposable disposable)
            disposable.Dispose();
    }
}