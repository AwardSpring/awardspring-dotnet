namespace AwardSpring.Net;

public partial interface IDonorsClient
{
    /// <summary>
    /// Returns one page at a time. Search with `q`: it splits on spaces and matches each
    /// term against first name, last name, email, or organization, so `jane smith` finds
    /// donors matching both terms.
    /// </summary>
    WithRawResponseTask<DonorListItemV1ListResponse> ListAsync(
        ListDonorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates either an individual or an organization, depending on `role`. Send
    /// `dry_run` to validate the request without saving it, and an `Idempotency-Key`
    /// header so a retry cannot create the same donor twice.
    /// </summary>
    WithRawResponseTask<DonorV1> CreateAsync(
        CreateDonorV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Includes giving totals for the donor's lifetime and the current year, their most recent
    /// gift, and their notes. Returns `404 donor_not_found` if no such donor belongs to
    /// this institution.
    /// </summary>
    WithRawResponseTask<DonorDetailV1> GetAsync(
        GetDonorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Only the fields present in the request body change; anything omitted is left alone. Send
    /// `dry_run` to validate the request without saving it.
    /// </summary>
    WithRawResponseTask<DonorV1> UpdateAsync(
        UpdateDonorV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replaces the donor's free-text notes. Returns `404 donor_not_found` if no such donor
    /// belongs to this institution.
    /// </summary>
    WithRawResponseTask<DonorNotesV1> UpdateNotesAsync(
        UpdateDonorNotesV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
