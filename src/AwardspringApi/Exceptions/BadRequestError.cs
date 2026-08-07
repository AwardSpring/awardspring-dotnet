namespace AwardspringApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(V1ErrorEnvelope body, AwardspringApi.RawResponse? rawResponse = null)
    : AwardspringApiApiException("BadRequestError", 400, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new V1ErrorEnvelope Body => body;
}
