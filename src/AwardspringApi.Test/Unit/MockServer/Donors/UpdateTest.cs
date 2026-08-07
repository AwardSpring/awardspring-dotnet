using AwardspringApi;
using AwardspringApi.Test.Unit.MockServer;
using AwardspringApi.Test.Utils;
using NUnit.Framework;

namespace AwardspringApi.Test.Unit.MockServer.Donors;

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
              "id": 1,
              "first_name": "first_name",
              "last_name": "last_name",
              "email": "email",
              "phone": "phone",
              "role": "Individual",
              "date_of_birth": "2024-01-15T09:30:00.000Z",
              "birth_month": "birth_month",
              "birth_day": 1,
              "birth_year": 1,
              "address1": "address1",
              "address2": "address2",
              "city": "city",
              "state": "state",
              "county": "county",
              "zip_code": "zip_code",
              "country": 1,
              "job_title": "job_title",
              "work_email": "work_email",
              "work_phone": "work_phone",
              "company_name": "company_name",
              "organization_name": "organization_name",
              "public_organization_name": "public_organization_name",
              "make_profile_private": true,
              "public_first_name": "public_first_name",
              "public_last_name": "public_last_name",
              "website": "website",
              "facebook_url": "facebook_url",
              "twitter_url": "twitter_url",
              "linked_in_url": "linked_in_url",
              "photo_url": "photo_url",
              "description": "description",
              "notes": "notes",
              "include_soft_credits": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/donors/1")
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

        var response = await Client.Donors.UpdateAsync(new UpdateDonorV1Request { Id = 1 });
        JsonAssert.AreEqual(response, mockResponse);
    }
}
