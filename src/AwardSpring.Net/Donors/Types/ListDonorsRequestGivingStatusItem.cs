using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(ListDonorsRequestGivingStatusItem.ListDonorsRequestGivingStatusItemSerializer)
)]
[Serializable]
public readonly record struct ListDonorsRequestGivingStatusItem : IStringEnum
{
    public static readonly ListDonorsRequestGivingStatusItem Recurring = new(Values.Recurring);

    public static readonly ListDonorsRequestGivingStatusItem New = new(Values.New);

    public static readonly ListDonorsRequestGivingStatusItem Lapsed = new(Values.Lapsed);

    public ListDonorsRequestGivingStatusItem(string value)
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
    public static ListDonorsRequestGivingStatusItem FromCustom(string value)
    {
        return new ListDonorsRequestGivingStatusItem(value);
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

    public static bool operator ==(ListDonorsRequestGivingStatusItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDonorsRequestGivingStatusItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDonorsRequestGivingStatusItem value) => value.Value;

    public static explicit operator ListDonorsRequestGivingStatusItem(string value) => new(value);

    internal class ListDonorsRequestGivingStatusItemSerializer
        : JsonConverter<ListDonorsRequestGivingStatusItem>
    {
        public override ListDonorsRequestGivingStatusItem Read(
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
            return new ListDonorsRequestGivingStatusItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDonorsRequestGivingStatusItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDonorsRequestGivingStatusItem ReadAsPropertyName(
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
            return new ListDonorsRequestGivingStatusItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDonorsRequestGivingStatusItem value,
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
        public const string Recurring = "Recurring";

        public const string New = "New";

        public const string Lapsed = "Lapsed";
    }
}
