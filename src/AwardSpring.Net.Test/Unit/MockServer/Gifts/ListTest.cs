using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
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
              "data": [
                {
                  "id": 1,
                  "donor_id": 1,
                  "type": "type",
                  "gift_type": "gift_type",
                  "amount": 1.1,
                  "subject": "subject",
                  "description": "description",
                  "fund_id": "fund_id",
                  "campaign_id": 1,
                  "is_completed": true,
                  "gift_acknowledgement_sent": true,
                  "date": 1,
                  "soft_credits": [
                    {}
                  ]
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

        var response = await Client.Gifts.ListAsync(new ListGiftsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
