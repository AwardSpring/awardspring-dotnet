using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One scholarship as returned by `GET /api/v1/scholarships/{scholarshipId}`. Carries
/// `"object": "scholarship"`. Every field the scholarship list shows keeps its list name and value.
/// </summary>
[Serializable]
public record ScholarshipV1 : IJsonOnDeserialized
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
    /// The scholarship's stored ID. Example: `"7HQ2KW9XR"`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Scholarship name as configured by the institution.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Total budgeted award value for the scholarship, or null when unset.
    /// </summary>
    [JsonPropertyName("total_amount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// True when the scholarship is active (visible/awardable); false when deactivated.
    /// </summary>
    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// The stored ID of the award cycle the scholarship belongs to.
    /// </summary>
    [JsonPropertyName("award_cycle_id")]
    public string? AwardCycleId { get; set; }

    /// <summary>
    /// When the scholarship's application window opens (UTC epoch seconds).
    /// </summary>
    [JsonPropertyName("application_start_date")]
    public int? ApplicationStartDate { get; set; }

    /// <summary>
    /// When the scholarship's application window closes (UTC epoch seconds).
    /// </summary>
    [JsonPropertyName("application_end_date")]
    public int? ApplicationEndDate { get; set; }

    /// <summary>
    /// The stored ID of the scholarship's department, or null when it has none.
    /// </summary>
    [JsonPropertyName("department_id")]
    public string? DepartmentId { get; set; }

    /// <summary>
    /// The scholarship's fund code, or null when it has none. This is the same code the create call takes.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// The stored IDs of the donors linked to the scholarship. Empty when there are none.
    /// </summary>
    [JsonPropertyName("donor_ids")]
    public IEnumerable<string>? DonorIds { get; set; }

    /// <summary>
    /// The scholarship's description, as stored. Empty when there is none.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("award_notification")]
    public ScholarshipAwardNotificationV1? AwardNotification { get; set; }

    /// <summary>
    /// Every custom field the scholarship's Details tab shows, in the tab's order, each with this scholarship's value.
    /// A field with no value is listed with an empty value. A field that has not been given a stored ID yet is left
    /// out.
    /// </summary>
    [JsonPropertyName("custom_fields")]
    public IEnumerable<ScholarshipCustomFieldV1>? CustomFields { get; set; }

    /// <summary>
    /// The scholarship's qualifications, in the Qualifications tab's groups and order. A student qualifies by
    /// meeting every rule in at least one group: rules inside a group are all required, and the groups are
    /// alternatives. Empty when the scholarship has no qualifications. Every `question` rule carries its
    /// question's stored ID.
    /// </summary>
    [JsonPropertyName("qualification_groups")]
    public IEnumerable<ScholarshipQualificationGroupV1>? QualificationGroups { get; set; }

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
