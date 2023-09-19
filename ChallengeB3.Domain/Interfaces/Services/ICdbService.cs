using ChallengeB3.Domain.Messages.Response;

namespace ChallengeB3.Domain.Interfaces.Services;

public interface ICdbService
{
    public Task<CdbResult> CalculateCDBReturn(decimal amount, int month);
}
