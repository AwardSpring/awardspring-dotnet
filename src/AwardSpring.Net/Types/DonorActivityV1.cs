using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// A single item on a donor's merged activity timeline. Fields a given source doesn't populate are
/// null/default.
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
    /// The stored ID of the row the item came from (a logged activity, an email, a text message, an award
    /// or a general application). Only a logged activity's ID opens the item on its own.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The stored ID of the donor the activity is with: the same value `donor_id` takes when an
    /// activity is created, and the `id` the donor has on the donor list.
    /// </summary>
    [JsonPropertyName("donor_id")]
    public string? DonorId { get; set; }

    /// <summary>
    /// The donor's name as the donor list shows it: an organization's name for an organization,
    /// otherwise the donor's first and last name. Shown for an archived donor too. Null when the
    /// request is made as a signed-in user whose Donors permission is No access, or when the donor's
    /// record has no name.
    /// </summary>
    [JsonPropertyName("donor_name")]
    public string? DonorName { get; set; }

    [JsonPropertyName("source")]
    public DonorActivitySourceV1? Source { get; set; }

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
    public int? Date { get; set; }

    /// <summary>
    /// Where the meeting or call takes place: a room, an address or a call link (logged activities only).
    /// Null when no place was given, which includes every activity logged on the website; null for
    /// emails, text messages, awards and applications.
    /// </summary>
    [JsonPropertyName("place")]
    public string? Place { get; set; }

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
    /// The stored ID of the campaign (logged monetary activities); null otherwise.
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// The stored ID of the staff member the activity is assigned to (logged activities); null otherwise.
    /// </summary>
    [JsonPropertyName("assigned_to_user_id")]
    public string? AssignedToUserId { get; set; }

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
