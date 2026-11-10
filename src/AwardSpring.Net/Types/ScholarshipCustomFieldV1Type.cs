using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(ScholarshipCustomFieldV1Type.ScholarshipCustomFieldV1TypeSerializer))]
[Serializable]
public readonly record struct ScholarshipCustomFieldV1Type : IStringEnum
{
    public static readonly ScholarshipCustomFieldV1Type Text = new(Values.Text);

    public static readonly ScholarshipCustomFieldV1Type Number = new(Values.Number);

    public static readonly ScholarshipCustomFieldV1Type OneChoice = new(Values.OneChoice);

    public static readonly ScholarshipCustomFieldV1Type MultipleChoice = new(Values.MultipleChoice);

    public ScholarshipCustomFieldV1Type(string value)
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
    public static ScholarshipCustomFieldV1Type FromCustom(string value)
    {
        return new ScholarshipCustomFieldV1Type(value);
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

    public static bool operator ==(ScholarshipCustomFieldV1Type value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScholarshipCustomFieldV1Type value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScholarshipCustomFieldV1Type value) => value.Value;

    public static explicit operator ScholarshipCustomFieldV1Type(string value) => new(value);

    internal class ScholarshipCustomFieldV1TypeSerializer
        : JsonConverter<ScholarshipCustomFieldV1Type>
    {
        public override ScholarshipCustomFieldV1Type Read(
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
            return new ScholarshipCustomFieldV1Type(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScholarshipCustomFieldV1Type value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScholarshipCustomFieldV1Type ReadAsPropertyName(
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
            return new ScholarshipCustomFieldV1Type(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScholarshipCustomFieldV1Type value,
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
        public const string Text = "text";

        public const string Number = "number";

        public const string OneChoice = "one_choice";

        public const string MultipleChoice = "multiple_choice";
    }
}
