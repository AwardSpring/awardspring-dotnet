namespace AwardspringApi;

public partial interface IAwardCyclesClient
{
    /// <summary>
    /// Returns the award cycles belonging to the institution your API key is issued for, in the list
    /// envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
    /// `data`). Page forward by passing the returned `next_cursor` as `starting_after`;
    /// the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
    /// Results are ordered by award-cycle id ascending. Filter with `?q=` (case-insensitive
    /// substring match on the award-cycle name).
    /// </summary>
    WithRawResponseTask<AwardCycleV1ListResponse> ListAsync(
        ListAwardCyclesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single AwardCycleV1 resource. The lookup prefers the cycle the
    /// institution has marked current; when none is marked current it falls back to the cycle
    /// marked next. When neither exists the endpoint returns `404 award_cycle_not_found` in the
    /// structured v1 error shape — in that case list all cycles via `GET /api/v1/award-cycles`
    /// and ask the user which one to use.
    /// </summary>
    WithRawResponseTask<AwardCycleV1> GetCurrentAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
