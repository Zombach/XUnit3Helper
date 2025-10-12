using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit3;

namespace XUnit3Helper.Impl;

public class CustomAutoDataAttribute(Func<IFixture> fixtureFactory)
    : AutoDataAttribute(() => CreateFixture(fixtureFactory()))
{
    public CustomAutoDataAttribute()
        : this(() => CreateFixture(new Fixture()))
    {
    }

    private static IFixture CreateFixture(IFixture fixture)
    {
        fixture.Customize(new CompositeCustomization(new AutoMoqCustomization { ConfigureMembers = true }));

        fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(behavior => fixture.Behaviors.Remove(behavior));

        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        return fixture;
    }
}
