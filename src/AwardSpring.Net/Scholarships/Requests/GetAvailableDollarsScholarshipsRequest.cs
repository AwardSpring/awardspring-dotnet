using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record GetAvailableDollarsScholarshipsRequest
{
    [JsonIgnore]
    public required int ScholarshipId { get; set; }

    [JsonIgnore]
    public int? AwardCycleId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
