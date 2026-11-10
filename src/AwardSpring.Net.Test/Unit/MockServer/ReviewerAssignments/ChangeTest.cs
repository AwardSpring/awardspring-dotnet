using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.ReviewerAssignments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ChangeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "review_group_id": "review_group_id",
              "review_group_name": "review_group_name",
              "award_cycle_id": "award_cycle_id",
              "award_cycle_name": "award_cycle_name",
              "panel": 1,
              "mode": "mode",
              "applied": true,
              "dry_run": true,
              "added": 1,
              "removed": 1,
              "unchanged": 1,
              "rejected": 1,
              "finished_reviews_removed": 1,
              "assignment_choice": "assignment_choice",
              "warning": "warning",
              "rows": [
                {
                  "index": 1,
                  "reviewer_id": "reviewer_id",
                  "reviewer_email": "reviewer_email",
                  "applicant_id": "applicant_id",
                  "applicant_email": "applicant_email",
                  "action": "action",
                  "status": "status",
                  "reason": "reason",
                  "message": "message"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/reviewer-assignments")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ReviewerAssignments.ChangeAsync(
            new ChangeReviewerAssignmentsV1Request()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
