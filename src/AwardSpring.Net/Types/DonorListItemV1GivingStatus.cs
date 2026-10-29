using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(DonorListItemV1GivingStatus.DonorListItemV1GivingStatusSerializer))]
[Serializable]
public readonly record struct DonorListItemV1GivingStatus : IStringEnum
{
    public static readonly DonorListItemV1GivingStatus Recurring = new(Values.Recurring);

    public static readonly DonorListItemV1GivingStatus New = new(Values.New);

    public static readonly DonorListItemV1GivingStatus Lapsed = new(Values.Lapsed);

    public DonorListItemV1GivingStatus(string value)
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
    public static DonorListItemV1GivingStatus FromCustom(string value)
    {
        return new DonorListItemV1GivingStatus(value);
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

    public static bool operator ==(DonorListItemV1GivingStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DonorListItemV1GivingStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DonorListItemV1GivingStatus value) => value.Value;

    public static explicit operator DonorListItemV1GivingStatus(string value) => new(value);

    internal class DonorListItemV1GivingStatusSerializer
        : JsonConverter<DonorListItemV1GivingStatus>
    {
        public override DonorListItemV1GivingStatus Read(
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
            return new DonorListItemV1GivingStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DonorListItemV1GivingStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DonorListItemV1GivingStatus ReadAsPropertyName(
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
            return new DonorListItemV1GivingStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DonorListItemV1GivingStatus value,
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
