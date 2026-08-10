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
              "data": [
                {
                  "id": 1,
                  "scholarship_id": 1,
                  "scholarship_name": "scholarship_name",
                  "fund_id": "fund_id",
                  "student_id": "student_id",
                  "first_name": "first_name",
                  "last_name": "last_name",
                  "email": "email",
                  "awarded_date": "2024-01-15T09:30:00.000Z",
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Scholarships.ListAwardedStudentsAsync(
            new ListAwardedStudentsScholarshipsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
