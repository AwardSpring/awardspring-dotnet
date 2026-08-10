using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[JsonConverter(
    typeof(CreateDonorActivityV1RequestActivityType.CreateDonorActivityV1RequestActivityTypeSerializer)
)]
[Serializable]
public readonly record struct CreateDonorActivityV1RequestActivityType : IStringEnum
{
    public static readonly CreateDonorActivityV1RequestActivityType LoggedEmail = new(
        Values.LoggedEmail
    );

    public static readonly CreateDonorActivityV1RequestActivityType LoggedPhone = new(
        Values.LoggedPhone
    );

    public static readonly CreateDonorActivityV1RequestActivityType LoggedMeeting = new(
        Values.LoggedMeeting
    );

    public static readonly CreateDonorActivityV1RequestActivityType LoggedNote = new(
        Values.LoggedNote
    );

    public static readonly CreateDonorActivityV1RequestActivityType LoggedPledge = new(
        Values.LoggedPledge
    );

    public CreateDonorActivityV1RequestActivityType(string value)
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
    public static CreateDonorActivityV1RequestActivityType FromCustom(string value)
    {
        return new CreateDonorActivityV1RequestActivityType(value);
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
        CreateDonorActivityV1RequestActivityType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateDonorActivityV1RequestActivityType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateDonorActivityV1RequestActivityType value) =>
        value.Value;

    public static explicit operator CreateDonorActivityV1RequestActivityType(string value) =>
        new(value);

    internal class CreateDonorActivityV1RequestActivityTypeSerializer
        : JsonConverter<CreateDonorActivityV1RequestActivityType>
    {
        public override CreateDonorActivityV1RequestActivityType Read(
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
            return new CreateDonorActivityV1RequestActivityType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateDonorActivityV1RequestActivityType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateDonorActivityV1RequestActivityType ReadAsPropertyName(
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
            return new CreateDonorActivityV1RequestActivityType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateDonorActivityV1RequestActivityType value,
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
        public const string LoggedEmail = "LoggedEmail";

        public const string LoggedPhone = "LoggedPhone";

        public const string LoggedMeeting = "LoggedMeeting";

        public const string LoggedNote = "LoggedNote";

        public const string LoggedPledge = "LoggedPledge";
    }
}
