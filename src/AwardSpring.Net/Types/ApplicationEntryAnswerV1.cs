using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One answer to an entry question on the student's general application for the award cycle.
/// </summary>
[Serializable]
public record ApplicationEntryAnswerV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the application section the entry question sits in. Always Entry Questions.
    /// </summary>
    [JsonPropertyName("section")]
    public string? Section { get; set; }

    /// <summary>
    /// The stored ID of the entry question.
    /// </summary>
    [JsonPropertyName("question_id")]
    public string? QuestionId { get; set; }

    /// <summary>
    /// The question as this award cycle's application words it.
    /// </summary>
    [JsonPropertyName("question")]
    public string? Question { get; set; }

    /// <summary>
    /// What the student answered. Chosen options are joined with a comma and a space and a number is given as the student entered it.
    /// </summary>
    [JsonPropertyName("answer")]
    public string? Answer { get; set; }

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
