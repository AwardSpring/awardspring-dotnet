namespace AwardSpring.Net.Core;

public interface IIsRetryableContent
{
    public bool IsRetryable { get; }
}
