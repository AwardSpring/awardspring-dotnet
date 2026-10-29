using AwardSpring.Net.Core;
using global::System.Text.Json;

namespace AwardSpring.Net;

public partial class ReviewersClient : IReviewersClient
{
    private readonly RawClient _client;

    internal ReviewersClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<ReviewerV1>> CreateAsyncCore(
        CreateReviewerV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new AwardSpring.Net.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new AwardSpring.Net.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "api/v1/reviewers",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ReviewerV1>(responseBody)!;
                return new WithRawResponse<ReviewerV1>()
                {
                    Data = responseData,
                    RawResponse = new AwardSpring.Net.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new AwardspringApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new AwardSpring.Net.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<V1ErrorEnvelope>(responseBody),
                            rawResponse: new AwardSpring.Net.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<string>(responseBody),
                            rawResponse: new AwardSpring.Net.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<V1ErrorEnvelope>(responseBody),
                            rawResponse: new AwardSpring.Net.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 409:
                        throw new ConflictError(
                            JsonUtils.Deserialize<V1ErrorEnvelope>(responseBody),
                            rawResponse: new AwardSpring.Net.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<V1ErrorEnvelope>(responseBody),
                            rawResponse: new AwardSpring.Net.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<V1ErrorEnvelope>(responseBody),
                            rawResponse: new AwardSpring.Net.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new AwardspringApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new AwardSpring.Net.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// Adds one reviewer account, with the same rules as adding a reviewer from the Users list in the AwardSpring
    /// admin interface: a first name, a last name and a well-formed email are required, each at most 50
    /// characters. As in the admin interface, a new reviewer gets no welcome email.
    ///
    /// <b>An email that already has an account:</b> by default the email must not already be used by any account
    /// at the institution, ignoring upper and lower case; if it is, this returns `400 email_already_exists`.
    /// With `if_email_in_use` set to `add_role`, this does what the admin interface does instead, and no
    /// second account is made. When an active account at the institution has the email, the reviewer role is added
    /// to that account, which keeps its name, email and password, and this returns `200` with that account as
    /// the reviewer. An account that already has the reviewer role is returned unchanged, also with `200`. The
    /// role is never added to an account that holds an administrator role, and this returns
    /// `400 email_already_exists` instead, as it does for an email whose account is deactivated, merged, or one
    /// the admin interface would not change. When only an archived account has the email, that account gets no
    /// role: a new reviewer is made with `201` and the email moves to them, as in the admin interface.
    /// The `AwardSpring-Existing-Account` header says which of these happened: `role_added`,
    /// `role_already_held` or `email_moved_from_archived`. It is absent for an ordinary create, and from
    /// a response replayed for an `Idempotency-Key`.
    ///
    /// <b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
    /// printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus the same
    /// request body within 24 hours returns the original response verbatim without creating a duplicate
    /// reviewer. The same key with a different body returns `422 idempotency_key_request_mismatch`; a
    /// concurrent retry while the first call is still executing returns `409 idempotency_key_in_flight`.
    /// </summary>
    /// <example><code>
    /// await client.Reviewers.CreateAsync(new CreateReviewerV1Request());
    /// </code></example>
    public WithRawResponseTask<ReviewerV1> CreateAsync(
        CreateReviewerV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ReviewerV1>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }
}
