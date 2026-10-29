using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(ListAwardsRequestIncludeItem.ListAwardsRequestIncludeItemSerializer))]
[Serializable]
public readonly record struct ListAwardsRequestIncludeItem : IStringEnum
{
    public static readonly ListAwardsRequestIncludeItem TotalCount = new(Values.TotalCount);

    public ListAwardsRequestIncludeItem(string value)
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
    public static ListAwardsRequestIncludeItem FromCustom(string value)
    {
        return new ListAwardsRequestIncludeItem(value);
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

    public static bool operator ==(ListAwardsRequestIncludeItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListAwardsRequestIncludeItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListAwardsRequestIncludeItem value) => value.Value;

    public static explicit operator ListAwardsRequestIncludeItem(string value) => new(value);

    internal class ListAwardsRequestIncludeItemSerializer
        : JsonConverter<ListAwardsRequestIncludeItem>
    {
        public override ListAwardsRequestIncludeItem Read(
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
            return new ListAwardsRequestIncludeItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListAwardsRequestIncludeItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListAwardsRequestIncludeItem ReadAsPropertyName(
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
            return new ListAwardsRequestIncludeItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListAwardsRequestIncludeItem value,
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
