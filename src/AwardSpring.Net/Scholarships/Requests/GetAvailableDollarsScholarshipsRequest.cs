using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record GetAvailableDollarsScholarshipsRequest
{
    [JsonIgnore]
    public required string ScholarshipId { get; set; }

    [JsonIgnore]
    public required string AwardCycleId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
