using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(ScholarshipQualificationRuleV1QuestionType.ScholarshipQualificationRuleV1QuestionTypeSerializer)
)]
[Serializable]
public readonly record struct ScholarshipQualificationRuleV1QuestionType : IStringEnum
{
    public static readonly ScholarshipQualificationRuleV1QuestionType OneChoice = new(
        Values.OneChoice
    );

    public static readonly ScholarshipQualificationRuleV1QuestionType MultipleChoice = new(
        Values.MultipleChoice
    );

    public static readonly ScholarshipQualificationRuleV1QuestionType MultipleChoiceAny = new(
        Values.MultipleChoiceAny
    );

    public static readonly ScholarshipQualificationRuleV1QuestionType Major = new(Values.Major);

    public static readonly ScholarshipQualificationRuleV1QuestionType Degree = new(Values.Degree);

    public static readonly ScholarshipQualificationRuleV1QuestionType AcademicStatus = new(
        Values.AcademicStatus
    );

    public static readonly ScholarshipQualificationRuleV1QuestionType Number = new(Values.Number);

    public static readonly ScholarshipQualificationRuleV1QuestionType NumberRange = new(
        Values.NumberRange
    );

    public static readonly ScholarshipQualificationRuleV1QuestionType HighSchoolGpa = new(
        Values.HighSchoolGpa
    );

    public static readonly ScholarshipQualificationRuleV1QuestionType CollegeGpa = new(
        Values.CollegeGpa
    );

    public static readonly ScholarshipQualificationRuleV1QuestionType ExpenseRatio = new(
        Values.ExpenseRatio
    );

    public ScholarshipQualificationRuleV1QuestionType(string value)
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
    public static ScholarshipQualificationRuleV1QuestionType FromCustom(string value)
    {
        return new ScholarshipQualificationRuleV1QuestionType(value);
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
        ScholarshipQualificationRuleV1QuestionType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ScholarshipQualificationRuleV1QuestionType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ScholarshipQualificationRuleV1QuestionType value) =>
        value.Value;

    public static explicit operator ScholarshipQualificationRuleV1QuestionType(string value) =>
        new(value);

    internal class ScholarshipQualificationRuleV1QuestionTypeSerializer
        : JsonConverter<ScholarshipQualificationRuleV1QuestionType>
    {
        public override ScholarshipQualificationRuleV1QuestionType Read(
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
            return new ScholarshipQualificationRuleV1QuestionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScholarshipQualificationRuleV1QuestionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScholarshipQualificationRuleV1QuestionType ReadAsPropertyName(
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
            return new ScholarshipQualificationRuleV1QuestionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScholarshipQualificationRuleV1QuestionType value,
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
        public const string OneChoice = "one_choice";

        public const string MultipleChoice = "multiple_choice";

        public const string MultipleChoiceAny = "multiple_choice_any";

        public const string Major = "major";

        public const string Degree = "degree";

        public const string AcademicStatus = "academic_status";

        public const string Number = "number";

        public const string NumberRange = "number_range";

        public const string HighSchoolGpa = "high_school_gpa";

        public const string CollegeGpa = "college_gpa";

        public const string ExpenseRatio = "expense_ratio";
    }
}
