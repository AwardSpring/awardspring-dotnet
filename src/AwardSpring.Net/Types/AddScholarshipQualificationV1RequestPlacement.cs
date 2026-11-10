using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(AddScholarshipQualificationV1RequestPlacement.AddScholarshipQualificationV1RequestPlacementSerializer)
)]
[Serializable]
public readonly record struct AddScholarshipQualificationV1RequestPlacement : IStringEnum
{
    public static readonly AddScholarshipQualificationV1RequestPlacement EveryGroup = new(
        Values.EveryGroup
    );

    public static readonly AddScholarshipQualificationV1RequestPlacement NewGroup = new(
        Values.NewGroup
    );

    public static readonly AddScholarshipQualificationV1RequestPlacement Group = new(Values.Group);

    public AddScholarshipQualificationV1RequestPlacement(string value)
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
    public static AddScholarshipQualificationV1RequestPlacement FromCustom(string value)
    {
        return new AddScholarshipQualificationV1RequestPlacement(value);
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
        AddScholarshipQualificationV1RequestPlacement value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddScholarshipQualificationV1RequestPlacement value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AddScholarshipQualificationV1RequestPlacement value) =>
        value.Value;

    public static explicit operator AddScholarshipQualificationV1RequestPlacement(string value) =>
        new(value);

    internal class AddScholarshipQualificationV1RequestPlacementSerializer
        : JsonConverter<AddScholarshipQualificationV1RequestPlacement>
    {
        public override AddScholarshipQualificationV1RequestPlacement Read(
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
            return new AddScholarshipQualificationV1RequestPlacement(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddScholarshipQualificationV1RequestPlacement value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddScholarshipQualificationV1RequestPlacement ReadAsPropertyName(
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
            return new AddScholarshipQualificationV1RequestPlacement(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddScholarshipQualificationV1RequestPlacement value,
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
        public const string EveryGroup = "every_group";

        public const string NewGroup = "new_group";

        public const string Group = "group";
    }
}
