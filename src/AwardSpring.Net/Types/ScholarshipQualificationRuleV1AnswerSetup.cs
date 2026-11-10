using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(ScholarshipQualificationRuleV1AnswerSetup.ScholarshipQualificationRuleV1AnswerSetupSerializer)
)]
[Serializable]
public readonly record struct ScholarshipQualificationRuleV1AnswerSetup : IStringEnum
{
    public static readonly ScholarshipQualificationRuleV1AnswerSetup AnyOf = new(Values.AnyOf);

    public static readonly ScholarshipQualificationRuleV1AnswerSetup OnlyThisOne = new(
        Values.OnlyThisOne
    );

    public ScholarshipQualificationRuleV1AnswerSetup(string value)
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
    public static ScholarshipQualificationRuleV1AnswerSetup FromCustom(string value)
    {
        return new ScholarshipQualificationRuleV1AnswerSetup(value);
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

    public static bool operator ==(
        ScholarshipQualificationRuleV1AnswerSetup value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ScholarshipQualificationRuleV1AnswerSetup value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ScholarshipQualificationRuleV1AnswerSetup value) =>
        value.Value;

    public static explicit operator ScholarshipQualificationRuleV1AnswerSetup(string value) =>
        new(value);

    internal class ScholarshipQualificationRuleV1AnswerSetupSerializer
        : JsonConverter<ScholarshipQualificationRuleV1AnswerSetup>
    {
        public override ScholarshipQualificationRuleV1AnswerSetup Read(
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
            return new ScholarshipQualificationRuleV1AnswerSetup(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScholarshipQualificationRuleV1AnswerSetup value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScholarshipQualificationRuleV1AnswerSetup ReadAsPropertyName(
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
            return new ScholarshipQualificationRuleV1AnswerSetup(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScholarshipQualificationRuleV1AnswerSetup value,
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
        public const string AnyOf = "any_of";

        public const string OnlyThisOne = "only_this_one";
    }
}
