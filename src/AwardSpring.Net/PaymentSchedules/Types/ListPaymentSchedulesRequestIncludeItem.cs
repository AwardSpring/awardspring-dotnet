using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(ListPaymentSchedulesRequestIncludeItem.ListPaymentSchedulesRequestIncludeItemSerializer)
)]
[Serializable]
public readonly record struct ListPaymentSchedulesRequestIncludeItem : IStringEnum
{
    public static readonly ListPaymentSchedulesRequestIncludeItem TotalCount = new(
        Values.TotalCount
    );

    public ListPaymentSchedulesRequestIncludeItem(string value)
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
    public static ListPaymentSchedulesRequestIncludeItem FromCustom(string value)
    {
        return new ListPaymentSchedulesRequestIncludeItem(value);
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

    public static bool operator ==(ListPaymentSchedulesRequestIncludeItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPaymentSchedulesRequestIncludeItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPaymentSchedulesRequestIncludeItem value) =>
        value.Value;

    public static explicit operator ListPaymentSchedulesRequestIncludeItem(string value) =>
        new(value);

    internal class ListPaymentSchedulesRequestIncludeItemSerializer
        : JsonConverter<ListPaymentSchedulesRequestIncludeItem>
    {
        public override ListPaymentSchedulesRequestIncludeItem Read(
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
            return new ListPaymentSchedulesRequestIncludeItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPaymentSchedulesRequestIncludeItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPaymentSchedulesRequestIncludeItem ReadAsPropertyName(
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
            return new ListPaymentSchedulesRequestIncludeItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPaymentSchedulesRequestIncludeItem value,
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
