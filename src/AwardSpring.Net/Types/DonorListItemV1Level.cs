using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(typeof(DonorListItemV1Level.DonorListItemV1LevelSerializer))]
[Serializable]
public readonly record struct DonorListItemV1Level : IStringEnum
{
    public static readonly DonorListItemV1Level Annual = new(Values.Annual);

    public static readonly DonorListItemV1Level Mid = new(Values.Mid);

    public static readonly DonorListItemV1Level Major = new(Values.Major);

    public static readonly DonorListItemV1Level Principal = new(Values.Principal);

    public DonorListItemV1Level(string value)
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
    public static DonorListItemV1Level FromCustom(string value)
    {
        return new DonorListItemV1Level(value);
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

    public static bool operator ==(DonorListItemV1Level value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DonorListItemV1Level value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DonorListItemV1Level value) => value.Value;

    public static explicit operator DonorListItemV1Level(string value) => new(value);

    internal class DonorListItemV1LevelSerializer : JsonConverter<DonorListItemV1Level>
    {
        public override DonorListItemV1Level Read(
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
            return new DonorListItemV1Level(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DonorListItemV1Level value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DonorListItemV1Level ReadAsPropertyName(
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
            return new DonorListItemV1Level(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DonorListItemV1Level value,
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
        public const string Annual = "Annual";

        public const string Mid = "Mid";

        public const string Major = "Major";

        public const string Principal = "Principal";
    }
}
