using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.ReviewerAssignments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListJobRowsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "url": "url",
              "has_more": true,
              "next_cursor": "next_cursor",
              "previous_cursor": "previous_cursor",
              "total_count": 1,
              "data": [
                {
                  "index": 1,
                  "reviewer_email": "reviewer_email",
                  "applicant_email": "applicant_email",
                  "action": "action",
                  "status": "status",
                  "message": "message"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/reviewer-assignment-job-rows")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ReviewerAssignments.ListJobRowsAsync(
            new ListJobRowsReviewerAssignmentsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
