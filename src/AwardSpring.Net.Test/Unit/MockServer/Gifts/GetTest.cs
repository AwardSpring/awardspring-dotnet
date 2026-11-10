using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Gifts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
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
                {
                  "name": "name",
                  "user_id": "user_id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/gifts/id").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Gifts.GetAsync(new GetGiftsRequest { Id = "id" });
        JsonAssert.AreEqual(response, mockResponse);
    }
}
