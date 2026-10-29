using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record CreateStudentV1Request
{
    /// <summary>
    /// The student's first name. Required, at most 50 characters. Example: `"Jordan"`.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The student's last name. Required, at most 50 characters. Example: `"Ellis"`.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// The student's email, which is also how they sign in. Required, at most 50 characters, and not already
    /// used by any account at the institution, ignoring upper and lower case, unless `if_email_in_use` is
    /// `add_role`. Example: `"jordan.ellis@school.edu"`.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Optional. The student number the institution assigned (for example an SIS or campus id), at most 50
    /// characters, and not already on another account at the institution. Example: `"20260142"`.
    /// </summary>
    [JsonPropertyName("student_id")]
    public string? StudentId { get; set; }

    /// <summary>
    /// Optional. What to do when an account at the institution already has the email. `error`, the default,
    /// returns `400 email_already_exists`. `add_role` does what the Users list's Add user window does:
    /// the student role is added to that account instead of making a second one. Any other value returns
    /// `400 validation_failed`.
    /// </summary>
    [JsonPropertyName("if_email_in_use")]
    public CreateStudentV1RequestIfEmailInUse? IfEmailInUse { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
