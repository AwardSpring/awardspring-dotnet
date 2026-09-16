namespace AwardSpring.Net;

public partial interface IAwardsClient
{
    /// <summary>
    /// Returns one page at a time. Each row names the awarded scholarship and its award cycle,
    /// and carries the awarded amount and decision date. Without filters the list covers the
    /// whole institution; narrow it with `user_id` (a student's `id` from the
    /// Students endpoints) to scope to a single student. Returns `404 student_not_found`
    /// when the `user_id` does not belong to this institution.
    /// </summary>
    WithRawResponseTask<AwardV1ListResponse> ListAsync(
        ListAwardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
