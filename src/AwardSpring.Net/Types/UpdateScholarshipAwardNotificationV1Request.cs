using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// New award notification wording. A part left out, or sent as `null`, keeps its current wording. Merge fields
/// are written `{{FieldName}}`; one AwardSpring does not fill in is refused, naming it.
/// </summary>
[Serializable]
public record UpdateScholarshipAwardNotificationV1Request : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The new email subject. It cannot be blank. Example: `"Congratulations, {{StudentFirstName}}!"`.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// The new email body, as HTML. It cannot be blank.
    /// Example: `"<para>You have been awarded the {{ScholarshipTitle}}.</para>"`.
    /// </summary>
    [JsonPropertyName("body")]
    public string? Body { get; set; }

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
