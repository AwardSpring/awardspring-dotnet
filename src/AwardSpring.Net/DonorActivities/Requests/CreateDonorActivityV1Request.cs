using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record CreateDonorActivityV1Request
{
    /// <summary>
    /// The stored ID of the donor (or donor organization) to attach the activity to.
    /// </summary>
    [JsonIgnore]
    public required string DonorId { get; set; }

    /// <summary>
    /// The kind of activity being logged. Supported values:
    /// <list type="bullet"><item><description>`LoggedEmail` — an email exchanged with the donor (manually logged after the fact). Example: `"LoggedEmail"`.</description></item><item><description>`LoggedPhone` — a phone conversation with the donor. Example: `"LoggedPhone"`.</description></item><item><description>`LoggedMeeting` — an in-person or virtual meeting. Example: `"LoggedMeeting"`.</description></item><item><description>`LoggedNote` — a free-form note attached to the donor record. Example: `"LoggedNote"`.</description></item><item><description>`LoggedPledge` — a recorded pledge of a future gift; requires Amount. Example: `"LoggedPledge"`.</description></item></list>
    /// Gifts (`LoggedGift`) are not supported by this endpoint — they are recorded through a separate gift-entry flow.
    /// </summary>
    [JsonPropertyName("activity_type")]
    public CreateDonorActivityV1RequestActivityType? ActivityType { get; set; }

    /// <summary>
    /// ISO 8601 date or date-time the activity occurred (or is scheduled for, when in the future). A full
    /// date is required — examples: `"2026-04-03"`, `"2026-04-03T10:00:00Z"`, `"2026-04-03T10:00:00-05:00"`.
    /// Time-of-day is optional. The date is interpreted in the tenant's configured time zone and persisted in UTC.
    /// </summary>
    [JsonPropertyName("activity_date")]
    public string? ActivityDate { get; set; }

    /// <summary>
    /// Short human-readable title for the activity. Required, non-whitespace. Example: `"Quarterly stewardship call"`.
    /// Surfaced in donor activity lists in the AwardSpring admin UI.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Optional free-form details about the activity. Example: `"Discussed plans for the spring scholarship gala; donor expressed interest in funding a new STEM award."`.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Monetary amount for pledge activities. Required and greater than zero when
    /// `activity_type` is `LoggedPledge`; ignored for non-monetary activity
    /// types. Example: `5000.00`.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// Optional fund identifier the pledge is directed toward. Only meaningful when ActivityType
    /// is `LoggedPledge`. When the tenant has Funds Management enabled, the value must match an existing
    /// fund's `FundIdName`; otherwise a `fund_not_found` error is returned. When Funds Management
    /// is disabled, the value is stored as a free-form label without validation. Example: `"GEN-2026"`.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// Optional stored ID of a campaign at this institution, for pledge activities. Only meaningful when
    /// ActivityType is `LoggedPledge`; ignored for non-monetary activity types.
    /// Example: `"7HQ2KW9XR"`.
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// Optional stored ID of the staff member the activity is assigned to (e.g., the donor manager who should
    /// follow up). Pass `null` or omit when no assignment is intended. Example: `"4MZ8RT2PW"`.
    /// </summary>
    [JsonPropertyName("assigned_to_user_id")]
    public string? AssignedToUserId { get; set; }

    /// <summary>
    /// Whether the activity is completed. For non-monetary activity types this is ignored (treated as `false`).
    /// For `LoggedPledge`, `true` indicates the pledge has been fulfilled. Defaults to `false`.
    /// </summary>
    [JsonPropertyName("is_completed")]
    public bool? IsCompleted { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
