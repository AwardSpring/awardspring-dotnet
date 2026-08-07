namespace AwardspringApi;

public partial interface IDonorActivitiesClient
{
    WithRawResponseTask<DonorActivityV1ListResponse> ListAsync(
        ListDonorActivitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Records that an interaction with a donor took place — a call you just finished, a meeting, an
    /// email, a note, or a verbal pledge. Errors come back with a stable `code`, a readable
    /// `message`, and per-field `details`, so a caller can tell what to correct.
    ///
    ///
    /// Supported activity types: `LoggedEmail`, `LoggedPhone`, `LoggedMeeting`, `LoggedNote`,
    /// `LoggedPledge`. Gifts are recorded through the Gifts endpoints instead.
    ///
    ///
    /// A typical use is working through a call list and logging each conversation as it ends, with the
    /// summary and any follow-up owner attached.
    ///
    ///
    /// Set `dry_run=true` (query param or `Dry-Run: true` header) to validate without persisting.
    ///
    /// <b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any printable-ASCII
    /// string, 1–255 chars — UUIDs work well). When supplied, the same key + same request body within 24 hours
    /// returns the original response verbatim without creating a duplicate activity. The same key with a
    /// different body returns `422 idempotency_key_request_mismatch`; a concurrent retry while the first
    /// call is still executing returns `409 idempotency_key_in_flight`. Only 2xx responses are cached —
    /// 4xx/5xx leave the key available for retry with a corrected payload.
    /// </summary>
    WithRawResponseTask<CreateDonorActivityV1Response> CreateAsync(
        CreateDonorActivityV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DonorActivityV1> GetAsync(
        GetDonorActivitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
