using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(PersonPermissionV1Access.PersonPermissionV1AccessSerializer))]
[Serializable]
public readonly record struct PersonPermissionV1Access : IStringEnum
{
    public static readonly PersonPermissionV1Access None = new(Values.None);

    public static readonly PersonPermissionV1Access View = new(Values.View);

    public static readonly PersonPermissionV1Access Edit = new(Values.Edit);

    public static readonly PersonPermissionV1Access No = new(Values.No);

    public static readonly PersonPermissionV1Access Yes = new(Values.Yes);

    public PersonPermissionV1Access(string value)
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
    public static PersonPermissionV1Access FromCustom(string value)
    {
        return new PersonPermissionV1Access(value);
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

    public static bool operator ==(PersonPermissionV1Access value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PersonPermissionV1Access value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PersonPermissionV1Access value) => value.Value;

    public static explicit operator PersonPermissionV1Access(string value) => new(value);

    internal class PersonPermissionV1AccessSerializer : JsonConverter<PersonPermissionV1Access>
    {
        public override PersonPermissionV1Access Read(
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
            return new PersonPermissionV1Access(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PersonPermissionV1Access value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PersonPermissionV1Access ReadAsPropertyName(
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
            return new PersonPermissionV1Access(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PersonPermissionV1Access value,
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
        public const string None = "none";

        public const string View = "view";

        public const string Edit = "edit";

        public const string No = "no";

        public const string Yes = "yes";
    }
}
