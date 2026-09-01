using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// An award cycle — the institution's scholarship season, for example "2025-2026". Carries
/// `"object": "award_cycle"`. The same shape is returned both as a list item from
/// `GET /api/v1/award-cycles` and on its own from `GET /api/v1/award-cycles/current`.
/// </summary>
[Serializable]
public record AwardCycleV1 : IJsonOnDeserialized
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
    /// AwardSpring award-cycle identifier — also the cursor anchor for paging.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    /// <summary>
    /// Award-cycle name as configured by the institution (e.g. "2025-2026").
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// True when this is the cycle the institution has marked current.
    /// </summary>
    [JsonPropertyName("is_current")]
    public bool? IsCurrent { get; set; }

    /// <summary>
    /// True when this is the cycle the institution has marked next/upcoming.
    /// </summary>
    [JsonPropertyName("is_next")]
    public bool? IsNext { get; set; }

    /// <summary>
    /// When the cycle's application window opens (UTC epoch seconds), or null when unset.
    /// </summary>
    [JsonPropertyName("application_start_date")]
    public int? ApplicationStartDate { get; set; }

    /// <summary>
    /// When the cycle's application window closes (UTC epoch seconds), or null when unset.
    /// </summary>
    [JsonPropertyName("application_end_date")]
    public int? ApplicationEndDate { get; set; }

    /// <summary>
    /// When the cycle's review window opens (UTC epoch seconds), or null when unset.
    /// </summary>
    [JsonPropertyName("review_start_date")]
    public int? ReviewStartDate { get; set; }

    /// <summary>
    /// When the cycle's review window closes (UTC epoch seconds), or null when unset.
    /// </summary>
    [JsonPropertyName("review_end_date")]
    public int? ReviewEndDate { get; set; }

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
