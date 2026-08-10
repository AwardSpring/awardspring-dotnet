using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(DonorListItemV1Role.DonorListItemV1RoleSerializer))]
[Serializable]
public readonly record struct DonorListItemV1Role : IStringEnum
{
    public static readonly DonorListItemV1Role Individual = new(Values.Individual);

    public static readonly DonorListItemV1Role Organization = new(Values.Organization);

    public DonorListItemV1Role(string value)
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
    public static DonorListItemV1Role FromCustom(string value)
    {
        return new DonorListItemV1Role(value);
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

    public static bool operator ==(DonorListItemV1Role value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DonorListItemV1Role value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DonorListItemV1Role value) => value.Value;

    public static explicit operator DonorListItemV1Role(string value) => new(value);

    internal class DonorListItemV1RoleSerializer : JsonConverter<DonorListItemV1Role>
    {
        public override DonorListItemV1Role Read(
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
            return new DonorListItemV1Role(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DonorListItemV1Role value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DonorListItemV1Role ReadAsPropertyName(
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
            return new DonorListItemV1Role(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DonorListItemV1Role value,
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
        public const string Individual = "Individual";

        public const string Organization = "Organization";
    }
}
