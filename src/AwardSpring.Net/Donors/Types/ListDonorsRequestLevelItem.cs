using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(ListDonorsRequestLevelItem.ListDonorsRequestLevelItemSerializer))]
[Serializable]
public readonly record struct ListDonorsRequestLevelItem : IStringEnum
{
    public static readonly ListDonorsRequestLevelItem Annual = new(Values.Annual);

    public static readonly ListDonorsRequestLevelItem Mid = new(Values.Mid);

    public static readonly ListDonorsRequestLevelItem Major = new(Values.Major);

    public static readonly ListDonorsRequestLevelItem Principal = new(Values.Principal);

    public ListDonorsRequestLevelItem(string value)
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
    public static ListDonorsRequestLevelItem FromCustom(string value)
    {
        return new ListDonorsRequestLevelItem(value);
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

    public static bool operator ==(ListDonorsRequestLevelItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDonorsRequestLevelItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDonorsRequestLevelItem value) => value.Value;

    public static explicit operator ListDonorsRequestLevelItem(string value) => new(value);

    internal class ListDonorsRequestLevelItemSerializer : JsonConverter<ListDonorsRequestLevelItem>
    {
        public override ListDonorsRequestLevelItem Read(
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
            return new ListDonorsRequestLevelItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDonorsRequestLevelItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDonorsRequestLevelItem ReadAsPropertyName(
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
            return new ListDonorsRequestLevelItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDonorsRequestLevelItem value,
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
        public const string Annual = "Annual";

        public const string Mid = "Mid";

        public const string Major = "Major";

        public const string Principal = "Principal";
    }
}
