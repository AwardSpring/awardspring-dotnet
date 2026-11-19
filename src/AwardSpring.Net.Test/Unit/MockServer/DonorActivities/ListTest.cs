using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
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
              "total_count": 1,
              "complete_up_to": 1,
              "data": [
                {
                  "id": "id",
                  "donor_id": "donor_id",
                  "donor_name": "donor_name",
                  "source": "Logged",
                  "activity_type": "activity_type",
                  "subject": "subject",
                  "description": "description",
                  "date": 1,
                  "place": "place",
                  "amount": 1.1,
                  "fund_id": "fund_id",
                  "is_completed": true,
                  "gift_acknowledgement_sent": true,
                  "gift_type": "gift_type",
                  "campaign_id": "campaign_id",
                  "assigned_to_user_id": "assigned_to_user_id",
                  "sender_name": "sender_name"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/donorId/activities")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.DonorActivities.ListAsync(
            new ListDonorActivitiesRequest { DonorId = "donorId" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
