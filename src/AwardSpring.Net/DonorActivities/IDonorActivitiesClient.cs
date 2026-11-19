using AwardSpring.Net.Core;

namespace AwardSpring.Net;

public partial interface IDonorActivitiesClient
{
    /// <summary>
    /// Assistant capability: `springiq_list_donor_activities`. Required permission: Donors (applies when called on behalf of a signed-in person).
    /// </summary>
    Task<Pager<DonorActivityV1>> ListAsync(
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
    /// `LoggedPledge`. Gifts are recorded through the Gifts endpoints instead. A pledge for an archived donor,
    /// whether the account is archived or only its Donor role, returns `400 validation_failed`; restore the
    /// donor first. Other activity types are recorded for an archived donor.
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
    ///
    ///
    /// Assistant capability: `springiq_create_activity`. Required permission: Donors (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<CreateDonorActivityV1Response> CreateAsync(
        CreateDonorActivityV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assistant capability: `springiq_get_donor_activity`. Required permission: Donors (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<DonorActivityV1> GetAsync(
        GetDonorActivitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
