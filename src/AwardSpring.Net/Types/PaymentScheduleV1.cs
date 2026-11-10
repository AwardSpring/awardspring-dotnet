using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// A payment schedule — one dated payment an institution configures and attaches to award cycles.
/// Carries `"object": "payment_schedule"`. A scholarship with two or more payments per award names
/// one of its award cycle's schedules for each payment after the first, in `payment_schedule_ids`.
/// </summary>
[Serializable]
public record PaymentScheduleV1 : IJsonOnDeserialized
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
    /// The payment schedule's stored ID: 9 characters, capital letters and numbers. Pass it in a scholarship's
    /// `payment_schedule_ids`. Example: `"7HN4KX2RB"`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Payment schedule name as configured by the institution (e.g. "Spring payment").
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// When this payment is made (UTC epoch seconds), or null when unset.
    /// </summary>
    [JsonPropertyName("payment_date")]
    public int? PaymentDate { get; set; }

    /// <summary>
    /// The stored IDs of the award cycles this schedule is configured on. A schedule can be configured on
    /// more than one cycle. Example: `["4MZ8QW2TC"]`.
    /// </summary>
    [JsonPropertyName("award_cycle_ids")]
    public IEnumerable<string>? AwardCycleIds { get; set; }

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
