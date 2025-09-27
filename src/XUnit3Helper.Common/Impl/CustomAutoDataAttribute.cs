using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit3;

namespace XUnit3Helper.Common.Impl;

public class CustomAutoDataAttribute(Func<IFixture> fixtureFactory)
    : AutoDataAttribute(() => CreateFixture(fixtureFactory()))
{
    /// <summary>
    /// 
    /// </summary>
    public CustomAutoDataAttribute()
        : this(() => CreateFixture(new Fixture()))
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fixture"></param>
    /// <returns></returns>
    protected static IFixture CreateFixture(IFixture fixture)
    {
        fixture.Customize(new CompositeCustomization(new AutoMoqCustomization { ConfigureMembers = true }));

        fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(behavior => fixture.Behaviors.Remove(behavior));

        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        return fixture;
    }
}
