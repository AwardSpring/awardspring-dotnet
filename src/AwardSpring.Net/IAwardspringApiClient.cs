namespace AwardSpring.Net;

public partial interface IAwardspringApiClient
{
    public IApplicationsClient Applications { get; }
    public IAwardCyclesClient AwardCycles { get; }
    public IAwardsClient Awards { get; }
    public IDonorActivitiesClient DonorActivities { get; }
    public IDonorsClient Donors { get; }
    public IFundsClient Funds { get; }
    public IGiftsClient Gifts { get; }
    public IScholarshipsClient Scholarships { get; }
    public IStudentsClient Students { get; }
}
