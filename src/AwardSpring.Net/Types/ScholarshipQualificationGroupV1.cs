using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One of a scholarship's qualification groups. A student qualifies by meeting every rule in at least one group:
/// rules inside a group are all required, and the groups are alternatives.
/// </summary>
[Serializable]
public record ScholarshipQualificationGroupV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The group's number, counting from 1 in the order the scholarship's Qualifications tab shows the groups. The
    /// update call's `to_group` and `group` mean these numbers. Example: `1`.
    /// </summary>
    [JsonPropertyName("group_number")]
    public int? GroupNumber { get; set; }

    /// <summary>
    /// The group's rules, in the Qualifications tab's order. A group always has at least one.
    /// </summary>
    [JsonPropertyName("rules")]
    public IEnumerable<ScholarshipQualificationRuleV1>? Rules { get; set; }

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
