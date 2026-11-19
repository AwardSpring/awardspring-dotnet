using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.AwardCycles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
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
                  "is_current": true,
                  "is_next": true,
                  "application_start_date": 1,
                  "application_end_date": 1,
                  "review_start_date": 1,
                  "review_end_date": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/award-cycles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.AwardCycles.ListAsync(new ListAwardCyclesRequest());
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
