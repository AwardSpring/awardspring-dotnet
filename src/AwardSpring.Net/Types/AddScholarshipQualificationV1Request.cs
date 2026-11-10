using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// A qualification rule to add, on one application question named by its stored ID. Which value fields it takes
/// depends on the question's `question_type`: a number question takes `comparison` with `value`
/// (or `between` with `min` and `max`), a `number_range` question takes `min` and
/// `max`, and a choice question takes `answers`.
/// </summary>
[Serializable]
public record AddScholarshipQualificationV1Request : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Required. The stored ID of an active application question at the institution that can back a qualification:
    /// a general application question, or one of this scholarship's own Before Applying questions where the
    /// institution allows them. Example: `"4MZ8RT2QX"`.
    /// </summary>
    [JsonPropertyName("question_id")]
    public string? QuestionId { get; set; }

    /// <summary>
    /// Required. The rule's title; it cannot be blank. Example: `"GPA 3.2 or higher"`.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Required on a `number`, `high_school_gpa`, `college_gpa` or `expense_ratio` question;
    /// there is no default. One of `at_least`, `at_most`, `more_than`, `less_than`,
    /// `equals` or `between`. A `number_range` question takes none, or `between`. Not
    /// accepted on a choice question.
    /// </summary>
    [JsonPropertyName("comparison")]
    public AddScholarshipQualificationV1RequestComparison? Comparison { get; set; }

    /// <summary>
    /// The number to compare against, as a JSON number, with any comparison but `between`. Stored to 4 decimal
    /// places. A GPA must be above 0 and at most 6. Example: `3.2`.
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value { get; set; }

    /// <summary>
    /// The lowest accepted number, with `between` or on a `number_range` question. It must be less than
    /// `max`. A GPA must be above 0 and at most 6; an expense ratio at least -100.
    /// </summary>
    [JsonPropertyName("min")]
    public double? Min { get; set; }

    /// <summary>
    /// The highest accepted number, with `between` or on a `number_range` question. A GPA must be above 0
    /// and at most 6; an expense ratio at most 100.
    /// </summary>
    [JsonPropertyName("max")]
    public double? Max { get; set; }

    /// <summary>
    /// On a choice question, the accepted answers by name, matched without regard to case; only the question's active
    /// answers are accepted. A `one_choice` question takes 1 or more (and must itself have at least 2 active
    /// answers), `multiple_choice` 2 or more, `multiple_choice_any` 1 or more, and `major`,
    /// `degree` and `academic_status` 1 or more, or exactly 1 with `only_this_one`. Not accepted on a
    /// number question. Example: `["Nursing"]`.
    /// </summary>
    [JsonPropertyName("answers")]
    public IEnumerable<string>? Answers { get; set; }

    /// <summary>
    /// On a `major`, `degree` or `academic_status` question only: `any_of` (the default) or
    /// `only_this_one`.
    /// </summary>
    [JsonPropertyName("answer_setup")]
    public AddScholarshipQualificationV1RequestAnswerSetup? AnswerSetup { get; set; }

    /// <summary>
    /// Where the rule goes. `every_group` (the default) adds it to every group that still has rules, so every
    /// student must meet it; with no groups, it makes group 1. `new_group` adds a new group at the end, an
    /// alternative to the others. `group` adds it to the one group named by `to_group`.
    /// </summary>
    [JsonPropertyName("placement")]
    public AddScholarshipQualificationV1RequestPlacement? Placement { get; set; }

    /// <summary>
    /// With `placement: "group"` only, and then required: the group's number as the scholarship was last read
    /// (its `qualification_groups`). Example: `1`.
    /// </summary>
    [JsonPropertyName("to_group")]
    public int? ToGroup { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
