using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// What happened to one pair in a request.
/// </summary>
[Serializable]
public record ReviewerAssignmentRowResultV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The row's position in the request, starting at 0. Null for a pair a `replace` removes because the
    /// request leaves it out.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    /// The reviewer's stored ID. Null when the row names no active account.
    /// </summary>
    [JsonPropertyName("reviewer_id")]
    public string? ReviewerId { get; set; }

    [JsonPropertyName("reviewer_email")]
    public string? ReviewerEmail { get; set; }

    /// <summary>
    /// The applicant's stored ID. Null when the row names no active account.
    /// </summary>
    [JsonPropertyName("applicant_id")]
    public string? ApplicantId { get; set; }

    [JsonPropertyName("applicant_email")]
    public string? ApplicantEmail { get; set; }

    /// <summary>
    /// What the row asks for: `add`, `remove` or `none` when the pair is already as asked. Null
    /// for a turned-down row.
    /// </summary>
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    /// <summary>
    /// `applied` when the pair now stands as the row asks, `not_applied` when the row passed but
    ///             nothing was changed (the request was blocked or a dry run), `rejected` when the row was turned down,
    ///             `waiting` for a background row not reached yet, and `failed` for a background row that could
    ///             not be applied.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Why a row was turned down: `person_missing`, `person_not_found`, `person_ambiguous`,
    /// `reviewer_not_in_group`, `applicant_not_in_pool`, `own_application`, `duplicate_row`
    /// or `review_started_or_finished`. Null otherwise.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// A plain sentence that names the email the row is about. Null unless the row was turned down or failed.
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
