using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;

namespace XUnit3Helper.Example.Api.Tests.Infrastructure.ExternalApis.JsonPlaceHolder;

public sealed class JsonPlaceHolderOptionsTests
{
    private const string SectionKey = "JsonPlaceHolderOptions";

    [Fact]
    public void Bind_WithBaseUrl_PopulatesPropertyAndIsValid()
    {
        const string baseUrl = "https://example.com";

        // Arrange
        var data = new Dictionary<string, string?>
        {
            [$"{SectionKey}:BaseUrl"] = baseUrl
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(data)
            .Build();

        // Act
        var options = configuration.GetSection(SectionKey)
            .Get<JsonPlaceHolderOptions>();

        // Assert - property populated
        Assert.NotNull(options);
        Assert.Equal(baseUrl, options.BaseUrl);

        // Assert - data annotations valid
        var results = new List<ValidationResult>();
        var ctx = new ValidationContext(options);
        var valid = Validator.TryValidateObject(options, ctx, results, validateAllProperties: true);
        Assert.True(valid, $"Validation failed: {string.Join(", ", results)}");
    }

    [Fact]
    public void Bind_WithoutBaseUrl_ValidationFails()
    {
        // Arrange
        var data = new Dictionary<string, string?>
        {
            [$"{SectionKey}:BaseUrl"] = null
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(data)
            .Build();

        // Act
        var options = configuration.GetSection(SectionKey)
            .Get<JsonPlaceHolderOptions>();

        // Assert - validation fails for required BaseUrl
        Assert.NotNull(options);
        var results = new List<ValidationResult>();
        var ctx = new ValidationContext(options);
        var valid = Validator.TryValidateObject(options, ctx, results, validateAllProperties: true);

        Assert.False(valid);
        Assert.Contains(results, r =>
        {
            foreach (var m in r.MemberNames)
            {
                if (string.Equals(m, nameof(JsonPlaceHolderOptions.BaseUrl), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        });
    }
}
