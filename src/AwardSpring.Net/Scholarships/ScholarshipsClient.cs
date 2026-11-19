using AwardSpring.Net.Core;
using global::System.Text.Json;

namespace AwardSpring.Net;

public partial class ScholarshipsClient : IScholarshipsClient
{
    private readonly RawClient _client;

    internal ScholarshipsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns the scholarships belonging to the institution your API key is issued for, in the list
    /// envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
    /// `data`). Page forward by passing the returned `next_cursor` as `starting_after`;
    /// the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
    /// Results are ordered by scholarship id ascending.
    /// Filter with `?q=` (case-insensitive substring match on the scholarship name).
    ///
    /// Assistant capability: `springiq_list_scholarships`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    private WithRawResponseTask<ScholarshipListItemV1ListResponse> ListInternalAsync(
        ListScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ScholarshipListItemV1ListResponse>(
            ListInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<ScholarshipListItemV1ListResponse>> ListInternalAsyncCore(
        ListScholarshipsRequest request,
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
                    Path = "api/v1/scholarships",
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
                var responseData = JsonUtils.Deserialize<ScholarshipListItemV1ListResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ScholarshipListItemV1ListResponse>()
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

    private async Task<WithRawResponse<CreateScholarshipV1Response>> CreateAsyncCore(
        CreateScholarshipV1Request request,
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
                    Path = "api/v1/scholarships",
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
                var responseData = JsonUtils.Deserialize<CreateScholarshipV1Response>(
                    responseBody
                )!;
                return new WithRawResponse<CreateScholarshipV1Response>()
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

    private async Task<WithRawResponse<ScholarshipV1>> GetAsyncCore(
        GetScholarshipsRequest request,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "api/v1/scholarships/{0}",
                        ValueConvert.ToPathParameterString(request.ScholarshipId)
                    ),
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
                var responseData = JsonUtils.Deserialize<ScholarshipV1>(responseBody)!;
                return new WithRawResponse<ScholarshipV1>()
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
                    case 404:
                        throw new NotFoundError(
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

    private async Task<WithRawResponse<ScholarshipV1>> UpdateAsyncCore(
        UpdateScholarshipV1Request request,
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
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "api/v1/scholarships/{0}",
                        ValueConvert.ToPathParameterString(request.ScholarshipId)
                    ),
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
                var responseData = JsonUtils.Deserialize<ScholarshipV1>(responseBody)!;
                return new WithRawResponse<ScholarshipV1>()
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
                    case 404:
                        throw new NotFoundError(
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
    /// Assistant capability: `springiq_get_available_scholarship_dollars`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    private WithRawResponseTask<ScholarshipAvailableDollarsV1ListResponse> ListAvailableDollarsInternalAsync(
        ListAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ScholarshipAvailableDollarsV1ListResponse>(
            ListAvailableDollarsInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ScholarshipAvailableDollarsV1ListResponse>
    > ListAvailableDollarsInternalAsyncCore(
        ListAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new AwardSpring.Net.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("award_cycle_id", request.AwardCycleId)
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
                    Path = "api/v1/scholarships/available-dollars",
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
                var responseData = JsonUtils.Deserialize<ScholarshipAvailableDollarsV1ListResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ScholarshipAvailableDollarsV1ListResponse>()
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
                    case 404:
                        throw new NotFoundError(
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

    private async Task<WithRawResponse<ScholarshipAvailableDollarsV1>> GetAvailableDollarsAsyncCore(
        GetAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new AwardSpring.Net.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("award_cycle_id", request.AwardCycleId)
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
                    Path = string.Format(
                        "api/v1/scholarships/{0}/available-dollars",
                        ValueConvert.ToPathParameterString(request.ScholarshipId)
                    ),
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
                var responseData = JsonUtils.Deserialize<ScholarshipAvailableDollarsV1>(
                    responseBody
                )!;
                return new WithRawResponse<ScholarshipAvailableDollarsV1>()
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
                    case 404:
                        throw new NotFoundError(
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
    /// Assistant capability: `springiq_get_awarded_students`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    private WithRawResponseTask<AwardedStudentV1ListResponse> ListAwardedStudentsInternalAsync(
        ListAwardedStudentsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AwardedStudentV1ListResponse>(
            ListAwardedStudentsInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<AwardedStudentV1ListResponse>
    > ListAwardedStudentsInternalAsyncCore(
        ListAwardedStudentsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new AwardSpring.Net.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("award_cycle_id", request.AwardCycleId)
            .Add("scholarship_id", request.ScholarshipId)
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
                    Path = "api/v1/scholarships/awarded-students",
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
                var responseData = JsonUtils.Deserialize<AwardedStudentV1ListResponse>(
                    responseBody
                )!;
                return new WithRawResponse<AwardedStudentV1ListResponse>()
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
                    case 404:
                        throw new NotFoundError(
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
    /// Returns the scholarships belonging to the institution your API key is issued for, in the list
    /// envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
    /// `data`). Page forward by passing the returned `next_cursor` as `starting_after`;
    /// the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
    /// Results are ordered by scholarship id ascending.
    /// Filter with `?q=` (case-insensitive substring match on the scholarship name).
    ///
    /// Assistant capability: `springiq_list_scholarships`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    /// <example><code>
    /// await client.Scholarships.ListAsync(new ListScholarshipsRequest());
    /// </code></example>
    public async Task<Pager<ScholarshipListItemV1>> ListAsync(
        ListScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListScholarshipsRequest,
            RequestOptions?,
            ScholarshipListItemV1ListResponse,
            string?,
            ScholarshipListItemV1
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(request, options, cancellationToken).WithRawResponse(),
                (request, cursor) =>
                {
                    request.StartingAfter = cursor;
                },
                response => response.NextCursor,
                response => response.Data?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a scholarship with its name, description, dates, financial totals, payment schedule,
    /// department and donor associations, custom-field answers, and applicant-notification settings.
    /// Errors come back with a stable `code`, a readable `message`, and per-field
    /// `details`, so a caller can tell what to correct.
    ///
    ///
    /// This endpoint enforces exactly the same rules as creating a scholarship in the AwardSpring
    /// admin interface, so anything rejected here would also have been rejected there.
    ///
    ///
    /// A typical call supplies the award's name, dates falling inside the active award cycle, a
    /// budget total, and any donor association. The response returns the new
    /// `scholarship_id`, which you can use in follow-up requests.
    ///
    ///
    /// Set `dry_run=true` (query param or `Dry-Run: true` header) to validate without persisting.
    ///
    /// <b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
    /// printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus
    /// the same request body within 24 hours returns the original response verbatim without
    /// creating a duplicate scholarship. The same key with a different body returns
    /// `422 idempotency_key_request_mismatch`; a concurrent retry while the first call is
    /// still executing returns `409 idempotency_key_in_flight`. Only 2xx responses are
    /// cached — 4xx/5xx leave the key available for retry with a corrected payload.
    ///
    ///
    /// Assistant capability: `springiq_create_scholarship`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    /// <example><code>
    /// await client.Scholarships.CreateAsync(new CreateScholarshipV1Request());
    /// </code></example>
    public WithRawResponseTask<CreateScholarshipV1Response> CreateAsync(
        CreateScholarshipV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateScholarshipV1Response>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.Scholarships.GetAsync(new GetScholarshipsRequest { ScholarshipId = "scholarshipId" });
    /// </code></example>
    public WithRawResponseTask<ScholarshipV1> GetAsync(
        GetScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ScholarshipV1>(
            GetAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Changes a scholarship's name, application open and close dates, department, fund, donors, description,
    /// award notification wording, custom field values and qualifications (`add_qualifications` and
    /// `remove_qualifications`), and returns the updated scholarship in the same shape as getting it. Only the
    /// fields in the body change: a field left out, or sent as `null`, stays as it is, and an empty string
    /// clears a field only where the scholarship's Details tab lets it be cleared (the department, the fund and a
    /// custom field's value).
    ///
    ///
    /// The same rules apply as when an administrator saves the scholarship's Details tab, so anything refused there
    /// is refused here. Every field is checked before anything is saved, and the changes are saved together or not
    /// at all: a request with one refused field saves nothing, and the error names each refused field in
    /// `details`. A field this call does not change (for example `total_amount`) is refused the same way.
    ///
    ///
    /// A date sent without a time is that calendar day in the institution's time zone, and the scholarship keeps
    /// the time of day it opens or closes at now. A scholarship that starts taking applications again because of
    /// the change has its student matching and auto-apply run shortly after the save, as on the Details tab.
    ///
    /// `remove_qualifications` and `add_qualifications` name groups by their `group_number` in the
    /// scholarship's `qualification_groups` as last read, and the rules are saved by the Qualifications tab's own
    /// save, so its checks apply. Qualifications change only while the scholarship is taking applications, and the
    /// request is refused if either its stored close date has passed or the `application_end_date` it sends is
    /// in the past: reopening a closed scholarship and changing its qualifications in one request is refused, so
    /// reopen it first and change the qualifications in a second call. Students are re-checked against
    /// changed qualifications shortly after the save. A question behind a qualification always carries its stored
    /// ID; a question found without one is a server error (500).
    ///
    ///
    /// A scholarship ID the institution does not have, or that is malformed, returns `404 scholarship_not_found`
    /// naming `id`. The call needs an API key with write permission.
    ///
    ///
    /// Set `dry_run=true` (query param or `Dry-Run: true` header) to check the changes and see the
    /// scholarship as it would be, without saving anything.
    ///
    /// <b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any printable-ASCII
    /// string, 1–255 chars). The same key plus the same request body within 24 hours returns the original response
    /// without changing the scholarship again. The same key with a different body returns
    /// `422 idempotency_key_request_mismatch`; a concurrent retry while the first call is still executing
    /// returns `409 idempotency_key_in_flight`. Only 2xx responses are cached.
    /// </summary>
    /// <example><code>
    /// await client.Scholarships.UpdateAsync(
    ///     new UpdateScholarshipV1Request { ScholarshipId = "scholarshipId" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ScholarshipV1> UpdateAsync(
        UpdateScholarshipV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ScholarshipV1>(
            UpdateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Assistant capability: `springiq_get_available_scholarship_dollars`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    /// <example><code>
    /// await client.Scholarships.ListAvailableDollarsAsync(
    ///     new ListAvailableDollarsScholarshipsRequest { AwardCycleId = "award_cycle_id" }
    /// );
    /// </code></example>
    public async Task<Pager<ScholarshipAvailableDollarsV1>> ListAvailableDollarsAsync(
        ListAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListAvailableDollarsScholarshipsRequest,
            RequestOptions?,
            ScholarshipAvailableDollarsV1ListResponse,
            string?,
            ScholarshipAvailableDollarsV1
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListAvailableDollarsInternalAsync(request, options, cancellationToken)
                        .WithRawResponse(),
                (request, cursor) =>
                {
                    request.StartingAfter = cursor;
                },
                response => response.NextCursor,
                response => response.Data?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Assistant capability: `springiq_get_available_scholarship_dollars`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    /// <example><code>
    /// await client.Scholarships.GetAvailableDollarsAsync(
    ///     new GetAvailableDollarsScholarshipsRequest
    ///     {
    ///         ScholarshipId = "scholarshipId",
    ///         AwardCycleId = "award_cycle_id",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ScholarshipAvailableDollarsV1> GetAvailableDollarsAsync(
        GetAvailableDollarsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ScholarshipAvailableDollarsV1>(
            GetAvailableDollarsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Assistant capability: `springiq_get_awarded_students`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
    /// </summary>
    /// <example><code>
    /// await client.Scholarships.ListAwardedStudentsAsync(
    ///     new ListAwardedStudentsScholarshipsRequest { AwardCycleId = "award_cycle_id" }
    /// );
    /// </code></example>
    public async Task<Pager<AwardedStudentV1>> ListAwardedStudentsAsync(
        ListAwardedStudentsScholarshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListAwardedStudentsScholarshipsRequest,
            RequestOptions?,
            AwardedStudentV1ListResponse,
            string?,
            AwardedStudentV1
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListAwardedStudentsInternalAsync(request, options, cancellationToken)
                        .WithRawResponse(),
                (request, cursor) =>
                {
                    request.StartingAfter = cursor;
                },
                response => response.NextCursor,
                response => response.Data?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
