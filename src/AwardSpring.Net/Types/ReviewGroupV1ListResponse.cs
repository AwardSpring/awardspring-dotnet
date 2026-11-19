using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// The envelope every list endpoint returns: one page of results in `data`, plus the cursors
/// needed to reach the rest.
/// ```
/// {
///   "object": "list",
///   "url": "/api/v1/…",
///   "has_more": true,
///   "next_cursor": "…",
///   "previous_cursor": null,
///   "data": [ … ]
/// }
/// ````url` echoes the path the collection was served from. To page forward, send
/// `next_cursor` back as `starting_after`; on the last page `has_more` is
/// `false` and `next_cursor` is null. A request with `include=total_count` also
/// gets `total_count`.
/// </summary>
[Serializable]
public record ReviewGroupV1ListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Discriminator constant. Always `"list"`, mirroring Stripe's list objects.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("object")]
    public string? Object { get; set; }

    /// <summary>
    /// The request path this collection was served from (e.g. `/api/v1/scholarships`).
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// True when another page exists in the current paging direction.
    /// </summary>
    [JsonPropertyName("has_more")]
    public bool? HasMore { get; set; }

    /// <summary>
    /// Opaque cursor for the next page (pass as `starting_after`). Null when there is none.
    /// </summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>
    /// Opaque cursor for the previous page (pass as `ending_before`). Null when there is none.
    /// </summary>
    [JsonPropertyName("previous_cursor")]
    public string? PreviousCursor { get; set; }

    /// <summary>
    /// The number of records that match the request across all pages, counted fresh on each
    /// request. Present only when the request includes `include=total_count`; otherwise the
    /// key is omitted.
    /// </summary>
    [JsonPropertyName("total_count")]
    public int? TotalCount { get; set; }

    /// <summary>
    /// Present only on a list requested with `changed_since`: the time this answer is complete up
    /// to, in UTC epoch seconds. Every change made before it is in the list, and a change made at or
    /// after it is not. Every page of one walk carries the same value. Start the next sync with
    /// `changed_since` set to it. Otherwise the key is omitted.
    /// </summary>
    [JsonPropertyName("complete_up_to")]
    public int? CompleteUpTo { get; set; }

    /// <summary>
    /// The page of items.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<ReviewGroupV1> Data { get; set; } = new List<ReviewGroupV1>();

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
