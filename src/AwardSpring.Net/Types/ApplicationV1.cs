using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One student's application to one scholarship within an award cycle.
/// </summary>
[Serializable]
public record ApplicationV1 : IJsonOnDeserialized
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
    /// The application's stored ID. An award of this application has the same `id`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The stored ID of the applicant's user record: the same value as the student resource's `id` (see the Students endpoints).
    /// </summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    /// <summary>
    /// The stored ID of the scholarship applied to (see the Scholarships endpoints).
    /// </summary>
    [JsonPropertyName("scholarship_id")]
    public string? ScholarshipId { get; set; }

    /// <summary>
    /// Name of the scholarship applied to, denormalized onto the row for convenience.
    /// </summary>
    [JsonPropertyName("scholarship_name")]
    public string? ScholarshipName { get; set; }

    /// <summary>
    /// The stored ID of the award cycle the application belongs to (see the Award Cycles endpoints).
    /// </summary>
    [JsonPropertyName("award_cycle_id")]
    public string? AwardCycleId { get; set; }

    /// <summary>
    /// Name of the award cycle the application belongs to, denormalized onto the row for convenience.
    /// </summary>
    [JsonPropertyName("award_cycle_name")]
    public string? AwardCycleName { get; set; }

    /// <summary>
    /// Where the application stands: `applied` (submitted, no decision yet),
    /// `awarded`, or `denied`.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// When the application was submitted, as UTC epoch seconds.
    /// </summary>
    [JsonPropertyName("applied_date")]
    public int? AppliedDate { get; set; }

    /// <summary>
    /// The student's entry-gate result on this award cycle's general application: `qualified`,
    /// `blocked_at_entry`, `pending`, or null when the application has no entry questions or
    /// the student was never evaluated.
    /// </summary>
    [JsonPropertyName("entry_outcome")]
    public string? EntryOutcome { get; set; }

    /// <summary>
    /// The student's answers to this award cycle's entry questions in the order the application asks them. Each one names the section Entry Questions. Null when the award cycle has no entry questions.
    /// </summary>
    [JsonPropertyName("entry_answers")]
    public IEnumerable<ApplicationEntryAnswerV1>? EntryAnswers { get; set; }

    /// <summary>
    /// The options the student picked on the Major question of this award cycle's general application,
    /// as the option text, in the order the question lists them. A choice the institution has since removed
    /// from the question still shows, after the ones it lists. The question can take several answers,
    /// so this may hold more than one. The options are written by the institution, so these are the
    /// institution's own words and not a fixed list. Empty when this award cycle has no Major question
    /// or the student has not answered it.
    /// </summary>
    [JsonPropertyName("majors")]
    public IEnumerable<string>? Majors { get; set; }

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
