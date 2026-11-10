using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One reviewer and applicant pair in a review group, as the Reviewer Assignment tab shows it. Carries
/// `"object": "reviewer_assignment"`.
/// </summary>
[Serializable]
public record ReviewerAssignmentV1 : IJsonOnDeserialized
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
    /// The stored ID of the review group.
    /// </summary>
    [JsonPropertyName("review_group_id")]
    public string? ReviewGroupId { get; set; }

    [JsonPropertyName("review_group_name")]
    public string? ReviewGroupName { get; set; }

    [JsonPropertyName("award_cycle_id")]
    public string? AwardCycleId { get; set; }

    [JsonPropertyName("award_cycle_name")]
    public string? AwardCycleName { get; set; }

    /// <summary>
    /// The panel the pair is on, `1` or `2`. Null on a review group with one panel.
    /// </summary>
    [JsonPropertyName("panel")]
    public int? Panel { get; set; }

    [JsonPropertyName("reviewer")]
    public ReviewerAssignmentPersonV1? Reviewer { get; set; }

    [JsonPropertyName("applicant")]
    public ReviewerAssignmentPersonV1? Applicant { get; set; }

    /// <summary>
    /// Where the review stands: `not_started`, `in_progress` or `complete`.
    /// </summary>
    [JsonPropertyName("review_status")]
    public string? ReviewStatus { get; set; }

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
