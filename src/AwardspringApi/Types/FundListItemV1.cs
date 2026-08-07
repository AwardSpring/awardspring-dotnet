using AwardspringApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[Serializable]
public record FundListItemV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Stripe-style resource discriminator. Stable, snake_case string naming the resource type.
    /// Serialized first so it reads as the leading field of every V1 resource body.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    [JsonPropertyName("remaining_balance")]
    public int? RemainingBalance { get; set; }

    [JsonPropertyName("fund_type")]
    public string? FundType { get; set; }

    [JsonPropertyName("is_endowed")]
    public bool? IsEndowed { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
