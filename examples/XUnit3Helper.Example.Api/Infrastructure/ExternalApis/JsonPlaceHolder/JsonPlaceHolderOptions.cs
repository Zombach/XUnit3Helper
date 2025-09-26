using System.ComponentModel.DataAnnotations;

namespace XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;

internal sealed class JsonPlaceHolderOptions
{
    public const string SectionKey = nameof(JsonPlaceHolderOptions);

    [Required]
    public required string BaseUrl { get; init; }
}
