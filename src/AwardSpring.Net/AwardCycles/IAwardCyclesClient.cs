namespace AwardSpring.Net;

public partial interface IAwardCyclesClient
{
    /// <summary>
    /// Returns the award cycles belonging to the institution your API key is issued for, in the list
    /// envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
    /// `data`). Page forward by passing the returned `next_cursor` as `starting_after`;
    /// the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
    /// Results are ordered by award-cycle id ascending. Filter with `?q=` (case-insensitive
    /// substring match on the award-cycle name).
    ///
    /// Assistant capability: `springiq_list_award_cycles`.
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
    ///
    /// Assistant capability: `springiq_get_current_award_cycle`.
    /// </summary>
    WithRawResponseTask<AwardCycleV1> GetCurrentAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one available-dollars summary (`object: "available_dollars_summary"`): the budget, awarded and remaining amounts of
    /// every active scholarship in the award cycle added together, and how many of those scholarships are
    /// over-awarded. The totals add up the same scholarships and amounts that
    /// `GET /api/v1/scholarships/available-dollars` lists for the same cycle, so use this endpoint for a
    /// cycle-wide total instead of paging through that list. An over-awarded scholarship (one that has awarded
    /// more than its budget) is included and counts against `total_amount_remaining`. A cycle with no
    /// active scholarships returns zeros, not an error. An award cycle ID the institution does not have returns
    /// `404 award_cycle_not_found` naming `awardCycleId`; to find the cycle running now, call
    /// `GET /api/v1/award-cycles/current`.
    ///
    /// Assistant capability: `springiq_get_available_dollars_summary`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<AvailableDollarsSummaryV1> GetAvailableDollarsSummaryAsync(
        GetAvailableDollarsSummaryAwardCyclesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
