using AwardspringApi.Core;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[Serializable]
public record GetDonorsRequest
{
    [JsonIgnore]
    public required int Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
