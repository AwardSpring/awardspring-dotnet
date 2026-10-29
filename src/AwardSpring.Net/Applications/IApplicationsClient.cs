namespace AwardSpring.Net;

public partial interface IApplicationsClient
{
    /// <summary>
    /// Returns one page at a time. Each row names the scholarship and award cycle it belongs to,
    /// and carries a `status` of `applied`, `awarded`, or `denied`. Without
    /// filters the list covers the whole institution; narrow it with `user_id` (a
    /// student's `id` from the Students endpoints) to scope to a single student. Returns
    /// `404 student_not_found`, naming `user_id` in `param`, when the `user_id` is not
    /// a student at this institution.
    ///
    /// Assistant capability: `springiq_list_student_applications`. Required permission: Users (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<ApplicationV1ListResponse> ListAsync(
        ListApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
