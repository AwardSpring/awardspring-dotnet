using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// One person with an account at the institution, as the institution's Users list shows them.
/// </summary>
[Serializable]
public record PersonV1 : IJsonOnDeserialized
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
    /// The stored ID of the person's user record.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The person's main role: `super_administrator`, `administrator`, `department_admin`,
    /// `reviewer`, `student`, `recommender`, `donor`, `organization` or
    /// `client_service_admin`.
    /// </summary>
    [JsonPropertyName("role")]
    public PersonV1Role? Role { get; set; }

    /// <summary>
    /// Every role the person holds: the main role first, then any other role on the same account.
    /// </summary>
    [JsonPropertyName("roles")]
    public IEnumerable<string>? Roles { get; set; }

    /// <summary>
    /// The departments an administrator is limited to. An administrator with departments works only with what
    /// belongs to those departments. An empty list means the person is not limited to departments, except for a
    /// `department_admin`, who is always limited and reaches no department until one is listed here.
    /// </summary>
    [JsonPropertyName("departments")]
    public IEnumerable<PersonDepartmentV1>? Departments { get; set; }

    /// <summary>
    /// True when the account is archived: the person cannot sign in until it is restored.
    /// </summary>
    [JsonPropertyName("is_archived")]
    public bool? IsArchived { get; set; }

    /// <summary>
    /// What the administrator may use, as their Permissions tab shows it. Null for anyone the Permissions tab
    /// does not manage: Super Administrators, people who are not administrators, and every person at an
    /// institution where all administrators have full access.
    /// </summary>
    [JsonPropertyName("permissions")]
    public IEnumerable<PersonPermissionCategoryV1>? Permissions { get; set; }

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
