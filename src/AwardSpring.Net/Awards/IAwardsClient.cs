using AwardSpring.Net.Core;

namespace AwardSpring.Net;

public partial interface IAwardsClient
{
    /// <summary>
    /// Returns one page at a time. Each row names the awarded scholarship and its award cycle,
    /// and carries the awarded amount and decision date. Without filters the list covers the
    /// whole institution; narrow it with `user_id` (a student's `id` from the
    /// Students endpoints) to scope to a single student. Returns `404 student_not_found`,
    /// naming `user_id` in `param`, when the `user_id` is not a student at this institution.
    ///
    /// Assistant capability: `springiq_list_student_awards`. Required permission: Users (applies when called on behalf of a signed-in person).
    /// </summary>
    Task<Pager<AwardV1>> ListAsync(
        ListAwardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
