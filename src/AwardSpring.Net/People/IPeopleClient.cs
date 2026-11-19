using AwardSpring.Net.Core;

namespace AwardSpring.Net;

public partial interface IPeopleClient
{
    /// <summary>
    /// Archives the account of a student or reviewer at the institution your API key is issued for. The person
    /// cannot sign in until the account is restored; their applications, reviews and everything else are kept.
    /// An API key can archive students and reviewers only: a person who holds any other role, such as an
    /// administrator or a donor, returns `400 validation_failed`, and is archived in AwardSpring instead.
    /// Archiving a person who is already archived changes nothing and returns the person. The archive is
    /// recorded under your API key. An `id` that names no person at the institution returns
    /// `404 person_not_found`, naming `id` in `param`.
    /// </summary>
    WithRawResponseTask<PersonV1> ArchiveAsync(
        ArchivePeopleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores the archived account of a student or reviewer at the institution your API key is issued for, so
    /// the person can sign in again. An API key can restore students and reviewers only: a person who holds any
    /// other role returns `400 validation_failed`, and is restored in AwardSpring instead. Restoring a person
    /// who is not archived changes nothing and returns the person. An `id` that names no person at the
    /// institution returns `404 person_not_found`, naming `id` in `param`.
    /// </summary>
    WithRawResponseTask<PersonV1> RestoreAsync(
        RestorePeopleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the people the institution's Users list shows, for the institution your API key is issued
    /// for, in the standard list envelope (`object: "list"`, `has_more`, `next_cursor`,
    /// `previous_cursor`, `data`). Each person carries their roles, the departments an
    /// administrator is limited to, whether the account is archived, and an administrator's permissions.
    /// Page forward by passing the returned `next_cursor` as `starting_after`. `limit`
    /// defaults to 25 and is capped at 100. Results are ordered by id ascending.
    ///
    ///
    /// Filter with `?role=` (`administrators`, `reviewers`, `students` or
    /// `donors`), `?q=` (part of a name, the start of an email address or student number, or an
    /// exact id) and `?status=` (`all`, `active` or `archived`; archived accounts are
    /// listed by default, as on the Users list).
    /// </summary>
    Task<Pager<PersonV1>> ListAsync(
        ListPeopleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
