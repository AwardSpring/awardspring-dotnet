using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(DonorActivitySourceV1.DonorActivitySourceV1Serializer))]
[Serializable]
public readonly record struct DonorActivitySourceV1 : IStringEnum
{
    public static readonly DonorActivitySourceV1 Logged = new(Values.Logged);

    public static readonly DonorActivitySourceV1 Email = new(Values.Email);

    public static readonly DonorActivitySourceV1 Sms = new(Values.Sms);

    public static readonly DonorActivitySourceV1 Award = new(Values.Award);

    public static readonly DonorActivitySourceV1 GeneralApplication = new(
        Values.GeneralApplication
    );

    public DonorActivitySourceV1(string value)
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
    public static DonorActivitySourceV1 FromCustom(string value)
    {
        return new DonorActivitySourceV1(value);
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

    public static bool operator ==(DonorActivitySourceV1 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DonorActivitySourceV1 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DonorActivitySourceV1 value) => value.Value;

    public static explicit operator DonorActivitySourceV1(string value) => new(value);

    internal class DonorActivitySourceV1Serializer : JsonConverter<DonorActivitySourceV1>
    {
        public override DonorActivitySourceV1 Read(
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
            return new DonorActivitySourceV1(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DonorActivitySourceV1 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DonorActivitySourceV1 ReadAsPropertyName(
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
            return new DonorActivitySourceV1(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DonorActivitySourceV1 value,
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
        public const string Logged = "Logged";

        public const string Email = "Email";

        public const string Sms = "Sms";

        public const string Award = "Award";

        public const string GeneralApplication = "GeneralApplication";
    }
}
