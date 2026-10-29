using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Scholarships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAvailableDollarsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "total_funds": 1.1,
              "total_awarded_amount": 1.1,
              "total_amount_remaining": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/scholarships/scholarshipId/available-dollars")
                    .WithParam("award_cycle_id", "award_cycle_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Scholarships.GetAvailableDollarsAsync(
            new GetAvailableDollarsScholarshipsRequest
            {
                ScholarshipId = "scholarshipId",
                AwardCycleId = "award_cycle_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
