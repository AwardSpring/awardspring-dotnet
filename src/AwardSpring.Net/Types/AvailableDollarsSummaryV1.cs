using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// The available dollars of a whole award cycle: the budget, awarded and remaining amounts of every active
/// scholarship in the cycle added together: the same scholarships and amounts the per-scholarship
/// available-dollars list reports for the cycle.
/// </summary>
[Serializable]
public record AvailableDollarsSummaryV1 : IJsonOnDeserialized
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
    /// The award cycle's stored ID.
    /// </summary>
    [JsonPropertyName("award_cycle_id")]
    public string? AwardCycleId { get; set; }

    /// <summary>
    /// How many active scholarships the totals cover.
    /// </summary>
    [JsonPropertyName("scholarship_count")]
    public int? ScholarshipCount { get; set; }

    /// <summary>
    /// The scholarships' budgets added together, rounded to 2 decimals.
    /// </summary>
    [JsonPropertyName("total_funds")]
    public double? TotalFunds { get; set; }

    /// <summary>
    /// Everything awarded from the scholarships, added together, rounded to 2 decimals.
    /// </summary>
    [JsonPropertyName("total_awarded_amount")]
    public double? TotalAwardedAmount { get; set; }

    /// <summary>
    /// The money left across the cycle: `total_funds` less `total_awarded_amount`. An over-awarded
    /// scholarship counts against it, so its overage is already subtracted. Negative when the cycle as a
    /// whole has awarded more than its budgets hold.
    /// </summary>
    [JsonPropertyName("total_amount_remaining")]
    public double? TotalAmountRemaining { get; set; }

    /// <summary>
    /// How many of the scholarships have awarded more than their budget (a negative
    /// `total_amount_remaining` on the per-scholarship list). They are included in every total above.
    /// </summary>
    [JsonPropertyName("over_awarded_scholarship_count")]
    public int? OverAwardedScholarshipCount { get; set; }

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
