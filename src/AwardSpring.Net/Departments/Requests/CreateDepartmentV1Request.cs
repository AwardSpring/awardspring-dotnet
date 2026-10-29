using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record CreateDepartmentV1Request
{
    /// <summary>
    /// The department's name. Required, and not already used by another department at the institution,
    /// ignoring upper and lower case and spaces at either end. Example: `"School of Nursing"`.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
