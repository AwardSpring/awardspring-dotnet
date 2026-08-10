using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(CreateDonorV1RequestRole.CreateDonorV1RequestRoleSerializer))]
[Serializable]
public readonly record struct CreateDonorV1RequestRole : IStringEnum
{
    public static readonly CreateDonorV1RequestRole Individual = new(Values.Individual);

    public static readonly CreateDonorV1RequestRole Organization = new(Values.Organization);

    public CreateDonorV1RequestRole(string value)
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
    public static CreateDonorV1RequestRole FromCustom(string value)
    {
        return new CreateDonorV1RequestRole(value);
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

    public static bool operator ==(CreateDonorV1RequestRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateDonorV1RequestRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateDonorV1RequestRole value) => value.Value;

    public static explicit operator CreateDonorV1RequestRole(string value) => new(value);

    internal class CreateDonorV1RequestRoleSerializer : JsonConverter<CreateDonorV1RequestRole>
    {
        public override CreateDonorV1RequestRole Read(
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
            return new CreateDonorV1RequestRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateDonorV1RequestRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateDonorV1RequestRole ReadAsPropertyName(
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
            return new CreateDonorV1RequestRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateDonorV1RequestRole value,
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
