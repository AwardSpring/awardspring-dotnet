using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.People;

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
              "total_count": 1,
              "data": [
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
                    {}
                  ],
                  "is_archived": true,
                  "permissions": [
                    {}
                  ]
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/people").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.People.ListAsync(new ListPeopleRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
