using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.DonorActivities;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "id": "id",
              "activity_type": "activity_type",
              "subject": "subject",
              "description": "description",
              "date": 1,
              "place": "place",
              "amount": 1.1,
              "fund_id": "fund_id",
              "campaign_id": "campaign_id",
              "assigned_to_user_id": "assigned_to_user_id",
              "is_completed": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/donorId/activities")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DonorActivities.CreateAsync(
            new CreateDonorActivityV1Request { DonorId = "donorId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
