using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(ListDonorsRequestSort.ListDonorsRequestSortSerializer))]
[Serializable]
public readonly record struct ListDonorsRequestSort : IStringEnum
{
    public static readonly ListDonorsRequestSort Name = new(Values.Name);

    public static readonly ListDonorsRequestSort LastContacted = new(Values.LastContacted);

    public static readonly ListDonorsRequestSort LongestSinceContact = new(
        Values.LongestSinceContact
    );

    public ListDonorsRequestSort(string value)
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
    public static ListDonorsRequestSort FromCustom(string value)
    {
        return new ListDonorsRequestSort(value);
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

    public static bool operator ==(ListDonorsRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDonorsRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDonorsRequestSort value) => value.Value;

    public static explicit operator ListDonorsRequestSort(string value) => new(value);

    internal class ListDonorsRequestSortSerializer : JsonConverter<ListDonorsRequestSort>
    {
        public override ListDonorsRequestSort Read(
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
            return new ListDonorsRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDonorsRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDonorsRequestSort ReadAsPropertyName(
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
            return new ListDonorsRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDonorsRequestSort value,
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
        public const string Name = "name";

        public const string LastContacted = "last_contacted";

        public const string LongestSinceContact = "longest_since_contact";
    }
}
