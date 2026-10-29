using AwardSpring.Net.Core;
using global::System.Text.Json;

namespace AwardSpring.Net;

public partial class DepartmentsClient : IDepartmentsClient
{
    private readonly RawClient _client;

    internal DepartmentsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<DepartmentV1ListResponse>> ListAsyncCore(
        ListDepartmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new AwardSpring.Net.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("q", request.Q)
            .Add("limit", request.Limit)
            .Add("starting_after", request.StartingAfter)
            .Add("ending_before", request.EndingBefore)
            .Add("include", request.Include)
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
                    Method = HttpMethod.Get,
                    Path = "api/v1/departments",
                    QueryString = _queryString,
                    Headers = _headers,
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
                var responseData = JsonUtils.Deserialize<DepartmentV1ListResponse>(responseBody)!;
                return new WithRawResponse<DepartmentV1ListResponse>()
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

    private async Task<WithRawResponse<DepartmentV1>> CreateAsyncCore(
        CreateDepartmentV1Request request,
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
                    Path = "api/v1/departments",
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
                var responseData = JsonUtils.Deserialize<DepartmentV1>(responseBody)!;
                return new WithRawResponse<DepartmentV1>()
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
    /// Returns the departments of the institution your API key is issued for, in the standard list envelope
    /// (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`, `data`),
    /// each with how many differently named scholarships and how many administrators belong to it. Page
    /// forward by passing the returned `next_cursor` as `starting_after`. `limit` defaults to
    /// 25 and is capped at 100. Results are ordered by id ascending. Filter with `?q=`
    /// (case-insensitive substring match on the department name).
    /// </summary>
    /// <example><code>
    /// await client.Departments.ListAsync(new ListDepartmentsRequest());
    /// </code></example>
    public WithRawResponseTask<DepartmentV1ListResponse> ListAsync(
        ListDepartmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DepartmentV1ListResponse>(
            ListAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Adds one department, with the same rules as adding a department in the AwardSpring admin interface:
    /// the name is required and must not already be used by another department at the institution, ignoring
    /// upper and lower case and spaces at either end. A new department starts with the same settings the
    /// admin interface gives one. Departments are not available on every plan; on a plan without them this
    /// returns `403 permission_required`.
    ///
    /// <b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
    /// printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus the same
    /// request body within 24 hours returns the original response verbatim without creating a duplicate
    /// department. The same key with a different body returns `422 idempotency_key_request_mismatch`; a
    /// concurrent retry while the first call is still executing returns `409 idempotency_key_in_flight`.
    /// </summary>
    /// <example><code>
    /// await client.Departments.CreateAsync(new CreateDepartmentV1Request());
    /// </code></example>
    public WithRawResponseTask<DepartmentV1> CreateAsync(
        CreateDepartmentV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DepartmentV1>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }
}
