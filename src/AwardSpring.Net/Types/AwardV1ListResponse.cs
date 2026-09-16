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
/// `false` and `next_cursor` is null.
/// </summary>
[Serializable]
public record AwardV1ListResponse : IJsonOnDeserialized
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
    /// The page of items.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<AwardV1>? Data { get; set; }

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
