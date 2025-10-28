using System.Reflection;
using Xunit.Sdk;
using Xunit.v3;

namespace XUnit3Helper.Impl
{
    public sealed class JsonFileDataAttribute
        : DataAttribute
    {
        public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(
            MethodInfo testMethod,
            DisposalTracker disposalTracker)
        {
            throw new NotImplementedException();
        }

        public override bool SupportsDiscoveryEnumeration()
        {
            throw new NotImplementedException();
        }
    }
}
