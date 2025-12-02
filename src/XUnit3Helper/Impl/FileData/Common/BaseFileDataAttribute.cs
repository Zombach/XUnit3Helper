using System.Reflection;
using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;

namespace XUnit3Helper.Impl.FileData.Common;

public abstract class BaseFileDataAttribute(
    string filePath)
    : DataAttribute
{
    protected virtual Type[] GetParameters(MethodInfo testMethod)
    {
        var parameterInfos = testMethod.GetParameters();
        var parameterTypes = parameterInfos.Select(x => x.ParameterType)
            .ToArray();

        return parameterTypes;
    }

    protected virtual void CheckParameters(Type[] parameterTypes)
    {
        if (parameterTypes.Length is 0)
        {
            throw new ArgumentException($"parameterTypes should be > 0: {parameterTypes}");
        }
    }

    protected virtual string GetPath(string path)
    {
        return !Path.IsPathRooted(path)
            ? Path.GetRelativePath(Directory.GetCurrentDirectory(), path)
            : path;
    }

    protected abstract ValueTask<IEnumerable<string>> GetSource(string path);

    protected abstract IEnumerable<ITheoryDataRow> GetTeoryDataRow(
        IEnumerable<string> source,
        Type[] parameterTypes);

    public override async ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(
        MethodInfo testMethod,
        DisposalTracker disposalTracker)
    {
        ArgumentNullException.ThrowIfNull(testMethod);

        var parameterTypes = GetParameters(testMethod);
        CheckParameters(parameterTypes);

        var path = GetPath(filePath);

        var source = await GetSource(path);
        var theoryDataRows = GetTeoryDataRow(source, parameterTypes);

        return theoryDataRows.CastOrToReadOnlyCollection();
    }

    public override bool SupportsDiscoveryEnumeration() => true;
}
