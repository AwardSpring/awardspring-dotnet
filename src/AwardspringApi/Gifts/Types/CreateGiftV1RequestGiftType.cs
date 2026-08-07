using AwardspringApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[JsonConverter(typeof(CreateGiftV1RequestGiftType.CreateGiftV1RequestGiftTypeSerializer))]
[Serializable]
public readonly record struct CreateGiftV1RequestGiftType : IStringEnum
{
    public static readonly CreateGiftV1RequestGiftType Cash = new(Values.Cash);

    public static readonly CreateGiftV1RequestGiftType Check = new(Values.Check);

    public static readonly CreateGiftV1RequestGiftType CreditOrDebit = new(Values.CreditOrDebit);

    public static readonly CreateGiftV1RequestGiftType BankTransfer = new(Values.BankTransfer);

    public static readonly CreateGiftV1RequestGiftType StockOrProperty = new(
        Values.StockOrProperty
    );

    public static readonly CreateGiftV1RequestGiftType InKind = new(Values.InKind);

    public static readonly CreateGiftV1RequestGiftType PayrollDeduction = new(
        Values.PayrollDeduction
    );

    public static readonly CreateGiftV1RequestGiftType Online = new(Values.Online);

    public static readonly CreateGiftV1RequestGiftType Other = new(Values.Other);

    public CreateGiftV1RequestGiftType(string value)
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
    public static CreateGiftV1RequestGiftType FromCustom(string value)
    {
        return new CreateGiftV1RequestGiftType(value);
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

    public static bool operator ==(CreateGiftV1RequestGiftType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateGiftV1RequestGiftType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateGiftV1RequestGiftType value) => value.Value;

    public static explicit operator CreateGiftV1RequestGiftType(string value) => new(value);

    internal class CreateGiftV1RequestGiftTypeSerializer
        : JsonConverter<CreateGiftV1RequestGiftType>
    {
        public override CreateGiftV1RequestGiftType Read(
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
            return new CreateGiftV1RequestGiftType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateGiftV1RequestGiftType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateGiftV1RequestGiftType ReadAsPropertyName(
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
            return new CreateGiftV1RequestGiftType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateGiftV1RequestGiftType value,
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
        public const string Cash = "Cash";

        public const string Check = "Check";

        public const string CreditOrDebit = "CreditOrDebit";

        public const string BankTransfer = "BankTransfer";

        public const string StockOrProperty = "StockOrProperty";

        public const string InKind = "InKind";

        public const string PayrollDeduction = "PayrollDeduction";

        public const string Online = "Online";

        public const string Other = "Other";
    }
}
