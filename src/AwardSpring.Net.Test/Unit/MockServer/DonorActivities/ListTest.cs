using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.DonorActivities;

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
                  "source": "Logged",
                  "activity_type": "activity_type",
                  "subject": "subject",
                  "description": "description",
                  "date": 1,
                  "amount": 1.1,
                  "fund_id": "fund_id",
                  "is_completed": true,
                  "gift_acknowledgement_sent": true,
                  "gift_type": "gift_type",
                  "campaign_id": 1,
                  "assigned_to_user_id": 1,
                  "sender_name": "sender_name"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/1/activities")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DonorActivities.ListAsync(
            new ListDonorActivitiesRequest { DonorId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
