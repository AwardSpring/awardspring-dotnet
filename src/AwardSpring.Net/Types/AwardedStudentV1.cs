using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One applicant's award of one scholarship within an award cycle (one flattened row per award).
/// </summary>
[Serializable]
public record AwardedStudentV1 : IJsonOnDeserialized
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
    /// Award row identifier (the underlying OpportunityApplication id) — also the cursor anchor for the list.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("scholarship_id")]
    public int? ScholarshipId { get; set; }

    [JsonPropertyName("scholarship_name")]
    public string? ScholarshipName { get; set; }

    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    [JsonPropertyName("student_id")]
    public string? StudentId { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("awarded_date")]
    public int? AwardedDate { get; set; }

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
