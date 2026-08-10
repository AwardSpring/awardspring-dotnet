using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record CreateDonorV1Request
{
    /// <summary>
    /// Optional email address — donors may have no email on file, matching the admin UI. When
    /// provided it must be a valid email format, 250 characters or fewer, and not already in
    /// use by another user in the institution. Note that email-less creates get no duplicate
    /// protection from that uniqueness check, so retried requests should carry an
    /// `Idempotency-Key` header to avoid creating the same donor twice.
    /// </summary>
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

    /// <summary>
    /// Whether this is an individual donor or a donor organization. Defaults to
    /// `Individual` when omitted. Determines which name fields are required.
    /// </summary>
    [JsonPropertyName("role")]
    public CreateDonorV1RequestRole? Role { get; set; }

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
