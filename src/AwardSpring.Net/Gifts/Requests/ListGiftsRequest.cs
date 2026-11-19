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
    /// Free-text search (`?q=`), case-insensitive: a substring of the subject or description, the start of words in the donor's name or organization (`mar ch` finds Margaret Chen's gifts), the start of the donor's email, or the start of words in the fund's name.
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
    /// Only gifts and pledges that changed at or after this time (`?changed_since=`), in UTC epoch
    /// seconds, such as `1767225600`. The list is then in the order the gifts changed, oldest change
    /// first. With no `type`, it also lists each gift or pledge removed since that time, with only its
    /// `id`, `deleted` and `removed_at`; with `donor_id`, only that donor's. With
    /// `donor_id` or `type`, a gift or pledge that moved to another donor or switched between gift
    /// and pledge is listed that way too, at the time it changed, unless it matches the list again. Start the
    /// next sync from the list's `complete_up_to`. A time in the future, or anything but a whole number
    /// of seconds, returns `400 validation_failed`. It cannot be combined with `q` or `sort`.
    /// </summary>
    [JsonIgnore]
    public int? ChangedSince { get; set; }

    /// <summary>
    /// Page size. Defaults to 25. Values outside 1–100 are clamped rather than rejected.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Opaque cursor. Pass the `next_cursor` from the previous page to page forward. Send it or `ending_before`, never both: a request with both returns `400 validation_failed`.
    /// </summary>
    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <summary>
    /// Opaque cursor. Pass the `previous_cursor` from the current page to page backward. Send it or `starting_after`, never both: a request with both returns `400 validation_failed`.
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
