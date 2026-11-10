using AwardSpring.Net;
using AwardSpring.Net.Test.Unit.MockServer;
using AwardSpring.Net.Test.Utils;
using NUnit.Framework;

namespace AwardSpring.Net.Test.Unit.MockServer.Scholarships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
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
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Scholarships.UpdateAsync(
            new UpdateScholarshipV1Request { ScholarshipId = "scholarshipId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
