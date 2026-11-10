using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One of the institution's scholarship custom fields, with this scholarship's value in it, as the scholarship's
/// Details tab shows it.
/// </summary>
[Serializable]
public record ScholarshipCustomFieldV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The custom field's stored ID. Example: `"3KD8WQ2MZ"`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The custom field's name, as the Details tab shows it. Example: `"Award type"`.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// What the field holds: `"text"`, `"number"`, `"one_choice"` (one of a list of choices) or
    /// `"multiple_choice"` (any number of a list of choices).
    /// </summary>
    [JsonPropertyName("type")]
    public ScholarshipCustomFieldV1Type? Type { get; set; }

    /// <summary>
    /// The value of a `text`, `number` or `one_choice` field (for a choice, the choice's name), or
    /// null when it has none. Always null for a `multiple_choice` field, which uses `values`.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// The names of the chosen choices of a `multiple_choice` field, in the order the Details tab lists them;
    /// empty when none is chosen. Always null for the other types, which use `value`.
    /// </summary>
    [JsonPropertyName("values")]
    public IEnumerable<string>? Values { get; set; }

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
