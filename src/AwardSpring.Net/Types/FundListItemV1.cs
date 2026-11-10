using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

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

    /// <summary>
    /// The fund's stored ID. The school's own fund code is `fund_id`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// The money left in the fund, in dollars, rounded to two decimal places: every deposit and gift into it, less
    /// every disbursement and decided award paid from it, over the fund's whole history.
    /// `0` when the fund has had no money in or out. Example: `1500.25`.
    /// </summary>
    [JsonPropertyName("remaining_balance")]
    public double? RemainingBalance { get; set; }

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
