using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// A new value for one scholarship custom field, named by the field's stored ID. Send exactly one of
/// `value` and `values`.
/// </summary>
[Serializable]
public record UpdateScholarshipCustomFieldV1Request : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The custom field's stored ID, as the scholarship's `custom_fields` shows it. Example: `"3KD8WQ2MZ"`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The new value. For a `text` field, any text; for a `number` field, a number such as `"3.5"`;
    /// for a `one_choice` or `multiple_choice` field, the name of one of its active choices (matched
    /// without regard to case). An empty string clears the field.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// The names of the choices to choose, for a choice field: this replaces every choice it has now. A
    /// `one_choice` field takes at most one. An empty list clears the field. Not accepted for a `text` or
    /// `number` field. Example: `["Merit", "Need"]`.
    /// </summary>
    [JsonPropertyName("values")]
    public IEnumerable<string>? Values { get; set; }

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
