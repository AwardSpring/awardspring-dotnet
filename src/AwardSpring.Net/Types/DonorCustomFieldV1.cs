using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One of the institution's donor custom fields, with this donor's answer.
/// </summary>
[Serializable]
public record DonorCustomFieldV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The donor's answer to a field that is not a `single_select` or `multiple_select`, or `null`
    /// when the donor has no answer or the field takes choices.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// The choices the donor has for a `single_select` or `multiple_select` field, in the order the field
    /// lists them. Empty when the donor has none or the field does not take choices.
    /// </summary>
    [JsonPropertyName("selected")]
    public IEnumerable<string>? Selected { get; set; }

    /// <summary>
    /// The field's name. Fields are identified by name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The kind of answer the field takes: `text`, `number`, `date`, `single_select`,
    /// `multiple_select`, or `other` for a kind the settings screen no longer offers.
    /// </summary>
    [JsonPropertyName("kind")]
    public DonorCustomFieldV1Kind? Kind { get; set; }

    /// <summary>
    /// The answers a `single_select` or `multiple_select` field offers, in the order the field lists them.
    /// Empty for every other kind.
    /// </summary>
    [JsonPropertyName("choices")]
    public IEnumerable<string>? Choices { get; set; }

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
