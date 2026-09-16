using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One scholarship award granted to one student within an award cycle.
/// </summary>
[Serializable]
public record AwardV1 : IJsonOnDeserialized
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
    /// Award identifier — also the cursor anchor for the list.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    /// <summary>
    /// The recipient's user record id — the same value as the student resource's `id` (see the Students endpoints).
    /// </summary>
    [JsonPropertyName("user_id")]
    public int? UserId { get; set; }

    /// <summary>
    /// Identifier of the awarded scholarship (see the Scholarships endpoints).
    /// </summary>
    [JsonPropertyName("scholarship_id")]
    public int? ScholarshipId { get; set; }

    /// <summary>
    /// Name of the awarded scholarship, denormalized onto the row for convenience.
    /// </summary>
    [JsonPropertyName("scholarship_name")]
    public string? ScholarshipName { get; set; }

    /// <summary>
    /// Identifier of the award cycle the award belongs to (see the Award Cycles endpoints).
    /// </summary>
    [JsonPropertyName("award_cycle_id")]
    public int? AwardCycleId { get; set; }

    /// <summary>
    /// Name of the award cycle the award belongs to, denormalized onto the row for convenience.
    /// </summary>
    [JsonPropertyName("award_cycle_name")]
    public string? AwardCycleName { get; set; }

    /// <summary>
    /// When the award decision was made, as UTC epoch seconds. Null when no decision date was recorded.
    /// </summary>
    [JsonPropertyName("awarded_date")]
    public int? AwardedDate { get; set; }

    /// <summary>
    /// Awarded dollar amount, rounded to two decimal places.
    /// </summary>
    [JsonPropertyName("awarded_amount")]
    public double? AwardedAmount { get; set; }

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
