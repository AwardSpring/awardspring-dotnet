using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.ReviewerAssignments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetJobTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "status": "status",
              "review_group_id": "review_group_id",
              "review_group_name": "review_group_name",
              "award_cycle_id": "award_cycle_id",
              "award_cycle_name": "award_cycle_name",
              "status_url": "status_url",
              "total": 1,
              "done": 1,
              "added": 1,
              "removed": 1,
              "unchanged": 1,
              "finished_reviews_removed": 1,
              "turned_down": 1,
              "failed": 1,
              "notices": [
                "notices"
              ],
              "assignment_choice": "assignment_choice",
              "warning": "warning",
              "created_at": 1,
              "started_at": 1,
              "completed_at": 1,
              "rows_url": "rows_url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/reviewer-assignment-jobs/job_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ReviewerAssignments.GetJobAsync(
            new GetJobReviewerAssignmentsRequest { JobId = "job_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
