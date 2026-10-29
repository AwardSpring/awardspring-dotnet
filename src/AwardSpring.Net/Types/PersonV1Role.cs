using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(PersonV1Role.PersonV1RoleSerializer))]
[Serializable]
public readonly record struct PersonV1Role : IStringEnum
{
    public static readonly PersonV1Role SuperAdministrator = new(Values.SuperAdministrator);

    public static readonly PersonV1Role Administrator = new(Values.Administrator);

    public static readonly PersonV1Role DepartmentAdmin = new(Values.DepartmentAdmin);

    public static readonly PersonV1Role Reviewer = new(Values.Reviewer);

    public static readonly PersonV1Role Student = new(Values.Student);

    public static readonly PersonV1Role Recommender = new(Values.Recommender);

    public static readonly PersonV1Role Donor = new(Values.Donor);

    public static readonly PersonV1Role Organization = new(Values.Organization);

    public static readonly PersonV1Role ClientServiceAdmin = new(Values.ClientServiceAdmin);

    public static readonly PersonV1Role AwardspringStaff = new(Values.AwardspringStaff);

    public PersonV1Role(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static PersonV1Role FromCustom(string value)
    {
        return new PersonV1Role(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(PersonV1Role value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PersonV1Role value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PersonV1Role value) => value.Value;

    public static explicit operator PersonV1Role(string value) => new(value);

    internal class PersonV1RoleSerializer : JsonConverter<PersonV1Role>
    {
        public override PersonV1Role Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new PersonV1Role(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PersonV1Role value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PersonV1Role ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new PersonV1Role(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PersonV1Role value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SuperAdministrator = "super_administrator";

        public const string Administrator = "administrator";

        public const string DepartmentAdmin = "department_admin";

        public const string Reviewer = "reviewer";

        public const string Student = "student";

        public const string Recommender = "recommender";

        public const string Donor = "donor";

        public const string Organization = "organization";

        public const string ClientServiceAdmin = "client_service_admin";

        public const string AwardspringStaff = "awardspring_staff";
    }
}
