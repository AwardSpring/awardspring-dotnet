using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Donors;

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
                  "organization": "organization",
                  "phone": "phone",
                  "role": "Individual",
                  "level": "Annual",
                  "last_contacted_at": 1,
                  "lifetime_giving": 1.1,
                  "giving_status": "Recurring"
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
