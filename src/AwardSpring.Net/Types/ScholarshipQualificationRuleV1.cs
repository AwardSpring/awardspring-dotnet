using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One qualification rule. A `question` rule checks the student's answer to one application question; an
/// `institutional_award` rule checks whether the student has won another scholarship.
/// </summary>
[Serializable]
public record ScholarshipQualificationRuleV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// `"question"`, or `"institutional_award"` (the student must have won another scholarship).
    /// </summary>
    [JsonPropertyName("kind")]
    public ScholarshipQualificationRuleV1Kind? Kind { get; set; }

    /// <summary>
    /// The rule's title, as the Qualifications tab shows it. Example: `"GPA 3.0 or higher"`.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// On an `institutional_award` rule, the stored ID of the scholarship the student must have won. Null on a
    /// `question` rule. Example: `"9QW3ZK7HD"`.
    /// </summary>
    [JsonPropertyName("institutional_award_scholarship_id")]
    public string? InstitutionalAwardScholarshipId { get; set; }

    /// <summary>
    /// The stored ID of the application question the rule checks. Always set on a `question` rule; null on an
    /// `institutional_award` rule. Example: `"4MZ8RT2QX"`.
    /// </summary>
    [JsonPropertyName("question_id")]
    public string? QuestionId { get; set; }

    /// <summary>
    /// The question's wording, for people reading the answer. Null on an `institutional_award` rule. Never accepted on input.
    /// </summary>
    [JsonPropertyName("question")]
    public string? Question { get; set; }

    /// <summary>
    /// The kind of question, which says which of the fields below apply: `one_choice`, `multiple_choice`
    /// (the student must have chosen every listed answer), `multiple_choice_any` (any one listed answer is
    /// enough), `major`, `degree`, `academic_status`, `number`, `number_range`,
    /// `high_school_gpa`, `college_gpa` or `expense_ratio`. Null on an `institutional_award`
    /// rule. Never accepted on input.
    /// </summary>
    [JsonPropertyName("question_type")]
    public ScholarshipQualificationRuleV1QuestionType? QuestionType { get; set; }

    /// <summary>
    /// A number rule's comparison: `at_least` (&gt;=), `at_most` (&lt;=), `more_than` (&gt;),
    /// `less_than` (&lt;), `equals` (=) or `between` (`min` to `max`). Null on a choice
    /// rule.
    /// </summary>
    [JsonPropertyName("comparison")]
    public ScholarshipQualificationRuleV1Comparison? Comparison { get; set; }

    /// <summary>
    /// The number compared against, when `comparison` is not `between`. Null otherwise. Example: `3.0`.
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value { get; set; }

    /// <summary>
    /// The lowest accepted number, with `between` or on a `number_range` question. Null otherwise.
    /// </summary>
    [JsonPropertyName("min")]
    public double? Min { get; set; }

    /// <summary>
    /// The highest accepted number, with `between` or on a `number_range` question. Null otherwise.
    /// </summary>
    [JsonPropertyName("max")]
    public double? Max { get; set; }

    /// <summary>
    /// A choice rule's accepted answers, by name, in the question's order. Null on a number rule. Example:
    /// `["Nursing", "Nursing (RN to BSN)"]`.
    /// </summary>
    [JsonPropertyName("answers")]
    public IEnumerable<string>? Answers { get; set; }

    /// <summary>
    /// For `major`, `degree` and `academic_status` rules only: `any_of` (any listed answer
    /// qualifies) or `only_this_one` (exactly one answer is listed). Null on every other rule.
    /// </summary>
    [JsonPropertyName("answer_setup")]
    public ScholarshipQualificationRuleV1AnswerSetup? AnswerSetup { get; set; }

    /// <summary>
    /// True when the question has been retired since the rule was made, which the Qualifications tab shows as a
    /// conflict. Always false on an `institutional_award` rule.
    /// </summary>
    [JsonPropertyName("question_inactive")]
    public bool? QuestionInactive { get; set; }

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
