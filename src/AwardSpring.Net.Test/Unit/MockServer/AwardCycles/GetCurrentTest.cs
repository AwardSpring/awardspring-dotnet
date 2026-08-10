using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.AwardCycles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCurrentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": 1,
              "name": "name",
              "is_current": true,
              "is_next": true,
              "application_start_date": "2024-01-15T09:30:00.000Z",
              "application_end_date": "2024-01-15T09:30:00.000Z",
              "review_start_date": "2024-01-15T09:30:00.000Z",
              "review_end_date": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/award-cycles/current")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AwardCycles.GetCurrentAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
