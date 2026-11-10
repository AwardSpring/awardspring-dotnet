using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// The activity that was created, returned by `POST /api/v1/donors/{donorId}/activities`.
///
///
/// Everything needed to follow up on the new activity is returned here, so a second request is not
/// required. Fields that do not apply to the activity type you logged come back as `null`.
/// </summary>
[Serializable]
public record CreateDonorActivityV1Response : IJsonOnDeserialized
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
    /// The new activity's stored ID: 9 characters, the same ID the donor's timeline shows for it. A dry run
    /// returns `null`, because nothing was saved.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Echo of the activity type that was saved (e.g. `"LoggedEmail"`, `"LoggedPledge"`).
    /// </summary>
    [JsonPropertyName("activity_type")]
    public string? ActivityType { get; set; }

    /// <summary>
    /// Echo of the saved `Subject`.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Echo of the saved `Description` (may be `null`).
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The activity date (UTC epoch seconds on the wire).
    /// </summary>
    [JsonPropertyName("date")]
    public int? Date { get; set; }

    /// <summary>
    /// Echo of the saved place for the meeting or call, with surrounding spaces removed, or `null` when
    /// no place was given.
    /// </summary>
    [JsonPropertyName("place")]
    public string? Place { get; set; }

    /// <summary>
    /// Pledge amount, or `null` for non-monetary activity types.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// Fund identifier the pledge was directed toward, or `null` for non-monetary activity types.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// The stored ID of the campaign the pledge belongs to, or `null` for non-monetary activity types.
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// The stored ID of the staff member the activity was assigned to, or `null` when not assigned.
    /// </summary>
    [JsonPropertyName("assigned_to_user_id")]
    public string? AssignedToUserId { get; set; }

    /// <summary>
    /// Completion flag — meaningful only for `LoggedPledge`. Always `false` for non-monetary types.
    /// </summary>
    [JsonPropertyName("is_completed")]
    public bool? IsCompleted { get; set; }

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
