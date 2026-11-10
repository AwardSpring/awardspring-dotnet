using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// The result of a request to change reviewer assignments. Carries `"object": "reviewer_assignment_change"`.
/// It is the body of a `200`, and the `details` of a `400 assignment_rows_rejected`.
/// </summary>
[Serializable]
public record ChangeReviewerAssignmentsV1Result : IJsonOnDeserialized
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

    [JsonPropertyName("review_group_id")]
    public string? ReviewGroupId { get; set; }

    [JsonPropertyName("review_group_name")]
    public string? ReviewGroupName { get; set; }

    [JsonPropertyName("award_cycle_id")]
    public string? AwardCycleId { get; set; }

    [JsonPropertyName("award_cycle_name")]
    public string? AwardCycleName { get; set; }

    /// <summary>
    /// The panel changed. Null on a review group with one panel.
    /// </summary>
    [JsonPropertyName("panel")]
    public int? Panel { get; set; }

    /// <summary>
    /// `add`, `remove` or `replace`.
    /// </summary>
    [JsonPropertyName("mode")]
    public string? Mode { get; set; }

    /// <summary>
    /// True when the pairs were written. False for a dry run and for a blocked request.
    /// </summary>
    [JsonPropertyName("applied")]
    public bool? Applied { get; set; }

    [JsonPropertyName("dry_run")]
    public bool? DryRun { get; set; }

    [JsonPropertyName("added")]
    public int? Added { get; set; }

    [JsonPropertyName("removed")]
    public int? Removed { get; set; }

    /// <summary>
    /// Pairs already as the request asked.
    /// </summary>
    [JsonPropertyName("unchanged")]
    public int? Unchanged { get; set; }

    /// <summary>
    /// Rows turned down.
    /// </summary>
    [JsonPropertyName("rejected")]
    public int? Rejected { get; set; }

    /// <summary>
    /// How many of the removed pairs had a finished review. Their scores were removed with them.
    /// </summary>
    [JsonPropertyName("finished_reviews_removed")]
    public int? FinishedReviewsRemoved { get; set; }

    /// <summary>
    /// How the panel picks reviewers: `manual`, `all` or `random`. A request never changes it.
    /// </summary>
    [JsonPropertyName("assignment_choice")]
    public string? AssignmentChoice { get; set; }

    /// <summary>
    /// Set when `assignment_choice` is `all` or `random`: applying that choice again in
    /// AwardSpring would replace the pairs loaded here. Null otherwise.
    /// </summary>
    [JsonPropertyName("warning")]
    public string? Warning { get; set; }

    [JsonPropertyName("rows")]
    public IEnumerable<ReviewerAssignmentRowResultV1>? Rows { get; set; }

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
