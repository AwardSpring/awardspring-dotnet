using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(AddScholarshipQualificationV1RequestAnswerSetup.AddScholarshipQualificationV1RequestAnswerSetupSerializer)
)]
[Serializable]
public readonly record struct AddScholarshipQualificationV1RequestAnswerSetup : IStringEnum
{
    public static readonly AddScholarshipQualificationV1RequestAnswerSetup AnyOf = new(
        Values.AnyOf
    );

    public static readonly AddScholarshipQualificationV1RequestAnswerSetup OnlyThisOne = new(
        Values.OnlyThisOne
    );

    public AddScholarshipQualificationV1RequestAnswerSetup(string value)
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
    public static AddScholarshipQualificationV1RequestAnswerSetup FromCustom(string value)
    {
        return new AddScholarshipQualificationV1RequestAnswerSetup(value);
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
        AddScholarshipQualificationV1RequestAnswerSetup value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddScholarshipQualificationV1RequestAnswerSetup value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AddScholarshipQualificationV1RequestAnswerSetup value) =>
        value.Value;

    public static explicit operator AddScholarshipQualificationV1RequestAnswerSetup(string value) =>
        new(value);

    internal class AddScholarshipQualificationV1RequestAnswerSetupSerializer
        : JsonConverter<AddScholarshipQualificationV1RequestAnswerSetup>
    {
        public override AddScholarshipQualificationV1RequestAnswerSetup Read(
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
            return new AddScholarshipQualificationV1RequestAnswerSetup(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddScholarshipQualificationV1RequestAnswerSetup value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddScholarshipQualificationV1RequestAnswerSetup ReadAsPropertyName(
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
            return new AddScholarshipQualificationV1RequestAnswerSetup(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddScholarshipQualificationV1RequestAnswerSetup value,
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
