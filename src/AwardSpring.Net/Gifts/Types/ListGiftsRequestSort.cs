using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(ListGiftsRequestSort.ListGiftsRequestSortSerializer))]
[Serializable]
public readonly record struct ListGiftsRequestSort : IStringEnum
{
    public static readonly ListGiftsRequestSort DateDesc = new(Values.DateDesc);

    public static readonly ListGiftsRequestSort DateAsc = new(Values.DateAsc);

    public ListGiftsRequestSort(string value)
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
    public static ListGiftsRequestSort FromCustom(string value)
    {
        return new ListGiftsRequestSort(value);
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

    public static bool operator ==(ListGiftsRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListGiftsRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListGiftsRequestSort value) => value.Value;

    public static explicit operator ListGiftsRequestSort(string value) => new(value);

    internal class ListGiftsRequestSortSerializer : JsonConverter<ListGiftsRequestSort>
    {
        public override ListGiftsRequestSort Read(
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
            return new ListGiftsRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListGiftsRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListGiftsRequestSort ReadAsPropertyName(
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
            return new ListGiftsRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListGiftsRequestSort value,
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
        public const string DateDesc = "date_desc";

        public const string DateAsc = "date_asc";
    }
}
