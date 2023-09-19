using ChallengeB3.Domain.Messages.Response;
using ChallengeB3.Domain.Interfaces.Services;

namespace ChallengeB3.Services;

public class CdbService : ICdbService
{
    private readonly ITaxService _taxService;



    public CdbService(ITaxService taxService)
    {
        _taxService = taxService;
    }

    public Task<CdbResult> CalculateCDBReturn(decimal amount, int month)
    {
        decimal TB = 0.009m;
        decimal CDI = 1.08m;

        decimal cdbCalculated = amount;

        for (int i = 1; i <= month; i++)
        {
            cdbCalculated *= (1 + (TB * CDI));
        }

        return Task.FromResult(new CdbResult
        {
            NetIncome = decimal.Round(amount + _taxService.IncomeTaxDiscountForCDB(cdbCalculated - amount, month), 2, MidpointRounding.AwayFromZero),
            GrossIncome = decimal.Round(cdbCalculated, 2, MidpointRounding.AwayFromZero)
        });
    }
}
