using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record ListPeopleRequest
{
    /// <summary>
    /// Which tab of the Users list (`?role=`): `administrators`, `reviewers`, `students`
    /// or `donors`. The reviewers tab also lists anyone on a review group in the current award cycle.
    /// </summary>
    [JsonIgnore]
    public string? Role { get; set; }

    /// <summary>
    /// Free-text search (`?q=`): matches part of a first or last name or organization, the start of
    /// an email address or student number, or a person's exact `id`.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Account status (`?status=`): `all` (the default, as the Users list shows), `active`
    /// or `archived`.
    /// </summary>
    [JsonIgnore]
    public string? Status { get; set; }

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
    public IEnumerable<ListPeopleRequestIncludeItem> Include { get; set; } =
        new List<ListPeopleRequestIncludeItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
