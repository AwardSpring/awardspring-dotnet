using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Scholarships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListAvailableDollarsTest : BaseMockServerTest
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
              "complete_up_to": 1,
              "data": [
                {
                  "id": "id",
                  "name": "name",
                  "total_funds": 1.1,
                  "total_awarded_amount": 1.1,
                  "total_amount_remaining": 1.1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/scholarships/available-dollars")
                    .WithParam("award_cycle_id", "award_cycle_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Scholarships.ListAvailableDollarsAsync(
            new ListAvailableDollarsScholarshipsRequest { AwardCycleId = "award_cycle_id" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
