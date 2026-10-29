using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record GiftV1 : IJsonOnDeserialized
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
    /// The gift's or pledge's stored ID: 9 characters, sent exactly as stored. A dry-run create
    /// returns `null`, because nothing was saved.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The stored ID of the donor the gift or pledge is attributed to.
    /// </summary>
    [JsonPropertyName("donor_id")]
    public string? DonorId { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("gift_type")]
    public string? GiftType { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The school's own code for the fund the gift is directed toward, as plain text.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// The stored ID of the campaign the gift or pledge belongs to, or `null`.
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    [JsonPropertyName("is_completed")]
    public bool? IsCompleted { get; set; }

    [JsonPropertyName("gift_acknowledgement_sent")]
    public bool? GiftAcknowledgementSent { get; set; }

    [JsonPropertyName("date")]
    public int? Date { get; set; }

    [JsonPropertyName("soft_credits")]
    public IEnumerable<SoftCreditV1>? SoftCredits { get; set; }

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
