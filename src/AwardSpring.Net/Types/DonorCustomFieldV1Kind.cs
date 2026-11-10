using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(DonorCustomFieldV1Kind.DonorCustomFieldV1KindSerializer))]
[Serializable]
public readonly record struct DonorCustomFieldV1Kind : IStringEnum
{
    public static readonly DonorCustomFieldV1Kind Text = new(Values.Text);

    public static readonly DonorCustomFieldV1Kind Number = new(Values.Number);

    public static readonly DonorCustomFieldV1Kind Date = new(Values.Date);

    public static readonly DonorCustomFieldV1Kind SingleSelect = new(Values.SingleSelect);

    public static readonly DonorCustomFieldV1Kind MultipleSelect = new(Values.MultipleSelect);

    public static readonly DonorCustomFieldV1Kind Other = new(Values.Other);

    public DonorCustomFieldV1Kind(string value)
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
    public static DonorCustomFieldV1Kind FromCustom(string value)
    {
        return new DonorCustomFieldV1Kind(value);
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

    public static bool operator ==(DonorCustomFieldV1Kind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DonorCustomFieldV1Kind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DonorCustomFieldV1Kind value) => value.Value;

    public static explicit operator DonorCustomFieldV1Kind(string value) => new(value);

    internal class DonorCustomFieldV1KindSerializer : JsonConverter<DonorCustomFieldV1Kind>
    {
        public override DonorCustomFieldV1Kind Read(
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
            return new DonorCustomFieldV1Kind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DonorCustomFieldV1Kind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DonorCustomFieldV1Kind ReadAsPropertyName(
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
            return new DonorCustomFieldV1Kind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DonorCustomFieldV1Kind value,
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

        public const string Date = "date";

        public const string SingleSelect = "single_select";

        public const string MultipleSelect = "multiple_select";

        public const string Other = "other";
    }
}
