using System.Text.Json.Serialization;

namespace Client.Contract;

public record RocketDTO
{
    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("stages")]
    public long Stages { get; set; }

    [JsonPropertyName("success_rate_pct")]
    public long SuccessRatePct { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}
