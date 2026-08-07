using AwardspringApi;
using AwardspringApi.Test.Unit.MockServer;
using AwardspringApi.Test.Utils;
using NUnit.Framework;

namespace AwardspringApi.Test.Unit.MockServer.Funds;

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
                  "fund_id": "fund_id",
                  "remaining_balance": 1,
                  "fund_type": "fund_type",
                  "is_endowed": true
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/funds").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Funds.ListAsync(new ListFundsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
