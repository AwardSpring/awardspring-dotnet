using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One row of a background reviewer assignment request and what has happened to it so far. Carries
/// `"object": "reviewer_assignment_job_row"`.
/// </summary>
[Serializable]
public record ReviewerAssignmentJobRowV1 : IJsonOnDeserialized
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
    /// The row's position in the request, starting at 0. Null for a pair a `replace` removes because the
    /// request leaves it out.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    [JsonPropertyName("reviewer_email")]
    public string? ReviewerEmail { get; set; }

    [JsonPropertyName("applicant_email")]
    public string? ApplicantEmail { get; set; }

    /// <summary>
    /// What the row asks for: `add`, `remove` or `none` when the pair is already as asked. Null
    /// for a row turned down before the job started.
    /// </summary>
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    /// <summary>
    /// `applied` when the pair now stands as the row asks, `rejected` when the row was turned down,
    ///             `waiting` while the job has not reached it, and `failed` when it could not be applied. A row an
    ///             all-or-nothing job never reached, because a pair failed its final check, stays `waiting`. When a job
    ///             stops for any other reason, a row it did not change is `rejected` and its `message` says why.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// A plain sentence saying why the row was turned down or failed. Null otherwise.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

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
