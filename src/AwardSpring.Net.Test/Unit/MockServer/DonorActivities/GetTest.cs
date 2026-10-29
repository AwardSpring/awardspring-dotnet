using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.DonorActivities;

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
              "campaign_id": "campaign_id",
              "assigned_to_user_id": "assigned_to_user_id",
              "sender_name": "sender_name"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/donorId/activities/activityId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DonorActivities.GetAsync(
            new GetDonorActivitiesRequest { DonorId = "donorId", ActivityId = "activityId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
