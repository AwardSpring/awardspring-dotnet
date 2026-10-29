using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(ListGiftsRequestIncludeItem.ListGiftsRequestIncludeItemSerializer))]
[Serializable]
public readonly record struct ListGiftsRequestIncludeItem : IStringEnum
{
    public static readonly ListGiftsRequestIncludeItem TotalCount = new(Values.TotalCount);

    public ListGiftsRequestIncludeItem(string value)
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
    public static ListGiftsRequestIncludeItem FromCustom(string value)
    {
        return new ListGiftsRequestIncludeItem(value);
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

    public static bool operator ==(ListGiftsRequestIncludeItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListGiftsRequestIncludeItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListGiftsRequestIncludeItem value) => value.Value;

    public static explicit operator ListGiftsRequestIncludeItem(string value) => new(value);

    internal class ListGiftsRequestIncludeItemSerializer
        : JsonConverter<ListGiftsRequestIncludeItem>
    {
        public override ListGiftsRequestIncludeItem Read(
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
            return new ListGiftsRequestIncludeItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListGiftsRequestIncludeItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListGiftsRequestIncludeItem ReadAsPropertyName(
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
            return new ListGiftsRequestIncludeItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListGiftsRequestIncludeItem value,
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
        public const string TotalCount = "total_count";
    }
}
