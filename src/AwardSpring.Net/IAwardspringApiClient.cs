namespace AwardSpring.Net;

public partial interface IAwardspringApiClient
{
    public IApplicationsClient Applications { get; }
    public IAwardCyclesClient AwardCycles { get; }
    public IAwardsClient Awards { get; }
    public IDepartmentsClient Departments { get; }
    public IDonorActivitiesClient DonorActivities { get; }
    public IDonorsClient Donors { get; }
    public IFundsClient Funds { get; }
    public IGiftsClient Gifts { get; }
    public IPaymentSchedulesClient PaymentSchedules { get; }
    public IPeopleClient People { get; }
    public IReviewersClient Reviewers { get; }
    public IScholarshipsClient Scholarships { get; }
    public IStudentsClient Students { get; }
}
