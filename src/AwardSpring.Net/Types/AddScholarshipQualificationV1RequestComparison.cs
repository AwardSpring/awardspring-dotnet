using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(AddScholarshipQualificationV1RequestComparison.AddScholarshipQualificationV1RequestComparisonSerializer)
)]
[Serializable]
public readonly record struct AddScholarshipQualificationV1RequestComparison : IStringEnum
{
    public static readonly AddScholarshipQualificationV1RequestComparison AtLeast = new(
        Values.AtLeast
    );

    public static readonly AddScholarshipQualificationV1RequestComparison AtMost = new(
        Values.AtMost
    );

    public static readonly AddScholarshipQualificationV1RequestComparison MoreThan = new(
        Values.MoreThan
    );

    public static readonly AddScholarshipQualificationV1RequestComparison LessThan = new(
        Values.LessThan
    );

    public static readonly AddScholarshipQualificationV1RequestComparison Equals_ = new(
        Values.Equals_
    );

    public static readonly AddScholarshipQualificationV1RequestComparison Between = new(
        Values.Between
    );

    public AddScholarshipQualificationV1RequestComparison(string value)
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
    public static AddScholarshipQualificationV1RequestComparison FromCustom(string value)
    {
        return new AddScholarshipQualificationV1RequestComparison(value);
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
        AddScholarshipQualificationV1RequestComparison value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddScholarshipQualificationV1RequestComparison value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AddScholarshipQualificationV1RequestComparison value) =>
        value.Value;

    public static explicit operator AddScholarshipQualificationV1RequestComparison(string value) =>
        new(value);

    internal class AddScholarshipQualificationV1RequestComparisonSerializer
        : JsonConverter<AddScholarshipQualificationV1RequestComparison>
    {
        public override AddScholarshipQualificationV1RequestComparison Read(
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
            return new AddScholarshipQualificationV1RequestComparison(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddScholarshipQualificationV1RequestComparison value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddScholarshipQualificationV1RequestComparison ReadAsPropertyName(
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
            return new AddScholarshipQualificationV1RequestComparison(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddScholarshipQualificationV1RequestComparison value,
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
