using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record GetDonorActivitiesRequest
{
    [JsonIgnore]
    public required string DonorId { get; set; }

    [JsonIgnore]
    public required string ActivityId { get; set; }

    [JsonIgnore]
    public DonorActivitySourceV1? Source { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
