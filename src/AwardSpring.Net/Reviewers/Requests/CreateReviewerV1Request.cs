using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record CreateReviewerV1Request
{
    /// <summary>
    /// The reviewer's first name. Required, at most 50 characters. Example: `"Pat"`.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The reviewer's last name. Required, at most 50 characters. Example: `"Lee"`.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// The reviewer's email, which is also how they sign in. Required, at most 50 characters, and not already
    /// used by any account at the institution, ignoring upper and lower case, unless `if_email_in_use` is
    /// `add_role`. Example: `"pat.lee@school.edu"`.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Optional. What to do when an account at the institution already has the email. `error`, the default,
    /// returns `400 email_already_exists`. `add_role` does what the Users list's Add user window does:
    /// the reviewer role is added to that account instead of making a second one. Any other value returns
    /// `400 validation_failed`.
    /// </summary>
    [JsonPropertyName("if_email_in_use")]
    public CreateReviewerV1RequestIfEmailInUse? IfEmailInUse { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
