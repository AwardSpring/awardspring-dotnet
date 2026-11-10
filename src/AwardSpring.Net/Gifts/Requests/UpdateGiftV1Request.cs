using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record UpdateGiftV1Request
{
    /// <summary>
    /// The gift's or pledge's stored ID, as the gifts list returns it in `id`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The new amount. Must be greater than zero; zero is allowed only on a gift paid `InKind`. Cannot be
    /// cleared. Refused on a gift given online.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// The new date of the gift or pledge, as an ISO 8601 date such as `"2026-04-03"`. The date is the
    /// institution's own calendar day; a time sent with it is ignored. Cannot be cleared. Refused on a gift
    /// given online.
    /// </summary>
    [JsonPropertyName("gift_date")]
    public string? GiftDate { get; set; }

    /// <summary>
    /// The new payment type of a gift: one of `Cash`, `Check`, `CreditOrDebit`,
    /// `BankTransfer`, `StockOrProperty`, `InKind`, `PayrollDeduction` or `Other`.
    /// `Online` is set only on gifts given online and cannot be chosen. Cannot be cleared. Refused on a
    /// pledge, which has no payment type, and on a gift given online.
    /// </summary>
    [JsonPropertyName("gift_type")]
    public string? GiftType { get; set; }

    /// <summary>
    /// The institution's own code for the fund the gift is directed toward, as the gift returns it in
    /// `fund_id`. When the institution uses Funds Management it must name one of its funds. Send an
    /// empty string to clear it.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// The stored ID of a campaign at this institution. Send an empty string to clear it.
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// The new short title of the gift or pledge. Cannot be cleared.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// The new notes about the gift or pledge. Replaces the notes whole. Send an empty string to clear them.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
