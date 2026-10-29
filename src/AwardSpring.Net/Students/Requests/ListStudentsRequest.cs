using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record ListStudentsRequest
{
    /// <summary>
    /// Free-text search (`?q=`): splits on spaces and matches each term against first name, last name, or email, case-insensitively.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Institution-assigned student number (`?student_id=`): exact, case-insensitive
    /// match. Student numbers are not guaranteed unique, so this can return more than one student.
    /// </summary>
    [JsonIgnore]
    public string? StudentId { get; set; }

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
    public IEnumerable<ListStudentsRequestIncludeItem> Include { get; set; } =
        new List<ListStudentsRequestIncludeItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
