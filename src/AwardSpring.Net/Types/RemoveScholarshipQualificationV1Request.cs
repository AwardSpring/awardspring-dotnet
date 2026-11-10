using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// A qualification rule to remove from one group. Name the rule by `question_id`, or an institutional award
/// rule by `institutional_award_scholarship_id`, and always send `group`. To remove a question's rule from
/// several groups, send one entry per group.
/// </summary>
[Serializable]
public record RemoveScholarshipQualificationV1Request : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The stored ID of the question the rule checks, as the rule's `question_id` shows it. Example: `"4MZ8RT2QX"`.
    /// </summary>
    [JsonPropertyName("question_id")]
    public string? QuestionId { get; set; }

    /// <summary>
    /// Instead of `question_id`, to remove an institutional award rule: the stored ID of the scholarship the rule
    /// names, as its `institutional_award_scholarship_id` shows it.
    /// </summary>
    [JsonPropertyName("institutional_award_scholarship_id")]
    public string? InstitutionalAwardScholarshipId { get; set; }

    /// <summary>
    /// Required. The number of the group to remove the rule from, as the scholarship was last read (its
    /// `qualification_groups`). Example: `1`.
    /// </summary>
    [JsonPropertyName("group")]
    public int? Group { get; set; }

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
