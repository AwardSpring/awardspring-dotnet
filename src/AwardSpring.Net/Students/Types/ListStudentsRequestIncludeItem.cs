using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(ListStudentsRequestIncludeItem.ListStudentsRequestIncludeItemSerializer))]
[Serializable]
public readonly record struct ListStudentsRequestIncludeItem : IStringEnum
{
    public static readonly ListStudentsRequestIncludeItem TotalCount = new(Values.TotalCount);

    public ListStudentsRequestIncludeItem(string value)
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
    public static ListStudentsRequestIncludeItem FromCustom(string value)
    {
        return new ListStudentsRequestIncludeItem(value);
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

    public static bool operator ==(ListStudentsRequestIncludeItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListStudentsRequestIncludeItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListStudentsRequestIncludeItem value) => value.Value;

    public static explicit operator ListStudentsRequestIncludeItem(string value) => new(value);

    internal class ListStudentsRequestIncludeItemSerializer
        : JsonConverter<ListStudentsRequestIncludeItem>
    {
        public override ListStudentsRequestIncludeItem Read(
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
            return new ListStudentsRequestIncludeItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListStudentsRequestIncludeItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListStudentsRequestIncludeItem ReadAsPropertyName(
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
            return new ListStudentsRequestIncludeItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListStudentsRequestIncludeItem value,
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
