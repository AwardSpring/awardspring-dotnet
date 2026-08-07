namespace AwardspringApi.Core;

public interface IIsRetryableContent
{
    public bool IsRetryable { get; }
}
