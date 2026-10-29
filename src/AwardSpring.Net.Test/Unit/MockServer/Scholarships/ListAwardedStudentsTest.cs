using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Scholarships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListAwardedStudentsTest : BaseMockServerTest
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
                  "id": "id",
                  "award_code": "award_code",
                  "scholarship_id": "scholarship_id",
                  "scholarship_name": "scholarship_name",
                  "fund_id": "fund_id",
                  "student_id": "student_id",
                  "first_name": "first_name",
                  "last_name": "last_name",
                  "email": "email",
                  "awarded_date": 1,
                  "awarded_amount": 1.1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/scholarships/awarded-students")
                    .WithParam("award_cycle_id", "award_cycle_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Scholarships.ListAwardedStudentsAsync(
            new ListAwardedStudentsScholarshipsRequest { AwardCycleId = "award_cycle_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
