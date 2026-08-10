using AwardSpring.Net.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

/// <summary>
/// Stripe-shaped error object for the `/api/v1/*` surface. Serialized snake_case (via
/// V1SnakeCaseNamingStrategy) and always nested under the `error` key of a
/// V1ErrorEnvelope:
/// ```{ "error": { "type": "...", "code": "...", "message": "...", "param": null, "doc_url": null, "recovery": "..." } }```
/// </summary>
[Serializable]
public record V1ErrorBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Coarse error category from V1ErrorType (e.g. `invalid_request_error`).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Stable fine-grained machine code from ErrorCode (e.g. `donor_not_found`).
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// Human-readable summary safe to surface to the caller.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The request parameter the error relates to, when attributable to a single field; otherwise null.
    /// </summary>
    [JsonPropertyName("param")]
    public string? Param { get; set; }

    /// <summary>
    /// Link to documentation for this error, when one exists; otherwise null.
    /// </summary>
    [JsonPropertyName("doc_url")]
    public string? DocUrl { get; set; }

    /// <summary>
    /// Plain-language guidance on how to recover from this error, suitable for showing to the
    /// person who triggered it. Not present on every error.
    /// </summary>
    [JsonPropertyName("recovery")]
    public string? Recovery { get; set; }

    /// <summary>
    /// Optional structured payload (e.g. a list of ValidationDetail for validation failures).
    /// Omitted from the wire when null so the canonical Stripe shape stays minimal.
    /// </summary>
    [JsonPropertyName("details")]
    public object? Details { get; set; }

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
