using AwardspringApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[JsonConverter(typeof(DonorV1Role.DonorV1RoleSerializer))]
[Serializable]
public readonly record struct DonorV1Role : IStringEnum
{
    public static readonly DonorV1Role Individual = new(Values.Individual);

    public static readonly DonorV1Role Organization = new(Values.Organization);

    public DonorV1Role(string value)
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
    public static DonorV1Role FromCustom(string value)
    {
        return new DonorV1Role(value);
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

    public static bool operator ==(DonorV1Role value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DonorV1Role value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DonorV1Role value) => value.Value;

    public static explicit operator DonorV1Role(string value) => new(value);

    internal class DonorV1RoleSerializer : JsonConverter<DonorV1Role>
    {
        public override DonorV1Role Read(
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
            return new DonorV1Role(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DonorV1Role value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DonorV1Role ReadAsPropertyName(
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
            return new DonorV1Role(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DonorV1Role value,
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
