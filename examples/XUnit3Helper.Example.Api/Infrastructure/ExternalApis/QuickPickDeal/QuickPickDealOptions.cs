using System.ComponentModel.DataAnnotations;

namespace XUnit3Helper.Example.Api.Infrastructure.ExternalApis.QuickPickDeal;

internal sealed class QuickPickDealOptions
{
    public const string SectionKey = nameof(QuickPickDealOptions);

    [Required]
    public required string BaseUrl { get; init; }
}
