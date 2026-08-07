using AwardspringApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[Serializable]
public record DonorQuickStatsV1 : IJsonOnDeserialized
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

    [JsonPropertyName("lifetime_total")]
    public double? LifetimeTotal { get; set; }

    [JsonPropertyName("lifetime_gift_count")]
    public int? LifetimeGiftCount { get; set; }

    [JsonPropertyName("year_total")]
    public double? YearTotal { get; set; }

    [JsonPropertyName("year_gift_count")]
    public int? YearGiftCount { get; set; }

    [JsonPropertyName("last_gift")]
    public double? LastGift { get; set; }

    [JsonPropertyName("last_gift_date")]
    public DateTime? LastGiftDate { get; set; }

    [JsonPropertyName("include_soft_credits")]
    public bool? IncludeSoftCredits { get; set; }

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
