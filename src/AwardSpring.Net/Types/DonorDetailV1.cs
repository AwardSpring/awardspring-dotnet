using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record DonorDetailV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Stripe-style resource discriminator. Stable, snake_case string naming the resource type.
    /// Serialized first so it reads as the leading field of every V1 resource body.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("quick_stats")]
    public DonorQuickStatsV1? QuickStats { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Whether this is an individual donor or a donor organization: `Individual` or
    /// `Organization`. Mirrors the `role` field on the create request.
    /// </summary>
    [JsonPropertyName("role")]
    public DonorDetailV1Role? Role { get; set; }

    [JsonPropertyName("date_of_birth")]
    public int? DateOfBirth { get; set; }

    [JsonPropertyName("birth_month")]
    public string? BirthMonth { get; set; }

    [JsonPropertyName("birth_day")]
    public int? BirthDay { get; set; }

    [JsonPropertyName("birth_year")]
    public int? BirthYear { get; set; }

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

    [JsonPropertyName("organization_name")]
    public string? OrganizationName { get; set; }

    [JsonPropertyName("public_organization_name")]
    public string? PublicOrganizationName { get; set; }

    [JsonPropertyName("make_profile_private")]
    public bool? MakeProfilePrivate { get; set; }

    [JsonPropertyName("public_first_name")]
    public string? PublicFirstName { get; set; }

    [JsonPropertyName("public_last_name")]
    public string? PublicLastName { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("facebook_url")]
    public string? FacebookUrl { get; set; }

    [JsonPropertyName("twitter_url")]
    public string? TwitterUrl { get; set; }

    [JsonPropertyName("linked_in_url")]
    public string? LinkedInUrl { get; set; }

    [JsonPropertyName("photo_url")]
    public string? PhotoUrl { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("include_soft_credits")]
    public bool? IncludeSoftCredits { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
