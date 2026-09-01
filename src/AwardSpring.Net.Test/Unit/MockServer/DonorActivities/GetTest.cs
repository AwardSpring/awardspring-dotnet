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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/1/activities/1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DonorActivities.GetAsync(
            new GetDonorActivitiesRequest { DonorId = 1, ActivityId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
