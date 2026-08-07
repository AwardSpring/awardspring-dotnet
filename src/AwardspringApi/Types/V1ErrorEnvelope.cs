using AwardspringApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

/// <summary>
/// Top-level Stripe-shaped error envelope for the `/api/v1/*` surface: a single `error`
/// key wrapping a V1ErrorBody. This is the NEW v1 error type and is distinct from the
/// legacy flat StructuredErrorResponse, which remains in use by hardened legacy
/// `api/...` endpoints and must not change shape.
/// </summary>
[Serializable]
public record V1ErrorEnvelope : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("error")]
    public V1ErrorBody? Error { get; set; }

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
