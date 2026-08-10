namespace AwardSpring.Net;

public partial interface IAwardspringApiClient
{
    public IAwardCyclesClient AwardCycles { get; }
    public IDonorActivitiesClient DonorActivities { get; }
    public IDonorsClient Donors { get; }
    public IFundsClient Funds { get; }
    public IGiftsClient Gifts { get; }
    public IScholarshipsClient Scholarships { get; }
}
