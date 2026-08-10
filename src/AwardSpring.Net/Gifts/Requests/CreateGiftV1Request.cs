using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record CreateGiftV1Request
{
    /// <summary>
    /// The donor (or donor organization) user id the gift is attributed to. Required.
    /// </summary>
    [JsonPropertyName("donor_id")]
    public int? DonorId { get; set; }

    /// <summary>
    /// `gift` or `pledge`. Defaults to `gift` when omitted. Soft credits are only
    ///             honored on gifts.
    /// </summary>
    [JsonPropertyName("type")]
    public CreateGiftV1RequestType? Type { get; set; }

    /// <summary>
    /// Gift instrument — one of `Cash`, `Check`, `CreditOrDebit`, `BankTransfer`,
    /// `StockOrProperty`, `InKind`, `PayrollDeduction`, `Online`, `Other`.
    /// Optional; defaults to `None`. Ignored for pledges.
    /// </summary>
    [JsonPropertyName("gift_type")]
    public CreateGiftV1RequestGiftType? GiftType { get; set; }

    /// <summary>
    /// Monetary amount. Required for both gifts and pledges and must be greater than zero;
    /// a zero amount is allowed only when GiftType is `InKind`.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// Short human-readable title. Required, non-whitespace.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// ISO 8601 date the gift/pledge occurred (e.g. `"2026-04-03"` or `"2026-04-03T10:00:00Z"`).
    /// Required. Interpreted in the tenant's time zone and persisted in UTC.
    /// </summary>
    [JsonPropertyName("gift_date")]
    public string? GiftDate { get; set; }

    /// <summary>
    /// Fund the gift is directed toward. When the tenant has Funds Management enabled the value must
    /// match an existing fund's identifier; otherwise it is stored as a free-form label.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    [JsonPropertyName("campaign_id")]
    public int? CampaignId { get; set; }

    /// <summary>
    /// Only meaningful for pledges — marks the pledge fulfilled. Ignored for gifts.
    /// </summary>
    [JsonPropertyName("is_completed")]
    public bool? IsCompleted { get; set; }

    /// <summary>
    /// Officer the record is assigned to. Must be a user in this tenant when supplied.
    /// </summary>
    [JsonPropertyName("assigned_to_user_id")]
    public int? AssignedToUserId { get; set; }

    /// <summary>
    /// Up to three soft-credit recipients. Honored on gifts only; ignored for pledges.
    /// </summary>
    [JsonPropertyName("soft_credits")]
    public IEnumerable<SoftCreditV1Input>? SoftCredits { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
