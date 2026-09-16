using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One student account at the institution.
/// </summary>
[Serializable]
public record StudentV1 : IJsonOnDeserialized
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
    /// AwardSpring's identifier for the student's user record. Use it with `GET /api/v1/students/{id}` and as the `user_id` filter on the applications and awards lists.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The student number the institution assigned (for example an SIS or campus id). Not
    /// guaranteed unique — two student accounts can carry the same number — and may be empty
    /// when the institution has not recorded one.
    /// </summary>
    [JsonPropertyName("student_id")]
    public string? StudentId { get; set; }

    /// <summary>
    /// The student's enrollment standing with the institution: `registered` (an active
    /// student account) or `prospective` (added ahead of enrollment, e.g. a recruit).
    /// </summary>
    [JsonPropertyName("enrollment_status")]
    public string? EnrollmentStatus { get; set; }

    /// <summary>
    /// When the student account was created, as UTC epoch seconds.
    /// </summary>
    [JsonPropertyName("created_date")]
    public int? CreatedDate { get; set; }

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
