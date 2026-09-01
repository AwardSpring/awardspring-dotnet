using AwardSpring.Net.Core;

namespace AwardSpring.Net;

public partial class AwardspringApiClient : IAwardspringApiClient
{
    private readonly RawClient _client;

    public AwardspringApiClient(string? apiKey = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "AwardSpring.Net" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "AwardSpring.Net/0.1.9" },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "X-Spring-API-Key", apiKey ?? "" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        AwardCycles = new AwardCyclesClient(_client);
        DonorActivities = new DonorActivitiesClient(_client);
        Donors = new DonorsClient(_client);
        Funds = new FundsClient(_client);
        Gifts = new GiftsClient(_client);
        Scholarships = new ScholarshipsClient(_client);
    }

    public IAwardCyclesClient AwardCycles { get; }

    public IDonorActivitiesClient DonorActivities { get; }

    public IDonorsClient Donors { get; }

    public IFundsClient Funds { get; }

    public IGiftsClient Gifts { get; }

    public IScholarshipsClient Scholarships { get; }
}
