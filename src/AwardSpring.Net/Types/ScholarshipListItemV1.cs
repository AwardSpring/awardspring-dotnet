using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// A scholarship as it appears in the `GET /api/v1/scholarships` list. Carries
/// `"object": "scholarship"`. This is a deliberately narrow summary shape so the list stays
/// fast — fetch a single scholarship's reporting endpoints for award and remaining-dollar detail.
/// </summary>
[Serializable]
public record ScholarshipListItemV1 : IJsonOnDeserialized
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
    /// The scholarship's identifier — also the cursor anchor used for paging.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

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
    /// The award cycle the scholarship belongs to.
    /// </summary>
    [JsonPropertyName("award_cycle_id")]
    public int? AwardCycleId { get; set; }

    /// <summary>
    /// When the scholarship's application window opens (UTC epoch seconds).
    /// </summary>
    [JsonPropertyName("application_start_date")]
    public DateTime? ApplicationStartDate { get; set; }

    /// <summary>
    /// When the scholarship's application window closes (UTC epoch seconds).
    /// </summary>
    [JsonPropertyName("application_end_date")]
    public DateTime? ApplicationEndDate { get; set; }

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
