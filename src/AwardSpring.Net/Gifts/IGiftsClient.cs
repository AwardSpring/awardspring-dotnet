using AwardSpring.Net.Core;

namespace AwardSpring.Net;

public partial interface IGiftsClient
{
    /// <summary>
    /// Returns one page at a time. Without filters the list covers the whole
    /// institution. Narrow it with `donor_id` (a donor's stored ID) to scope to a single donor, `type` to
    /// return only gifts or only pledges, and `q` to search the subject and description, the donor's
    /// name, organization or email, and the fund's name. `donor_id` takes any donor
    /// `GET /api/v1/donors/{id}` returns, an archived one included.
    ///
    ///
    /// With no `sort`, gifts are listed in the order they were recorded, earliest recorded first.
    /// Sort by gift `date` with `sort`: `date_desc` lists the newest gift date first and
    /// `date_asc` the oldest first. Gifts that share a date keep the same order from one page
    /// to the next: the most recently recorded first for `date_desc`, the earliest recorded first
    /// for `date_asc`.
    ///
    /// `sort`, `donor_id`, `type` and `q` work together. Send the same ones on every
    /// page: a cursor sent with a different `sort`, `donor_id`, `type` or `q` returns
    /// `400 invalid_cursor`. An unknown `sort` returns `400 validation_failed` with
    /// `param` set to `sort`.
    ///
    ///
    /// To keep a copy in sync, send `changed_since`, a time in UTC epoch seconds. The list then holds
    /// only the gifts and pledges that changed at or after that time, in the order they changed, oldest
    /// change first, by `last_changed_at`. A gift or pledge removed since that time is listed too, at
    /// the time it was removed, with only `object`, `id`, `deleted: true` and
    /// `removed_at`. A list narrowed by `donor_id` lists that donor's removed gifts and pledges. A
    /// removed gift keeps no type, so a list narrowed by `type` leaves removals out: keep one sync
    /// without `type` to learn of them. A gift or pledge that moved to another donor, or switched between
    /// gift and pledge, is listed the same way in a list narrowed by the `donor_id` or `type` it
    /// left, at the time it changed, unless it matches that list again by then; it stays live in every other
    /// list, and a list with neither filter never lists it removed. Every page carries `complete_up_to`, the same on every
    /// page of one walk; start the next sync from it. A gift may appear in two syncs in a row, but none is
    /// missed.
    ///
    /// `changed_since` works with `donor_id` and `type`. With `sort` or `q` it
    /// returns `400 validation_failed` with `param` naming the parameter it cannot be combined
    /// with. A time in the future, or anything but a whole number of seconds, returns
    /// `400 validation_failed` with `param` set to `changed_since`. A cursor sent with a
    /// different `changed_since` returns `400 invalid_cursor`.
    ///
    ///
    /// Assistant capability: `springiq_list_gifts`. Required permission: Donors (applies when called on behalf of a signed-in person).
    /// </summary>
    Task<Pager<GiftV1>> ListAsync(
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

    /// <summary>
    /// Fetches one gift or pledge by its `id` from the gifts list, with the same fields and values
    /// the list returns for it. Returns `404 gift_not_found`, naming `id` in `param`, when
    /// no gift or pledge with that ID belongs to this institution, including when the ID belongs to
    /// another kind of logged activity such as an email or a meeting.
    /// </summary>
    WithRawResponseTask<GiftV1> GetAsync(
        GetGiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes a gift's or pledge's amount, gift date, payment type, fund, campaign, subject and description,
    /// with the same rules the gift's edit window applies. Send only the fields to change: a field left out
    /// keeps its value. Send an empty string to clear `fund_id`, `campaign_id` or
    /// `description`; the other fields cannot be cleared.
    ///
    ///
    /// The donor, the record type (`type`), soft credits, `is_completed`,
    /// `assigned_to_user_id`, `gift_acknowledgement_sent` and any field not listed in the request
    /// body cannot be changed here. A request that sends one, or a value that is refused, returns
    /// `400 validation_failed`, and nothing in the request is saved. Each refused field is named in
    /// `details`, and in `param` when only one field is refused; a refusal from the gift's own save rules
    /// (for example a zero amount, or a closed fund) names no field.
    /// On a gift given online, the amount, gift date and payment type cannot be changed; its other fields can.
    /// A pledge has no payment type, and `Online` cannot be chosen as a payment type.
    ///
    ///
    /// Returns the gift or pledge as `GET /api/v1/gifts/{id}` returns it after the change. Returns
    /// `404 gift_not_found`, naming `id` in `param`, when no gift or pledge with that ID belongs
    /// to this institution. Send `dry_run` to check the change and see the result without saving it,
    /// and an `Idempotency-Key` header so a retry returns the first answer.
    /// </summary>
    WithRawResponseTask<GiftV1> UpdateAsync(
        UpdateGiftV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
