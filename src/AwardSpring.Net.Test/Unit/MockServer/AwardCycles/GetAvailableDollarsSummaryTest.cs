using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.AwardCycles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAvailableDollarsSummaryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "award_cycle_id": "award_cycle_id",
              "scholarship_count": 1,
              "total_funds": 1.1,
              "total_awarded_amount": 1.1,
              "total_amount_remaining": 1.1,
              "over_awarded_scholarship_count": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/award-cycles/awardCycleId/available-dollars-summary")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AwardCycles.GetAvailableDollarsSummaryAsync(
            new GetAvailableDollarsSummaryAwardCyclesRequest { AwardCycleId = "awardCycleId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
