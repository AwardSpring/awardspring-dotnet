namespace AwardSpring.Net;

public partial interface IScholarshipsClient
{
    /// <summary>
    /// Returns the scholarships belonging to the institution your API key is issued for, in the list
    /// envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
    /// `data`). Page forward by passing the returned `next_cursor` as `starting_after`;
    /// the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
    /// Results are ordered by scholarship id ascending.
    /// Filter with `?q=` (case-insensitive substring match on the scholarship name).
    ///
    /// Assistant capability: `springiq_list_scholarships`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
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
    ///
    ///
    /// Assistant capability: `springiq_create_scholarship`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<CreateScholarshipV1Response> CreateAsync(
        CreateScholarshipV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ScholarshipV1> GetAsync(
        GetScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes a scholarship's name, application open and close dates, department, fund, donors, description,
    /// award notification wording, custom field values and qualifications (`add_qualifications` and
    /// `remove_qualifications`), and returns the updated scholarship in the same shape as getting it. Only the
    /// fields in the body change: a field left out, or sent as `null`, stays as it is, and an empty string
    /// clears a field only where the scholarship's Details tab lets it be cleared (the department, the fund and a
    /// custom field's value).
    ///
    ///
    /// The same rules apply as when an administrator saves the scholarship's Details tab, so anything refused there
    /// is refused here. Every field is checked before anything is saved, and the changes are saved together or not
    /// at all: a request with one refused field saves nothing, and the error names each refused field in
    /// `details`. A field this call does not change (for example `total_amount`) is refused the same way.
    ///
    ///
    /// A date sent without a time is that calendar day in the institution's time zone, and the scholarship keeps
    /// the time of day it opens or closes at now. A scholarship that starts taking applications again because of
    /// the change has its student matching and auto-apply run shortly after the save, as on the Details tab.
    ///
    /// `remove_qualifications` and `add_qualifications` name groups by their `group_number` in the
    /// scholarship's `qualification_groups` as last read, and the rules are saved by the Qualifications tab's own
    /// save, so its checks apply. Qualifications change only while the scholarship is taking applications, and the
    /// request is refused if either its stored close date has passed or the `application_end_date` it sends is
    /// in the past: reopening a closed scholarship and changing its qualifications in one request is refused, so
    /// reopen it first and change the qualifications in a second call. Students are re-checked against
    /// changed qualifications shortly after the save. A question behind a qualification always carries its stored
    /// ID; a question found without one is a server error (500).
    ///
    ///
    /// A scholarship ID the institution does not have, or that is malformed, returns `404 scholarship_not_found`
    /// naming `id`. The call needs an API key with write permission.
    ///
    ///
    /// Set `dry_run=true` (query param or `Dry-Run: true` header) to check the changes and see the
    /// scholarship as it would be, without saving anything.
    ///
    /// <b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any printable-ASCII
    /// string, 1–255 chars). The same key plus the same request body within 24 hours returns the original response
    /// without changing the scholarship again. The same key with a different body returns
    /// `422 idempotency_key_request_mismatch`; a concurrent retry while the first call is still executing
    /// returns `409 idempotency_key_in_flight`. Only 2xx responses are cached.
    /// </summary>
    WithRawResponseTask<ScholarshipV1> UpdateAsync(
        UpdateScholarshipV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assistant capability: `springiq_get_available_scholarship_dollars`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<ScholarshipAvailableDollarsV1ListResponse> ListAvailableDollarsAsync(
        ListAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assistant capability: `springiq_get_available_scholarship_dollars`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<ScholarshipAvailableDollarsV1> GetAvailableDollarsAsync(
        GetAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assistant capability: `springiq_get_awarded_students`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<AwardedStudentV1ListResponse> ListAwardedStudentsAsync(
        ListAwardedStudentsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
