using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(ScholarshipQualificationRuleV1Comparison.ScholarshipQualificationRuleV1ComparisonSerializer)
)]
[Serializable]
public readonly record struct ScholarshipQualificationRuleV1Comparison : IStringEnum
{
    public static readonly ScholarshipQualificationRuleV1Comparison AtLeast = new(Values.AtLeast);

    public static readonly ScholarshipQualificationRuleV1Comparison AtMost = new(Values.AtMost);

    public static readonly ScholarshipQualificationRuleV1Comparison MoreThan = new(Values.MoreThan);

    public static readonly ScholarshipQualificationRuleV1Comparison LessThan = new(Values.LessThan);

    public static readonly ScholarshipQualificationRuleV1Comparison Equals_ = new(Values.Equals_);

    public static readonly ScholarshipQualificationRuleV1Comparison Between = new(Values.Between);

    public ScholarshipQualificationRuleV1Comparison(string value)
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
    public static ScholarshipQualificationRuleV1Comparison FromCustom(string value)
    {
        return new ScholarshipQualificationRuleV1Comparison(value);
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
        ScholarshipQualificationRuleV1Comparison value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ScholarshipQualificationRuleV1Comparison value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ScholarshipQualificationRuleV1Comparison value) =>
        value.Value;

    public static explicit operator ScholarshipQualificationRuleV1Comparison(string value) =>
        new(value);

    internal class ScholarshipQualificationRuleV1ComparisonSerializer
        : JsonConverter<ScholarshipQualificationRuleV1Comparison>
    {
        public override ScholarshipQualificationRuleV1Comparison Read(
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
            return new ScholarshipQualificationRuleV1Comparison(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScholarshipQualificationRuleV1Comparison value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScholarshipQualificationRuleV1Comparison ReadAsPropertyName(
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
            return new ScholarshipQualificationRuleV1Comparison(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScholarshipQualificationRuleV1Comparison value,
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
        public const string AtLeast = "at_least";

        public const string AtMost = "at_most";

        public const string MoreThan = "more_than";

        public const string LessThan = "less_than";

        public const string Equals_ = "equals";

        public const string Between = "between";
    }
}
