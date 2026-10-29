using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(ListAvailableDollarsScholarshipsRequestIncludeItem.ListAvailableDollarsScholarshipsRequestIncludeItemSerializer)
)]
[Serializable]
public readonly record struct ListAvailableDollarsScholarshipsRequestIncludeItem : IStringEnum
{
    public static readonly ListAvailableDollarsScholarshipsRequestIncludeItem TotalCount = new(
        Values.TotalCount
    );

    public ListAvailableDollarsScholarshipsRequestIncludeItem(string value)
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
    public static ListAvailableDollarsScholarshipsRequestIncludeItem FromCustom(string value)
    {
        return new ListAvailableDollarsScholarshipsRequestIncludeItem(value);
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

    public static bool operator ==(
        ListAvailableDollarsScholarshipsRequestIncludeItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListAvailableDollarsScholarshipsRequestIncludeItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListAvailableDollarsScholarshipsRequestIncludeItem value
    ) => value.Value;

    public static explicit operator ListAvailableDollarsScholarshipsRequestIncludeItem(
        string value
    ) => new(value);

    internal class ListAvailableDollarsScholarshipsRequestIncludeItemSerializer
        : JsonConverter<ListAvailableDollarsScholarshipsRequestIncludeItem>
    {
        public override ListAvailableDollarsScholarshipsRequestIncludeItem Read(
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
            return new ListAvailableDollarsScholarshipsRequestIncludeItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListAvailableDollarsScholarshipsRequestIncludeItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListAvailableDollarsScholarshipsRequestIncludeItem ReadAsPropertyName(
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
            return new ListAvailableDollarsScholarshipsRequestIncludeItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListAvailableDollarsScholarshipsRequestIncludeItem value,
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
