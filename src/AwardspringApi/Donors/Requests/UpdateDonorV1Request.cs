using AwardspringApi.Core;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[Serializable]
public record UpdateDonorV1Request
{
    [JsonIgnore]
    public required int Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("organization")]
    public string? Organization { get; set; }

    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("county")]
    public string? County { get; set; }

    [JsonPropertyName("zip_code")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("country")]
    public int? Country { get; set; }

    [JsonPropertyName("job_title")]
    public string? JobTitle { get; set; }

    [JsonPropertyName("work_email")]
    public string? WorkEmail { get; set; }

    [JsonPropertyName("work_phone")]
    public string? WorkPhone { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("public_first_name")]
    public string? PublicFirstName { get; set; }

    [JsonPropertyName("public_last_name")]
    public string? PublicLastName { get; set; }

    [JsonPropertyName("public_organization_name")]
    public string? PublicOrganizationName { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("facebook_url")]
    public string? FacebookUrl { get; set; }

    [JsonPropertyName("twitter_url")]
    public string? TwitterUrl { get; set; }

    [JsonPropertyName("linked_in_url")]
    public string? LinkedInUrl { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("make_profile_private")]
    public bool? MakeProfilePrivate { get; set; }

    [JsonPropertyName("include_soft_credits")]
    public bool? IncludeSoftCredits { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
