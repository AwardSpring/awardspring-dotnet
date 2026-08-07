using AwardspringApi.Core;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[Serializable]
public record ListDonorActivitiesRequest
{
    [JsonIgnore]
    public required int DonorId { get; set; }

    /// <summary>
    /// Free-text search (`?q=`): case-insensitive substring match on subject or description.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Activity-type filter (`?activity_type=`): case-insensitive exact match on the activity type label.
    /// </summary>
    [JsonIgnore]
    public string? ActivityType { get; set; }

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
