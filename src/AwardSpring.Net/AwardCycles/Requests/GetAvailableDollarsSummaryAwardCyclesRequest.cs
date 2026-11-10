using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record GetAvailableDollarsSummaryAwardCyclesRequest
{
    /// <summary>
    /// The award cycle's stored ID.
    /// </summary>
    [JsonIgnore]
    public required string AwardCycleId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
