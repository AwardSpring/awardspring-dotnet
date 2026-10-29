namespace AwardSpring.Net;

public partial interface IDonorsClient
{
    /// <summary>
    /// Returns one page at a time. With no `sort` and no `q`, donors are listed by
    /// `id`, lowest first.
    ///
    ///
    /// Sort with `sort`. `name` lists donors A to Z, ignoring case: an organization by its
    /// organization name, and a person by last name, then first name. A person with no last name
    /// is listed by first name, and a donor with no name at all comes last. `last_contacted`
    /// lists the most recently contacted donors first, by `last_contacted_at`; donors who
    /// have never been contacted come last. Donors who tie are listed by `id`: lowest first
    /// for `name`, highest first for `last_contacted`.
    ///
    ///
    /// Narrow the list with `level` to donors at one or more levels, for example
    /// `level=major,principal`. A donor's level comes from their giving, so a request made as
    /// a signed-in user who may not see donors' giving returns `403 permission_denied` when
    /// it filters by level. Sorting is open to everyone who can list donors.
    ///
    ///
    /// Narrow the list with `giving_status` to donors with one or more giving statuses, for
    /// example `giving_status=recurring,new`. `Recurring`: the donor has a recurring gift
    /// that is still running (not cancelled or stopped, and not past its end date) and at least one
    /// payment from it has gone through. `New`: the donor's first gift was in the last 12
    /// months. `Lapsed`: the donor's last gift was more than 12 months ago. The 12 months count
    /// back from now, not from the start of a fiscal year. A donor who fits more than one takes the
    /// first of `Recurring`, `New`, `Lapsed`. A donor who has never given has no giving
    /// status, and neither does one whose first gift was more than 12 months ago and who has given
    /// again within the last 12 months. With `level` as well, a donor must match both. A
    /// request made as a signed-in user who may not see donors' giving returns
    /// `403 permission_denied` when it filters by giving status.
    ///
    ///
    /// Search with `q` (at least `2` characters). Every word you type must match the
    /// start of a word in the donor's first name, last name or organization, or the start of
    /// their email address, so `jane smi` finds Jane Smith. Matches inside a word are not
    /// found: `co` finds `Coworking` but not `Waco`. Where digits and letters
    /// touch, a word is also split there, so `25co` finds `25N Coworking`.
    ///
    ///
    /// Without `sort`, search results come in three groups: first, donors whose full name or
    /// organization starts with the search (for a search with no spaces, compared with the spaces
    /// taken out, so `janesmith` finds Jane Smith); next, donors where every word starts a
    /// word in their name or organization; last, donors matched only through their email address.
    /// Within a group, donors are listed by `id`, lowest first, so the order holds from one
    /// page to the next. With `sort`, the search only decides which donors are listed and
    /// the sort decides their order.
    ///
    /// `sort`, `level`, `giving_status` and `q` work together. Send the same ones
    /// on every page: a cursor sent with a different `sort`, `level`, `giving_status`
    /// or `q` returns `400 invalid_cursor`. A search shorter than `2` characters, or an
    /// unknown `level`, `giving_status` or `sort`, returns `400 validation_failed`
    /// with `param` set to the parameter at fault.
    ///
    ///
    /// Assistant capability: `springiq_list_donors`. Required permission: Donors (applies when called on behalf of a signed-in person).
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
    ///
    /// Assistant capability: `springiq_create_donor`. Required permission: Donors (applies when called on behalf of a signed-in person).
    /// </summary>
    WithRawResponseTask<DonorV1> CreateAsync(
        CreateDonorV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Includes giving totals for the donor's lifetime and the current year, their most recent
    /// gift, and their notes. `id` is the donor's stored ID. Returns `404 donor_not_found`
    /// naming `id` if no such donor belongs to this institution.
    ///
    /// Assistant capability: `springiq_get_donor_profile`. Required permission: Donors (applies when called on behalf of a signed-in person).
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
    /// Replaces the donor's free-text notes. `id` is the donor's stored ID. Returns
    /// `404 donor_not_found` naming `id` if no such donor belongs to this institution.
    /// </summary>
    WithRawResponseTask<DonorNotesV1> UpdateNotesAsync(
        UpdateDonorNotesV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
