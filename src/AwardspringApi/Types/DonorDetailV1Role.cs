using AwardspringApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[JsonConverter(typeof(DonorDetailV1Role.DonorDetailV1RoleSerializer))]
[Serializable]
public readonly record struct DonorDetailV1Role : IStringEnum
{
    public static readonly DonorDetailV1Role Individual = new(Values.Individual);

    public static readonly DonorDetailV1Role Organization = new(Values.Organization);

    public DonorDetailV1Role(string value)
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
    public static DonorDetailV1Role FromCustom(string value)
    {
        return new DonorDetailV1Role(value);
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

    public static bool operator ==(DonorDetailV1Role value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DonorDetailV1Role value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DonorDetailV1Role value) => value.Value;

    public static explicit operator DonorDetailV1Role(string value) => new(value);

    internal class DonorDetailV1RoleSerializer : JsonConverter<DonorDetailV1Role>
    {
        public override DonorDetailV1Role Read(
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
            return new DonorDetailV1Role(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DonorDetailV1Role value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DonorDetailV1Role ReadAsPropertyName(
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
            return new DonorDetailV1Role(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DonorDetailV1Role value,
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
