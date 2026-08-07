using AwardspringApi;
using AwardspringApi.Test.Unit.MockServer;
using AwardspringApi.Test.Utils;
using NUnit.Framework;

namespace AwardspringApi.Test.Unit.MockServer.Donors;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateNotesTest : BaseMockServerTest
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
              "notes": "notes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/1/notes")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Donors.UpdateNotesAsync(
            new UpdateDonorNotesV1Request { Id = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
