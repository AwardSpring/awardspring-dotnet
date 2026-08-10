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
              "id": 1,
              "activity_type": "activity_type",
              "subject": "subject",
              "description": "description",
              "date": "2024-01-15T09:30:00.000Z",
              "amount": 1.1,
              "fund_id": "fund_id",
              "campaign_id": 1,
              "assigned_to_user_id": 1,
              "is_completed": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/1/activities")
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
            new CreateDonorActivityV1Request { DonorId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
