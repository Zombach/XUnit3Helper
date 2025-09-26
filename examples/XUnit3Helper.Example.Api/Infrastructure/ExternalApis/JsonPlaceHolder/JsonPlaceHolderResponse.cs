using System.Text.Json.Serialization;

namespace XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;

public sealed record JsonPlaceHolderResponse
{
    [JsonPropertyName(nameof(UserId))]
    public int UserId { get; set; }

    [JsonPropertyName(nameof(Id))]
    public int Id { get; set; }

    [JsonPropertyName(nameof(Title))]
    public string Title { get; set; }

    [JsonPropertyName(nameof(Body))]
    public string Body { get; set; }
}
