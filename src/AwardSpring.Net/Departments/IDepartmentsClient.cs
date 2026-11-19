using AwardSpring.Net.Core;

namespace AwardSpring.Net;

public partial interface IDepartmentsClient
{
    /// <summary>
    /// Returns the departments of the institution your API key is issued for, in the standard list envelope
    /// (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`, `data`),
    /// each with how many differently named scholarships and how many administrators belong to it. Page
    /// forward by passing the returned `next_cursor` as `starting_after`. `limit` defaults to
    /// 25 and is capped at 100. Results are ordered by id ascending. Filter with `?q=`
    /// (case-insensitive substring match on the department name).
    /// </summary>
    Task<Pager<DepartmentV1>> ListAsync(
        ListDepartmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds one department, with the same rules as adding a department in the AwardSpring admin interface:
    /// the name is required and must not already be used by another department at the institution, ignoring
    /// upper and lower case and spaces at either end. A new department starts with the same settings the
    /// admin interface gives one. Departments are not available on every plan; on a plan without them this
    /// returns `403 permission_required`.
    ///
    /// <b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
    /// printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus the same
    /// request body within 24 hours returns the original response verbatim without creating a duplicate
    /// department. The same key with a different body returns `422 idempotency_key_request_mismatch`; a
    /// concurrent retry while the first call is still executing returns `409 idempotency_key_in_flight`.
    /// </summary>
    WithRawResponseTask<DepartmentV1> CreateAsync(
        CreateDepartmentV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
