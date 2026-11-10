using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(ScholarshipQualificationRuleV1Kind.ScholarshipQualificationRuleV1KindSerializer)
)]
[Serializable]
public readonly record struct ScholarshipQualificationRuleV1Kind : IStringEnum
{
    public static readonly ScholarshipQualificationRuleV1Kind Question = new(Values.Question);

    public static readonly ScholarshipQualificationRuleV1Kind InstitutionalAward = new(
        Values.InstitutionalAward
    );

    public ScholarshipQualificationRuleV1Kind(string value)
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
    public static ScholarshipQualificationRuleV1Kind FromCustom(string value)
    {
        return new ScholarshipQualificationRuleV1Kind(value);
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

    public static bool operator ==(ScholarshipQualificationRuleV1Kind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScholarshipQualificationRuleV1Kind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScholarshipQualificationRuleV1Kind value) => value.Value;

    public static explicit operator ScholarshipQualificationRuleV1Kind(string value) => new(value);

    internal class ScholarshipQualificationRuleV1KindSerializer
        : JsonConverter<ScholarshipQualificationRuleV1Kind>
    {
        public override ScholarshipQualificationRuleV1Kind Read(
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
            return new ScholarshipQualificationRuleV1Kind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScholarshipQualificationRuleV1Kind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScholarshipQualificationRuleV1Kind ReadAsPropertyName(
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
            return new ScholarshipQualificationRuleV1Kind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScholarshipQualificationRuleV1Kind value,
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
        public const string Question = "question";

        public const string InstitutionalAward = "institutional_award";
    }
}
