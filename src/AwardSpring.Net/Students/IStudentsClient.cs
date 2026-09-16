namespace AwardSpring.Net;

public partial interface IStudentsClient
{
    /// <summary>
    /// Returns one page at a time, covering every student account at the institution — both
    /// registered and prospective. Search with `q`: it splits on spaces and matches each
    /// term against first name, last name, or email. Filter with `student_id` to look a
    /// student up by the number the institution assigned; numbers are not guaranteed unique, so
    /// the match can return more than one student.
    /// </summary>
    WithRawResponseTask<StudentV1ListResponse> ListAsync(
        ListStudentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches one student by their AwardSpring identifier — the `id` from the students
    /// list. Returns `404 student_not_found` if no such student belongs to this institution.
    /// </summary>
    WithRawResponseTask<StudentV1> GetAsync(
        GetStudentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
