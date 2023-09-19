using ChallengeB3.Domain.Interfaces.Services;

namespace ChallengeB3.Services;

public class TaxService : ITaxService
{
    public decimal IncomeTaxDiscountForCDB(decimal money, int month)
    {
        return month switch
        {
            <= 6 => CalculateTaxDiscount(money, 22.5m),
            <= 12 => CalculateTaxDiscount(money, 20m),
            <= 24 => CalculateTaxDiscount(money, 17.5m),
            _ => CalculateTaxDiscount(money, 15)
        };

    }

    private static decimal CalculateTaxDiscount(decimal money, decimal tax)
    => money -  (money * (tax / 100));
}
