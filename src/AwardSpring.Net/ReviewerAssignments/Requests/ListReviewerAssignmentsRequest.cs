using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record ListReviewerAssignmentsRequest
{
    /// <summary>
    /// The review group's stored ID (`?review_group_id=`). Send it or `review_group_name`; leaving
    /// both out returns `400 validation_failed`. A group that does not exist at your institution returns
    /// `404 review_group_not_found`.
    /// </summary>
    [JsonIgnore]
    public string? ReviewGroupId { get; set; }

    /// <summary>
    /// Optional, instead of `review_group_id`: the review group's name (`?review_group_name=`), matched
    /// whole and ignoring case, or else as part of a name. A name that fits no group returns
    /// `404 review_group_not_found`; one that fits more than one returns `400 validation_failed`
    /// naming each, with its award cycle and stored ID.
    /// </summary>
    [JsonIgnore]
    public string? ReviewGroupName { get; set; }

    /// <summary>
    /// Optional, with `review_group_name` only: the stored ID of the award cycle to look for the name in
    /// (`?award_cycle_id=`).
    /// </summary>
    [JsonIgnore]
    public string? AwardCycleId { get; set; }

    /// <summary>
    /// Optional. Only this panel's pairs (`?panel=`): `1` or `2`. Leave it out on a group with one
    /// panel, and to list both panels of a group with two. A panel the group does not have returns
    /// `404 review_group_panel_not_found`.
    /// </summary>
    [JsonIgnore]
    public int? Panel { get; set; }

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
    public IEnumerable<ListReviewerAssignmentsRequestIncludeItem> Include { get; set; } =
        new List<ListReviewerAssignmentsRequestIncludeItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
