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

    /// <summary>
    /// The names of the tags on this donor, in the order the institution lists its tags. Empty when the donor has
    /// none.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// The institution's donor custom fields that apply to this kind of donor (individual or organization), in the
    /// order the institution lists them, each with this donor's answer. A field the donor has not answered is
    /// included with no answer.
    /// </summary>
    [JsonPropertyName("custom_fields")]
    public IEnumerable<DonorCustomFieldV1>? CustomFields { get; set; }

    /// <summary>
    /// The kinds of email this donor is opted out of: by their own unsubscribe or spam complaint, by the institution,
    /// or by the platform after their address bounced, as AwardSpring's donor page shows them. Each is one of
    /// `campaign`, `newsletter`, `event_invitations` or `giving_renewal_asks`; more may be
    /// added, so ignore a value you do not recognize. Receipts, thank-you letters and impact reports are always
    /// sent and never appear. Empty when the donor has opted out of nothing.
    /// </summary>
    [JsonPropertyName("email_opt_outs")]
    public IEnumerable<string>? EmailOptOuts { get; set; }

    /// <summary>
    /// The donor's stored ID: 9 characters, sent exactly as stored. A dry-run create returns
    /// `null`, because no donor was saved.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

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

    /// <summary>
    /// Whether the donor's record is archived, the way AwardSpring shows it. `true` when the
    /// account is not active, or when the person is a donor only through an extra Donor role and that role
    /// is archived; `false` for an active donor, and again once the donor is restored. Archiving and
    /// restoring each move `last_changed_at`, so a donors list requested with `changed_since`
    /// lists an archived donor marked `true` and a restored one marked `false`; archiving never
    /// removes a donor from that list.
    /// </summary>
    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

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

    /// <summary>
    /// When anything stored on the donor that the API returns last changed, in UTC epoch seconds: their
    /// name, contact details, profile, whether their donor record is archived, the tags on them, their answers
    /// to the school's donor custom fields, or which kinds of email they are opted out of. Renaming a tag, a
    /// custom field or one of its choices does not count, because it changes the school's list, not the
    /// donor. Adding the donor counts as
    /// a change; their gifts and pledges do not. Null only on a dry-run create, because no donor was saved.
    /// Use it with the donors list's `changed_since` to pick up only the donors that changed.
    /// </summary>
    [JsonPropertyName("last_changed_at")]
    public int? LastChangedAt { get; set; }

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
