using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// The result of `POST /api/v1/scholarships` — the identifier of the scholarship just created.
/// </summary>
[Serializable]
public record CreateScholarshipV1Response : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// AwardSpring-assigned identifier of the newly created scholarship (`Opportunity.Id`).
    /// Stable for the lifetime of the scholarship. Example: `1234`.
    /// </summary>
    [JsonPropertyName("scholarship_id")]
    public int? ScholarshipId { get; set; }

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
