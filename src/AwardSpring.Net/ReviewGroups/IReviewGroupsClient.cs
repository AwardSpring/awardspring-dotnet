using AwardSpring.Net.Core;

namespace AwardSpring.Net;

public partial interface IReviewGroupsClient
{
    /// <summary>
    /// Returns the review groups of one award cycle, in the standard list envelope. `award_cycle_id` is
    /// required and is the award cycle's stored ID. Each group shows its stored ID, its name and its award cycle.
    /// An award cycle the institution does not have returns `404 award_cycle_not_found`.
    /// </summary>
    Task<Pager<ReviewGroupV1>> ListAsync(
        ListReviewGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
