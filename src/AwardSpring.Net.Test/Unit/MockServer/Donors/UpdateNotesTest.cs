using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Donors;

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
              "id": "id",
              "notes": "notes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/id/notes")
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
            new UpdateDonorNotesV1Request { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
