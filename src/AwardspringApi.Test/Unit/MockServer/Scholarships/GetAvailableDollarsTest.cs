using AwardspringApi;
using AwardspringApi.Test.Unit.MockServer;
using AwardspringApi.Test.Utils;
using NUnit.Framework;

namespace AwardspringApi.Test.Unit.MockServer.Scholarships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAvailableDollarsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": 1,
              "name": "name",
              "total_funds": 1.1,
              "total_awarded_amount": 1.1,
              "total_amount_remaining": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/scholarships/1/available-dollars")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Scholarships.GetAvailableDollarsAsync(
            new GetAvailableDollarsScholarshipsRequest { ScholarshipId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
