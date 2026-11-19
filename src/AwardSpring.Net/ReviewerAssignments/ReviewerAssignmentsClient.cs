using AwardSpring.Net.Core;
using global::System.Text.Json;

namespace AwardSpring.Net;

public partial class ReviewerAssignmentsClient : IReviewerAssignmentsClient
{
    private readonly RawClient _client;

    internal ReviewerAssignmentsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns one row per pair, as the Reviewer Assignment tab shows them, in the standard list envelope. Each row
    /// has the group's name and award cycle, the panel number on a group with two panels, and the reviewer and the
    /// applicant with name, email and stored ID. Rows are ordered by panel, then reviewer, then applicant.
    ///
    ///
    /// Name the group by `review_group_id`, its stored ID, or by `review_group_name`, optionally with
    /// `award_cycle_id`; leaving both out returns `400 validation_failed`. A group that does not exist at
    /// your institution, including one from another institution, returns `404 review_group_not_found`, and so
    /// does a name that fits no group. A name that fits more than one group returns `400 validation_failed`
    /// naming each. Leave `panel` out to list every panel; send `panel` to list one. A panel the group
    /// does not have returns `404 review_group_panel_not_found`. Send the same filters on every page: they are
    /// recorded in the cursor, and a page request whose filters do not match the cursor's is refused.
    ///
    ///
    /// Assistant capability: `springiq_list_reviewer_assignments`.
    /// </summary>
    private WithRawResponseTask<ReviewerAssignmentV1ListResponse> ListInternalAsync(
        ListReviewerAssignmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ReviewerAssignmentV1ListResponse>(
            ListInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<ReviewerAssignmentV1ListResponse>> ListInternalAsyncCore(
        ListReviewerAssignmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new AwardSpring.Net.Core.QueryStringBuilder.Builder(capacity: 8)
            .Add("review_group_id", request.ReviewGroupId)
            .Add("review_group_name", request.ReviewGroupName)
            .Add("award_cycle_id", request.AwardCycleId)
            .Add("panel", request.Panel)
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
                    Path = "api/v1/reviewer-assignments",
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
                var responseData = JsonUtils.Deserialize<ReviewerAssignmentV1ListResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ReviewerAssignmentV1ListResponse>()
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

    private async Task<WithRawResponse<ChangeReviewerAssignmentsV1Result>> ChangeAsyncCore(
        ChangeReviewerAssignmentsV1Request request,
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
                    Path = "api/v1/reviewer-assignments",
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
                var responseData = JsonUtils.Deserialize<ChangeReviewerAssignmentsV1Result>(
                    responseBody
                )!;
                return new WithRawResponse<ChangeReviewerAssignmentsV1Result>()
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

    private async Task<WithRawResponse<ReviewerAssignmentJobV1>> GetJobAsyncCore(
        GetJobReviewerAssignmentsRequest request,
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
                        "api/v1/reviewer-assignment-jobs/{0}",
                        ValueConvert.ToPathParameterString(request.JobId)
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
                var responseData = JsonUtils.Deserialize<ReviewerAssignmentJobV1>(responseBody)!;
                return new WithRawResponse<ReviewerAssignmentJobV1>()
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

    /// <summary>
    /// Returns a background request's rows in request order, in the standard list envelope, each with what has
    /// happened to it so far: `waiting` until the job reaches it, then `applied`, `rejected` or
    /// `failed` with a `message` saying why. A row an all-or-nothing job never reached, because a pair
    /// failed its final check, stays `waiting`. When a job stops for any other reason, such as the API key
    /// losing its write access or the job being unable to finish, a row it did not change is `rejected`
    /// with a `message` saying why, and a row whose pair already stands as asked is `applied`. Pairs a
    /// `replace` removes because the request leaves them out come after the
    /// request's own rows and have no `index`.
    ///
    /// `job_id` is required and is the job's code from its `status_url`. A code that names no job at your
    /// institution, including another institution's, returns `404 assignment_job_not_found`.
    /// </summary>
    private WithRawResponseTask<ReviewerAssignmentJobRowV1ListResponse> ListJobRowsInternalAsync(
        ListJobRowsReviewerAssignmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ReviewerAssignmentJobRowV1ListResponse>(
            ListJobRowsInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ReviewerAssignmentJobRowV1ListResponse>
    > ListJobRowsInternalAsyncCore(
        ListJobRowsReviewerAssignmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new AwardSpring.Net.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("job_id", request.JobId)
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
                    Path = "api/v1/reviewer-assignment-job-rows",
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
                var responseData = JsonUtils.Deserialize<ReviewerAssignmentJobRowV1ListResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ReviewerAssignmentJobRowV1ListResponse>()
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
    /// Returns one row per pair, as the Reviewer Assignment tab shows them, in the standard list envelope. Each row
    /// has the group's name and award cycle, the panel number on a group with two panels, and the reviewer and the
    /// applicant with name, email and stored ID. Rows are ordered by panel, then reviewer, then applicant.
    ///
    ///
    /// Name the group by `review_group_id`, its stored ID, or by `review_group_name`, optionally with
    /// `award_cycle_id`; leaving both out returns `400 validation_failed`. A group that does not exist at
    /// your institution, including one from another institution, returns `404 review_group_not_found`, and so
    /// does a name that fits no group. A name that fits more than one group returns `400 validation_failed`
    /// naming each. Leave `panel` out to list every panel; send `panel` to list one. A panel the group
    /// does not have returns `404 review_group_panel_not_found`. Send the same filters on every page: they are
    /// recorded in the cursor, and a page request whose filters do not match the cursor's is refused.
    ///
    ///
    /// Assistant capability: `springiq_list_reviewer_assignments`.
    /// </summary>
    /// <example><code>
    /// await client.ReviewerAssignments.ListAsync(new ListReviewerAssignmentsRequest());
    /// </code></example>
    public async Task<Pager<ReviewerAssignmentV1>> ListAsync(
        ListReviewerAssignmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListReviewerAssignmentsRequest,
            RequestOptions?,
            ReviewerAssignmentV1ListResponse,
            string?,
            ReviewerAssignmentV1
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
    /// Changes the pairs on one panel of a review group, with the same rules as the Reviewer Assignment tab.
    /// `review_group_id` in the body is required and is the review group's stored ID. Name each person by
    /// email or stored ID. Set `mode` to `add`, `remove` or `replace`; `replace` makes the
    /// panel hold exactly the pairs you send, removing the others.
    ///
    /// <b>Checks on every row.</b> The reviewer must already be a reviewer in the group. The applicant must have
    /// applied to a scholarship in the group, and on panel 2 must have been moved up to it. A reviewer is never
    /// given their own application. A pair listed twice, or a person who matches no active account or more than
    /// one, is turned down. A `replace` that would remove a pair whose review is started or finished turns
    /// that pair down unless `allow_removing_started_reviews` is `true`; removing a pair also removes
    /// that reviewer's scores for it, as Unassign does on the tab. Only a pair the tab shows is already in place
    /// or there to remove: adding a pair the tab does not show is turned down, and removing one leaves it as it
    /// is and counts it as `unchanged`.
    ///
    /// <b>All or nothing.</b> If any row is turned down, nothing changes and the answer is
    /// `400 assignment_rows_rejected`, whose `details` list every row with its reason. Rows that pass
    /// show `not_applied`. With `apply_good_rows_only` set to `true`, the rows that pass are
    /// applied and each turned-down row is listed in the `200`. A `replace` is the exception: one row
    /// whose reviewer or applicant matches no active account, or more than one, refuses the whole request with
    /// `400 assignment_rows_rejected` even with `apply_good_rows_only`, because that row could name a
    /// pair the panel holds and a `replace` removes every pair it does not list.
    ///
    /// <b>Large requests.</b> A request with more than 500 rows, or more than 500 pairs to change, is accepted at
    /// once with `202` and a `reviewer_assignment_job`, which names the review group and its award
    /// cycle as every answer does. Read `status_url` to follow it. Under
    /// all-or-nothing, a pair that becomes invalid while the job runs stops the job: batches already written
    /// stay written, and the job says so. At most 20,000 rows are accepted in one request, and a request may
    /// cover at most 20,000 pairs counting the pairs a `replace` removes because the request leaves them out;
    /// a larger one is refused with `400 validation_failed`.
    ///
    /// <b>The panel's assignment choice is never changed.</b> Every answer shows it as `assignment_choice`.
    /// When it is `all` or `random`, the answer carries a `warning`: applying that choice again in
    /// AwardSpring would replace the pairs you loaded.
    ///
    ///
    /// Each pair added is recorded as added by your API key. Send `dry_run` to check the request without
    /// changing anything, and an `Idempotency-Key` header so a retry returns the original answer; for a
    /// background job, the same job. Sending the same request again also ends in the same pairs.
    /// </summary>
    /// <example><code>
    /// await client.ReviewerAssignments.ChangeAsync(new ChangeReviewerAssignmentsV1Request());
    /// </code></example>
    public WithRawResponseTask<ChangeReviewerAssignmentsV1Result> ChangeAsync(
        ChangeReviewerAssignmentsV1Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ChangeReviewerAssignmentsV1Result>(
            ChangeAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Shows how a background request is going: `status`, how many of its rows are done, and the counts so
    /// far. Like every answer about pairs, it names the review group and its award cycle by stored ID and name.
    /// The job carries totals only; read `rows_url` for each row's result. `completed` means every
    /// row was applied. A job that stopped early, or has any turned-down or failed row, including rows turned down
    /// when the request was accepted, is `partially_completed` and says why in `notices`. A job that
    /// applied nothing because it could not run, or because every row it reached was turned down or failed, is
    /// `failed`. A job code that names no job at your institution, including another institution's, returns
    /// `404 assignment_job_not_found`.
    /// </summary>
    /// <example><code>
    /// await client.ReviewerAssignments.GetJobAsync(
    ///     new GetJobReviewerAssignmentsRequest { JobId = "job_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ReviewerAssignmentJobV1> GetJobAsync(
        GetJobReviewerAssignmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ReviewerAssignmentJobV1>(
            GetJobAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns a background request's rows in request order, in the standard list envelope, each with what has
    /// happened to it so far: `waiting` until the job reaches it, then `applied`, `rejected` or
    /// `failed` with a `message` saying why. A row an all-or-nothing job never reached, because a pair
    /// failed its final check, stays `waiting`. When a job stops for any other reason, such as the API key
    /// losing its write access or the job being unable to finish, a row it did not change is `rejected`
    /// with a `message` saying why, and a row whose pair already stands as asked is `applied`. Pairs a
    /// `replace` removes because the request leaves them out come after the
    /// request's own rows and have no `index`.
    ///
    /// `job_id` is required and is the job's code from its `status_url`. A code that names no job at your
    /// institution, including another institution's, returns `404 assignment_job_not_found`.
    /// </summary>
    /// <example><code>
    /// await client.ReviewerAssignments.ListJobRowsAsync(new ListJobRowsReviewerAssignmentsRequest());
    /// </code></example>
    public async Task<Pager<ReviewerAssignmentJobRowV1>> ListJobRowsAsync(
        ListJobRowsReviewerAssignmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListJobRowsReviewerAssignmentsRequest,
            RequestOptions?,
            ReviewerAssignmentJobRowV1ListResponse,
            string?,
            ReviewerAssignmentJobRowV1
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListJobRowsInternalAsync(request, options, cancellationToken)
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
