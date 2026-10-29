using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(CreateStudentV1RequestIfEmailInUse.CreateStudentV1RequestIfEmailInUseSerializer)
)]
[Serializable]
public readonly record struct CreateStudentV1RequestIfEmailInUse : IStringEnum
{
    public static readonly CreateStudentV1RequestIfEmailInUse Error = new(Values.Error);

    public static readonly CreateStudentV1RequestIfEmailInUse AddRole = new(Values.AddRole);

    public CreateStudentV1RequestIfEmailInUse(string value)
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
    public static CreateStudentV1RequestIfEmailInUse FromCustom(string value)
    {
        return new CreateStudentV1RequestIfEmailInUse(value);
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

    public static bool operator ==(CreateStudentV1RequestIfEmailInUse value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateStudentV1RequestIfEmailInUse value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateStudentV1RequestIfEmailInUse value) => value.Value;

    public static explicit operator CreateStudentV1RequestIfEmailInUse(string value) => new(value);

    internal class CreateStudentV1RequestIfEmailInUseSerializer
        : JsonConverter<CreateStudentV1RequestIfEmailInUse>
    {
        public override CreateStudentV1RequestIfEmailInUse Read(
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
            return new CreateStudentV1RequestIfEmailInUse(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateStudentV1RequestIfEmailInUse value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateStudentV1RequestIfEmailInUse ReadAsPropertyName(
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
            return new CreateStudentV1RequestIfEmailInUse(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateStudentV1RequestIfEmailInUse value,
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
        public const string Error = "error";

        public const string AddRole = "add_role";
    }
}
