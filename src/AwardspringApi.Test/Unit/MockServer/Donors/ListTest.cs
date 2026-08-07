using AwardspringApi;
using AwardspringApi.Test.Unit.MockServer;
using AwardspringApi.Test.Utils;
using NUnit.Framework;

namespace AwardspringApi.Test.Unit.MockServer.Donors;

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
              "data": [
                {
                  "id": 1,
                  "first_name": "first_name",
                  "last_name": "last_name",
                  "email": "email",
                  "organization": "organization",
                  "phone": "phone",
                  "role": "Individual"
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/donors").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Donors.ListAsync(new ListDonorsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
