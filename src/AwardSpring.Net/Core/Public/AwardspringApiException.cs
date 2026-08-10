namespace AwardSpring.Net;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class AwardspringApiException(string message, Exception? innerException = null)
    : Exception(message, innerException);
