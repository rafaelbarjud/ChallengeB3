namespace ChallengeB3.Domain.Interfaces.Services;

public interface ITaxService
{
    public decimal IncomeTaxDiscountForCDB(decimal money, int month);
}
