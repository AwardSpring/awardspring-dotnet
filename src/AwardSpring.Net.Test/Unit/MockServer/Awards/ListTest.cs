using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Awards;

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
                  "award_code": "award_code",
                  "user_id": "user_id",
                  "scholarship_id": "scholarship_id",
                  "scholarship_name": "scholarship_name",
                  "award_cycle_id": "award_cycle_id",
                  "award_cycle_name": "award_cycle_name",
                  "awarded_date": 1,
                  "awarded_amount": 1.1
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/awards").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Awards.ListAsync(new ListAwardsRequest());
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
