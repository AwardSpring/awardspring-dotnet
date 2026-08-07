using AwardspringApi.Core;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[Serializable]
public record GetDonorActivitiesRequest
{
    [JsonIgnore]
    public required int DonorId { get; set; }

    [JsonIgnore]
    public required int ActivityId { get; set; }

    [JsonIgnore]
    public int? Source { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
