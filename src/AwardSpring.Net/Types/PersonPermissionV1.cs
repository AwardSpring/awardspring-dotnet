using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One finer permission inside an area of the Permissions tab.
/// </summary>
[Serializable]
public record PersonPermissionV1 : IJsonOnDeserialized
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
    /// The permission's stable key, for example `scholarships.qualifications`.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// The permission's name as the Permissions tab shows it.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The administrator's access: `none`, `view` or `edit` for a permission with access levels,
    /// and `no` or `yes` for a permission that is simply on or off.
    /// </summary>
    [JsonPropertyName("access")]
    public PersonPermissionV1Access? Access { get; set; }

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
