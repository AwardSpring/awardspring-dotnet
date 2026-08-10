namespace AwardSpring.Net;

public partial interface IFundsClient
{
    /// <summary>
    /// Returns the funds belonging to the institution your API key is issued for, in the standard list envelope
    /// (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
    /// `data`). Page forward by passing the returned `next_cursor` as
    /// `starting_after`. Filter with `?q=` (case-insensitive substring match on the
    /// fund name).
    /// </summary>
    WithRawResponseTask<FundListItemV1ListResponse> ListAsync(
        ListFundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
