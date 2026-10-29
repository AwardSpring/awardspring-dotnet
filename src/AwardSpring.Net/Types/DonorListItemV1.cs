using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record DonorListItemV1 : IJsonOnDeserialized
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

    /// <summary>
    /// The donor's stored ID: 9 characters, sent exactly as stored.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("organization")]
    public string? Organization { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Whether this is an individual donor or a donor organization: `Individual` or
    /// `Organization`. Mirrors the `role` field on the create request.
    /// </summary>
    [JsonPropertyName("role")]
    public DonorListItemV1Role? Role { get; set; }

    /// <summary>
    /// The donor's level: `Annual`, `Mid`, `Major` or `Principal`. It is the
    /// level the institution's donor portal shows this donor, worked out from the total of every
    /// gift recorded for them: under $1,000 is `Annual`, from $1,000 is `Mid`, from
    /// $25,000 is `Major` and from $1,000,000 is `Principal`. When staff have set or held
    /// the donor's level by hand, that level is shown instead. Null when the request is made as a
    /// signed-in user who may not see donors' giving.
    /// </summary>
    [JsonPropertyName("level")]
    public DonorListItemV1Level? Level { get; set; }

    /// <summary>
    /// When the donor was last contacted: the date of the newest email, phone call, meeting or
    /// note logged with them before today, in the institution's time zone. Gifts, pledges and
    /// emails sent by AwardSpring do not count. Null when no contact has been logged.
    /// </summary>
    [JsonPropertyName("last_contacted_at")]
    public int? LastContactedAt { get; set; }

    /// <summary>
    /// The donor's lifetime giving, the same figure the donor's page in AwardSpring shows: every
    /// gift recorded for them up to now, plus their soft credits when their record is set to
    /// include soft credits. `0` for a donor with no gifts. Null when the request is made as
    /// a signed-in user who may not see donors' giving.
    /// </summary>
    [JsonPropertyName("lifetime_giving")]
    public double? LifetimeGiving { get; set; }

    /// <summary>
    /// The donor's giving status: `Recurring`, `New` or `Lapsed`.
    /// `Recurring` means the donor has a recurring gift that is still running (it has not been
    /// cancelled or stopped, and its end date, if it has one, has not arrived) and at least one
    /// payment from it has gone through. Otherwise the donor's gift dates decide: `New` means
    /// their first gift was in the last 12 months, and `Lapsed` means their last gift was more
    /// than 12 months ago. The 12 months count back from the moment of the request, not from the
    /// start of a fiscal year. A donor who fits more than one is `Recurring` before `New`,
    /// and `New` before `Lapsed`. Null for a donor who has never given, or whose first gift
    /// was more than 12 months ago and who has given again within the last 12 months. Also null
    /// when the request is made as a signed-in user who may not see donors' giving.
    /// </summary>
    [JsonPropertyName("giving_status")]
    public DonorListItemV1GivingStatus? GivingStatus { get; set; }

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
