using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Gifts;

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
                  "donor_id": "donor_id",
                  "type": "type",
                  "gift_type": "gift_type",
                  "amount": 1.1,
                  "subject": "subject",
                  "description": "description",
                  "fund_id": "fund_id",
                  "campaign_id": "campaign_id",
                  "is_completed": true,
                  "gift_acknowledgement_sent": true,
                  "date": 1,
                  "soft_credits": [
                    {}
                  ],
                  "last_changed_at": 1,
                  "deleted": true,
                  "removed_at": 1
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/gifts").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Gifts.ListAsync(new ListGiftsRequest());
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
