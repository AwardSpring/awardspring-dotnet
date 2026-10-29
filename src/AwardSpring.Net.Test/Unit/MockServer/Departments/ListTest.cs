using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Departments;

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
                  "name": "name",
                  "scholarship_count": 1,
                  "admin_count": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/departments").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Departments.ListAsync(new ListDepartmentsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
