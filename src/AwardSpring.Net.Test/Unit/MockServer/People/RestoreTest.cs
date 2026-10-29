using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.People;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RestoreTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "first_name": "first_name",
              "last_name": "last_name",
              "email": "email",
              "role": "super_administrator",
              "roles": [
                "roles"
              ],
              "departments": [
                {
                  "id": "id",
                  "name": "name"
                }
              ],
              "is_archived": true,
              "permissions": [
                {
                  "category": "category",
                  "name": "name",
                  "enabled": true,
                  "items": [
                    {}
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/people/id/restore")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.People.RestoreAsync(new RestorePeopleRequest { Id = "id" });
        JsonAssert.AreEqual(response, mockResponse);
    }
}
