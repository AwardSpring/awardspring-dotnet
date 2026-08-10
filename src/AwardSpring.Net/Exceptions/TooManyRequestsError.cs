namespace AwardSpring.Net;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class TooManyRequestsError(
    V1ErrorEnvelope body,
    AwardSpring.Net.RawResponse? rawResponse = null
) : AwardspringApiApiException("TooManyRequestsError", 429, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new V1ErrorEnvelope Body => body;
}
