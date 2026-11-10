using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// A request too big to answer at once, running in the background. Carries
/// `"object": "reviewer_assignment_job"`. It is the body of the `202` that accepts the request and of
/// every read of `status_url`, and names the review group and its award cycle as every answer does.
/// </summary>
[Serializable]
public record ReviewerAssignmentJobV1 : IJsonOnDeserialized
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
    /// The job's code, used in `status_url`. It is not a record ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// `queued`, `running`, `completed`, `partially_completed` or `failed`.
    ///             `completed` means every row was applied. A job that stopped early, or has any turned-down or failed
    ///             row, including rows turned down when the request was accepted, is `partially_completed`. A job that
    ///             applied nothing because it could not run, or because every row it reached was turned down or failed, is
    ///             `failed`.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The stored ID of the review group the request changes.
    /// </summary>
    [JsonPropertyName("review_group_id")]
    public string? ReviewGroupId { get; set; }

    [JsonPropertyName("review_group_name")]
    public string? ReviewGroupName { get; set; }

    /// <summary>
    /// The stored ID of the review group's award cycle.
    /// </summary>
    [JsonPropertyName("award_cycle_id")]
    public string? AwardCycleId { get; set; }

    [JsonPropertyName("award_cycle_name")]
    public string? AwardCycleName { get; set; }

    /// <summary>
    /// The path to read this job again.
    /// </summary>
    [JsonPropertyName("status_url")]
    public string? StatusUrl { get; set; }

    /// <summary>
    /// How many rows the job has.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// Rows finished one way or another: applied, turned down or failed.
    /// </summary>
    [JsonPropertyName("done")]
    public int? Done { get; set; }

    [JsonPropertyName("added")]
    public int? Added { get; set; }

    [JsonPropertyName("removed")]
    public int? Removed { get; set; }

    [JsonPropertyName("unchanged")]
    public int? Unchanged { get; set; }

    [JsonPropertyName("finished_reviews_removed")]
    public int? FinishedReviewsRemoved { get; set; }

    [JsonPropertyName("turned_down")]
    public int? TurnedDown { get; set; }

    [JsonPropertyName("failed")]
    public int? Failed { get; set; }

    /// <summary>
    /// Plain sentences about the run as a whole, such as why it stopped early.
    /// </summary>
    [JsonPropertyName("notices")]
    public IEnumerable<string>? Notices { get; set; }

    /// <summary>
    /// The panel's assignment choice. Set on the `202` only.
    /// </summary>
    [JsonPropertyName("assignment_choice")]
    public string? AssignmentChoice { get; set; }

    /// <summary>
    /// Set on the `202` when `assignment_choice` is `all` or `random`.
    /// </summary>
    [JsonPropertyName("warning")]
    public string? Warning { get; set; }

    /// <summary>
    /// When the request was accepted, as UTC epoch seconds.
    /// </summary>
    [JsonPropertyName("created_at")]
    public int? CreatedAt { get; set; }

    [JsonPropertyName("started_at")]
    public int? StartedAt { get; set; }

    [JsonPropertyName("completed_at")]
    public int? CompletedAt { get; set; }

    /// <summary>
    /// The path to read the job's rows a page at a time, each with its result so far. The job itself carries only
    /// totals.
    /// </summary>
    [JsonPropertyName("rows_url")]
    public string? RowsUrl { get; set; }

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
