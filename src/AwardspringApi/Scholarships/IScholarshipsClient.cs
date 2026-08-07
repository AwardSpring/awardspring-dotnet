namespace AwardspringApi;

public partial interface IScholarshipsClient
{
    /// <summary>
    /// Returns the scholarships belonging to the institution your API key is issued for, in the list
    /// envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
    /// `data`). Page forward by passing the returned `next_cursor` as `starting_after`;
    /// the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
    /// Results are ordered by scholarship id ascending.
    /// Filter with `?q=` (case-insensitive substring match on the scholarship name).
    /// </summary>
    WithRawResponseTask<ScholarshipListItemV1ListResponse> ListAsync(
        ListScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a scholarship with its name, description, dates, financial totals, payment schedule,
    /// department and donor associations, custom-field answers, and applicant-notification settings.
    /// Errors come back with a stable `code`, a readable `message`, and per-field
    /// `details`, so a caller can tell what to correct.
    ///
    ///
    /// This endpoint enforces exactly the same rules as creating a scholarship in the AwardSpring
    /// admin interface, so anything rejected here would also have been rejected there.
    ///
    ///
    /// A typical call supplies the award's name, dates falling inside the active award cycle, a
    /// budget total, and any donor association. The response returns the new
    /// `scholarship_id`, which you can use in follow-up requests.
    ///
    ///
    /// Set `dry_run=true` (query param or `Dry-Run: true` header) to validate without persisting.
    ///
    /// <b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
    /// printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus
    /// the same request body within 24 hours returns the original response verbatim without
    /// creating a duplicate scholarship. The same key with a different body returns
    /// `422 idempotency_key_request_mismatch`; a concurrent retry while the first call is
    /// still executing returns `409 idempotency_key_in_flight`. Only 2xx responses are
    /// cached — 4xx/5xx leave the key available for retry with a corrected payload.
    /// </summary>
    WithRawResponseTask<CreateScholarshipV1Response> CreateAsync(
        CreateScholarshipV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ScholarshipAvailableDollarsV1ListResponse> ListAvailableDollarsAsync(
        ListAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ScholarshipAvailableDollarsV1> GetAvailableDollarsAsync(
        GetAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AwardedStudentV1ListResponse> ListAwardedStudentsAsync(
        ListAwardedStudentsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
