namespace AwardSpring.Net;

public partial interface IGiftsClient
{
    /// <summary>
    /// Returns one page at a time, newest first. Without filters the list covers the whole
    /// institution. Narrow it with `donor_id` to scope to a single donor, `type` to
    /// return only gifts or only pledges, and `q` to search the subject and description.
    /// </summary>
    WithRawResponseTask<GiftV1ListResponse> ListAsync(
        ListGiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gifts may also carry soft credits, which acknowledge someone other than the giver.
    /// Send `dry_run` to validate the request without saving it, and an
    /// `Idempotency-Key` header so a retry cannot record the same gift twice.
    /// </summary>
    WithRawResponseTask<GiftV1> CreateAsync(
        CreateGiftV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
