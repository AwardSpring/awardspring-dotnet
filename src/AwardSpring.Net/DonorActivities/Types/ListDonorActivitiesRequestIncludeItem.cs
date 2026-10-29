using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(ListDonorActivitiesRequestIncludeItem.ListDonorActivitiesRequestIncludeItemSerializer)
)]
[Serializable]
public readonly record struct ListDonorActivitiesRequestIncludeItem : IStringEnum
{
    public static readonly ListDonorActivitiesRequestIncludeItem TotalCount = new(
        Values.TotalCount
    );

    public ListDonorActivitiesRequestIncludeItem(string value)
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
    public static ListDonorActivitiesRequestIncludeItem FromCustom(string value)
    {
        return new ListDonorActivitiesRequestIncludeItem(value);
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

    public static bool operator ==(ListDonorActivitiesRequestIncludeItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDonorActivitiesRequestIncludeItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDonorActivitiesRequestIncludeItem value) =>
        value.Value;

    public static explicit operator ListDonorActivitiesRequestIncludeItem(string value) =>
        new(value);

    internal class ListDonorActivitiesRequestIncludeItemSerializer
        : JsonConverter<ListDonorActivitiesRequestIncludeItem>
    {
        public override ListDonorActivitiesRequestIncludeItem Read(
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
            return new ListDonorActivitiesRequestIncludeItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDonorActivitiesRequestIncludeItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDonorActivitiesRequestIncludeItem ReadAsPropertyName(
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
            return new ListDonorActivitiesRequestIncludeItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDonorActivitiesRequestIncludeItem value,
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
