using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record ListDonorsRequest
{
    /// <summary>
    /// Search text (`?q=`), at least `2` characters; a shorter search returns
    /// `400 validation_failed`. Each word must match the start of a word in the donor's first
    /// name, last name or organization, or the start of their email address, ignoring case:
    /// `co` finds `Coworking` and `cole@school.edu` but not `Waco`. Where digits
    /// and letters touch, a word is also split there, so `25co` searches as `25 co`. A
    /// search with no spaces also matches the start of the full name or organization with its
    /// spaces taken out, so `janesmith` finds Jane Smith. Leave it out to list every donor.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Only donors at these levels (`?level=`): `Annual`, `Mid`, `Major` or
    /// `Principal`, the values of the donor's `level` field, in any case. Send several
    /// comma-separated (`level=major,principal`) or repeat the parameter; a donor at any of
    /// them is listed. Any other value returns `400 validation_failed`. Level is worked out
    /// from giving, so a signed-in user who may not see donors' giving gets
    /// `403 permission_denied`. Leave it out for every level.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ListDonorsRequestLevelItem> Level { get; set; } =
        new List<ListDonorsRequestLevelItem>();

    /// <summary>
    /// Only donors with these giving statuses (`?giving_status=`): `Recurring`, `New`
    /// or `Lapsed`, the values of the donor's `giving_status` field, in any case. Send
    /// several comma-separated (`giving_status=recurring,new`) or repeat the parameter; a donor
    /// with any of them is listed. With `level` as well, a donor must match both. Any other
    /// value returns `400 validation_failed`. Giving status is worked out from giving, so a
    /// signed-in user who may not see donors' giving gets `403 permission_denied`. Leave it
    /// out for every donor, including those with no giving status.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ListDonorsRequestGivingStatusItem> GivingStatus { get; set; } =
        new List<ListDonorsRequestGivingStatusItem>();

    /// <summary>
    /// The order to list donors in (`?sort=`): `name` or `last_contacted`. Leave it
    /// out for the default order. Any other value returns `400 validation_failed`.
    /// </summary>
    [JsonIgnore]
    public ListDonorsRequestSort? Sort { get; set; }

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
    public IEnumerable<ListDonorsRequestIncludeItem> Include { get; set; } =
        new List<ListDonorsRequestIncludeItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
