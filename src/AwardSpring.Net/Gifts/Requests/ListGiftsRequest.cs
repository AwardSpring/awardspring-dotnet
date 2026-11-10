using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record ListGiftsRequest
{
    /// <summary>
    /// Optional donor scope (`?donor_id=`): the donor's stored ID. Omit for a tenant-wide list.
    /// </summary>
    [JsonIgnore]
    public string? DonorId { get; set; }

    /// <summary>
    /// Record-type filter (`?type=`): `gift` or `pledge`. Omit for both.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; set; }

    /// <summary>
    /// Free-text search (`?q=`): case-insensitive substring match on subject or description.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// The order to list gifts in (`?sort=`): `date_desc` for the newest gift date first, or
    /// `date_asc` for the oldest gift date first. Leave it out for the order the gifts were
    /// recorded in. Any other value returns `400 validation_failed`.
    /// </summary>
    [JsonIgnore]
    public ListGiftsRequestSort? Sort { get; set; }

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

    /// <summary>
    /// Optional extras to add to the response, comma-separated. `total_count` is the only supported value: it adds `total_count`, the number of records that match this request across all pages. The count is taken fresh at the moment of each request, so it can change while you page; ask for it on the first page. Without it, `total_count` is left out of the response. Asking or not never invalidates a cursor. Any other value returns `400 validation_failed`.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ListGiftsRequestIncludeItem> Include { get; set; } =
        new List<ListGiftsRequestIncludeItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
