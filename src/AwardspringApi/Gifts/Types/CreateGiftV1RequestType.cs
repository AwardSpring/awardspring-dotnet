using AwardspringApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[JsonConverter(typeof(CreateGiftV1RequestType.CreateGiftV1RequestTypeSerializer))]
[Serializable]
public readonly record struct CreateGiftV1RequestType : IStringEnum
{
    public static readonly CreateGiftV1RequestType Gift = new(Values.Gift);

    public static readonly CreateGiftV1RequestType Pledge = new(Values.Pledge);

    public CreateGiftV1RequestType(string value)
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
    public static CreateGiftV1RequestType FromCustom(string value)
    {
        return new CreateGiftV1RequestType(value);
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

    public static bool operator ==(CreateGiftV1RequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateGiftV1RequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateGiftV1RequestType value) => value.Value;

    public static explicit operator CreateGiftV1RequestType(string value) => new(value);

    internal class CreateGiftV1RequestTypeSerializer : JsonConverter<CreateGiftV1RequestType>
    {
        public override CreateGiftV1RequestType Read(
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
            return new CreateGiftV1RequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateGiftV1RequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateGiftV1RequestType ReadAsPropertyName(
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
            return new CreateGiftV1RequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateGiftV1RequestType value,
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
        public const string Gift = "gift";

        public const string Pledge = "pledge";
    }
}
