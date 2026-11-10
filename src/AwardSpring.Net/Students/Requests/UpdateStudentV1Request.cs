using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record UpdateStudentV1Request
{
    /// <summary>
    /// The student's id, as the students list returns it.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The student's new first name, at most 250 characters. It cannot be blank: an empty value is refused rather
    /// than clearing the name. Example: `"Jordan"`.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The student's new last name, at most 250 characters. It cannot be blank: an empty value is refused rather
    /// than clearing the name. Example: `"Ellis"`.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// The student's new email, which is also how they sign in. It must be a well-formed email of at most 250
    /// characters, and not used by any other account at the institution, ignoring upper and lower case, including
    /// an archived one; otherwise this returns `400 email_already_exists`. It cannot be blank. No email is
    /// sent to the student about the change. Example: `"jordan.ellis@school.edu"`.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The new student number the institution assigned (for example an SIS or campus id), at most 250 characters,
    /// and not already on another account at the institution. An empty string clears it.
    /// Example: `"20260142"`.
    /// </summary>
    [JsonPropertyName("student_id")]
    public string? StudentId { get; set; }

    /// <summary>
    /// The student's new phone number. Everything except digits and `+` is removed before it is saved, and
    /// what remains can be at most 100 characters. An empty string clears it. Example: `"+1 (555) 123-4567"`,
    /// saved as `"+15551234567"`.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
