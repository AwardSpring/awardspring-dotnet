using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One reviewer and applicant pair in a request. Name each person by email or by stored ID. When a person
/// has both, the ID is used.
/// </summary>
[Serializable]
public record ReviewerAssignmentRowV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reviewer's stored ID. Example: `"7HQ2KW9XR"`.
    /// </summary>
    [JsonPropertyName("reviewer_id")]
    public string? ReviewerId { get; set; }

    /// <summary>
    /// The reviewer's email, ignoring upper and lower case. Example: `"pat.lee@school.edu"`.
    /// </summary>
    [JsonPropertyName("reviewer_email")]
    public string? ReviewerEmail { get; set; }

    /// <summary>
    /// The applicant's stored ID. Example: `"4MZ8RT2PW"`.
    /// </summary>
    [JsonPropertyName("applicant_id")]
    public string? ApplicantId { get; set; }

    /// <summary>
    /// The applicant's email, ignoring upper and lower case. Example: `"sam.ortiz@school.edu"`.
    /// </summary>
    [JsonPropertyName("applicant_email")]
    public string? ApplicantEmail { get; set; }

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
