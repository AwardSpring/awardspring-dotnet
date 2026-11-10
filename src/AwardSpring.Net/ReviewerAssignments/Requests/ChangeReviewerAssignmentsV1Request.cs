using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record ChangeReviewerAssignmentsV1Request
{
    /// <summary>
    /// Required. The review group's stored ID. Leaving it out returns `400 validation_failed`; a group that
    /// does not exist at your institution returns `404 review_group_not_found`.
    /// </summary>
    [JsonPropertyName("review_group_id")]
    public string? ReviewGroupId { get; set; }

    /// <summary>
    /// Required. `add` adds the pairs, `remove` removes them, and `replace` makes the panel hold
    /// exactly these pairs: pairs not listed are removed and new ones are added. Any other value returns
    /// `400 validation_failed`.
    /// </summary>
    [JsonPropertyName("mode")]
    public string? Mode { get; set; }

    /// <summary>
    /// Optional. The panel to change, `1` or `2`. Leave it out on a review group with one panel. On a
    /// group with two panels, leaving it out means panel 1. A panel the group does not have returns
    /// `404 review_group_panel_not_found`.
    /// </summary>
    [JsonPropertyName("panel")]
    public int? Panel { get; set; }

    /// <summary>
    /// Required. At least one pair and at most 20,000.
    /// </summary>
    [JsonPropertyName("rows")]
    public IEnumerable<ReviewerAssignmentRowV1>? Rows { get; set; }

    /// <summary>
    /// Optional, default `false`. When `true`, the pairs that pass are applied and each turned-down row
    /// is listed. When `false`, a single turned-down row changes nothing.
    /// </summary>
    [JsonPropertyName("apply_good_rows_only")]
    public bool? ApplyGoodRowsOnly { get; set; }

    /// <summary>
    /// Optional, default `false`. When `false`, a `replace` that would remove a pair whose review
    /// is started or finished turns that pair down. When `true` it removes the pair and its scores.
    /// `remove` mode always removes the pairs it lists, as Unassign does on the tab.
    /// </summary>
    [JsonPropertyName("allow_removing_started_reviews")]
    public bool? AllowRemovingStartedReviews { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
