using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Scholarships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "total_amount": 1.1,
              "is_active": true,
              "award_cycle_id": "award_cycle_id",
              "application_start_date": 1,
              "application_end_date": 1,
              "department_id": "department_id",
              "fund_id": "fund_id",
              "donor_ids": [
                "donor_ids"
              ],
              "description": "description",
              "award_notification": {
                "subject": "subject",
                "body": "body"
              },
              "custom_fields": [
                {
                  "id": "id",
                  "name": "name",
                  "type": "text",
                  "value": "value",
                  "values": [
                    "values"
                  ]
                }
              ],
              "qualification_groups": [
                {
                  "group_number": 1,
                  "rules": [
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
                    .WithPath("/api/v1/scholarships/scholarshipId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Scholarships.GetAsync(
            new GetScholarshipsRequest { ScholarshipId = "scholarshipId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
