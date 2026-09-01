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
              "application_start_date": 1,
              "application_end_date": 1,
              "review_start_date": 1,
              "review_end_date": 1
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
