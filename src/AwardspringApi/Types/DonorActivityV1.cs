using AwardspringApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

/// <summary>
/// A single item on a donor's merged activity timeline. Fields a given source doesn't populate are
/// null/default; (Source, Id) is the item's identity since Id
/// is unique only within a source.
/// </summary>
[Serializable]
public record DonorActivityV1 : IJsonOnDeserialized
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
    /// Source-local identifier. Unique only within Source, not across the timeline.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("source")]
    public int? Source { get; set; }

    /// <summary>
    /// Activity type label (e.g. `"LoggedEmail"`, `"Email"`, `"Sms"`, `"Award"`, `"GeneralApplication"`).
    /// </summary>
    [JsonPropertyName("activity_type")]
    public string? ActivityType { get; set; }

    /// <summary>
    /// Short human-readable title for the item.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Free-form detail (populated only for logged activities and SMS; null otherwise).
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// When the activity occurred, in the tenant's local time zone (UTC epoch seconds on the wire).
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    /// <summary>
    /// Monetary amount (logged monetary activities and awards); null otherwise.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// Fund the pledge/gift was directed toward (logged activities only); null otherwise.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// Completion flag (logged monetary activities); false otherwise.
    /// </summary>
    [JsonPropertyName("is_completed")]
    public bool? IsCompleted { get; set; }

    /// <summary>
    /// Whether a gift acknowledgement was sent (logged gifts); false otherwise.
    /// </summary>
    [JsonPropertyName("gift_acknowledgement_sent")]
    public bool? GiftAcknowledgementSent { get; set; }

    /// <summary>
    /// Gift type label (logged activities); null otherwise.
    /// </summary>
    [JsonPropertyName("gift_type")]
    public string? GiftType { get; set; }

    /// <summary>
    /// Campaign association (logged monetary activities); null otherwise.
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public int? CampaignId { get; set; }

    /// <summary>
    /// Staff member the activity is assigned to (logged activities); null otherwise.
    /// </summary>
    [JsonPropertyName("assigned_to_user_id")]
    public int? AssignedToUserId { get; set; }

    /// <summary>
    /// Sender display name (system emails only); null otherwise.
    /// </summary>
    [JsonPropertyName("sender_name")]
    public string? SenderName { get; set; }

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
