using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record GiftV1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Stripe-style resource discriminator. Stable, snake_case string naming the resource type.
    /// Serialized first so it reads as the leading field of every V1 resource body.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("object")]
    public string? Object { get; set; }

    /// <summary>
    /// The gift's or pledge's stored ID: 9 characters, sent exactly as stored. A dry-run create
    /// returns `null`, because nothing was saved.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The stored ID of the donor the gift or pledge is attributed to.
    /// </summary>
    [JsonPropertyName("donor_id")]
    public string? DonorId { get; set; }

    /// <summary>
    /// `gift` for money already given, or `pledge` for money promised.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// How the gift was given: one of `None`, `Cash`, `Check`, `CreditOrDebit`,
    /// `BankTransfer`, `StockOrProperty`, `InKind`, `PayrollDeduction`, `Online` or
    /// `Other`. `None` when no payment type was recorded.
    /// </summary>
    [JsonPropertyName("gift_type")]
    public string? GiftType { get; set; }

    /// <summary>
    /// The amount given or pledged, or `null` when no amount was recorded.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// The short title of the gift or pledge.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Longer notes about the gift or pledge, or `null`.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The school's own code for the fund the gift is directed toward, as plain text.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// The stored ID of the campaign the gift or pledge belongs to, or `null`.
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// For a pledge, whether it has been fulfilled.
    /// </summary>
    [JsonPropertyName("is_completed")]
    public bool? IsCompleted { get; set; }

    /// <summary>
    /// Whether a gift acknowledgement has been sent to the donor for this gift.
    /// </summary>
    [JsonPropertyName("gift_acknowledgement_sent")]
    public bool? GiftAcknowledgementSent { get; set; }

    /// <summary>
    /// The date of the gift or pledge, as the institution's own wall-clock time, sent as epoch seconds.
    /// The number is not a true UTC moment: it counts the school's clock as if the school were on UTC, so a gift made
    /// at 10:00 AM school time arrives as 10:00 UTC. Read it as UTC and show it as is; do not convert it to the viewer's time zone.
    /// </summary>
    [JsonPropertyName("date")]
    public int? Date { get; set; }

    /// <summary>
    /// Up to three people or names credited for the gift besides the donor. An empty list when there are
    /// none.
    /// </summary>
    [JsonPropertyName("soft_credits")]
    public IEnumerable<SoftCreditV1>? SoftCredits { get; set; }

    /// <summary>
    /// When anything stored on the gift or pledge that this resource returns last changed, in UTC epoch
    /// seconds. Logging it counts as a change. Null only on a dry-run create, because nothing was saved.
    /// Use it with the gifts list's `changed_since` to pick up only the gifts that changed.
    /// </summary>
    [JsonPropertyName("last_changed_at")]
    public int? LastChangedAt { get; set; }

    /// <summary>
    /// Present, and `true`, only on a gift or pledge that was removed. Removed gifts appear only in a
    /// gifts list requested with `changed_since`, and carry only `object`, `id`,
    /// `deleted` and `removed_at`. Otherwise the key is omitted.
    /// </summary>
    [JsonPropertyName("deleted")]
    public bool? Deleted { get; set; }

    /// <summary>
    /// On a removed gift or pledge only: when it was removed, in UTC epoch seconds. Otherwise the key is
    /// omitted.
    /// </summary>
    [JsonPropertyName("removed_at")]
    public int? RemovedAt { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
