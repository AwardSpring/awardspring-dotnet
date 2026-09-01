using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record ListAvailableDollarsScholarshipsRequest
{
    [JsonIgnore]
    public required int AwardCycleId { get; set; }

    /// <summary>
    /// Page size. Defaults to 25. Values outside 1–100 are clamped rather than rejected.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Opaque cursor. Pass the `next_cursor` from the previous page to page forward. Mutually exclusive with `ending_before`; if both are supplied, `starting_after` wins.
    /// </summary>
    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <summary>
    /// Opaque cursor. Pass the `previous_cursor` from the current page to page backward.
    /// </summary>
    [JsonIgnore]
    public string? EndingBefore { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
