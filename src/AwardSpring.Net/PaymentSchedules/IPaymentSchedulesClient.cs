namespace AwardSpring.Net;

public partial interface IPaymentSchedulesClient
{
    /// <summary>
    /// Returns the payment schedules belonging to the institution your API key is issued for, in the list
    /// envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
    /// `data`). Page forward by passing the returned `next_cursor` as `starting_after`;
    /// the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
    /// Results are ordered by payment-schedule id ascending; sort by `payment_date` to get the
    /// order `payment_schedule_ids` expects. Filter with `?award_cycle_id=` to list only the
    /// schedules configured on that award cycle; an award cycle the institution does not have returns
    /// `404 award_cycle_not_found`.
    ///
    /// Assistant capability: `springiq_list_payment_schedules`.
    /// </summary>
    WithRawResponseTask<PaymentScheduleV1ListResponse> ListAsync(
        ListPaymentSchedulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
