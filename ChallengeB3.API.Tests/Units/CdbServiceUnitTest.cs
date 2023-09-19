

using ChallengeB3.Domain.Interfaces.Services;
using ChallengeB3.Services;
using NUnit.Framework;
using ChallengeB3.Domain.Messages.Response;

namespace ChallengeB3.API.Tests.Units;

public class CdbServiceUnitTest
{
    [Test]
    [TestCase(100, 1, 100.75, 100.97)]
    [TestCase(100.35, 1, 101.11, 101.33)]
    [TestCase(200, 2, 203.03, 203.91)]
    [TestCase(300, 3, 306.85, 308.83)]
    [TestCase(400, 4, 412.23, 415.78)]
    [TestCase(500, 5, 519.20, 524.78)]
    [TestCase(600, 6, 627.79, 635.85)]
    [TestCase(700, 7, 739.23, 749.04)]
    [TestCase(800, 8, 851.49, 864.37)]
    [TestCase(900, 9, 965.49, 981.86)]
    [TestCase(1000, 10, 1081.25, 1101.56)]
    [TestCase(1100, 11, 1198.80, 1223.50)]
    [TestCase(1200, 12, 1318.16, 1347.70)]
    [TestCase(1300, 13, 1443.71, 1474.20)]
    [TestCase(1400, 14, 1567.50, 1603.03)]
    [TestCase(1500, 15, 1693.24, 1734.23)]
    [TestCase(1600, 16, 1820.95, 1867.82)]
    [TestCase(1700, 17, 1950.68, 2003.85)]
    [TestCase(1800, 18, 2082.44, 2142.35)]
    [TestCase(1900, 19, 2216.26, 2283.35)]
    [TestCase(2000, 20, 2352.18, 2426.88)]
    [TestCase(2100, 21, 2490.22, 2573.00)]
    [TestCase(2200, 22, 2630.42, 2721.72)]
    [TestCase(2300, 23, 2772.80, 2873.09)]
    [TestCase(2400, 24, 2917.40, 3027.15)]
    
    public async Task TestCdbCalculatedAsync(decimal amount, int month, decimal netIncomeExpected, decimal grossIncomeExpected)
    {
        ITaxService taxService = new TaxService();
        ICdbService cdbService = new CdbService(taxService);

        CdbResult resultCalculate = await cdbService.CalculateCDBReturn(amount, month);

        Assert.Multiple(() =>
        {
            Assert.That(netIncomeExpected, Is.EqualTo(resultCalculate.NetIncome));
            Assert.That(grossIncomeExpected, Is.EqualTo(resultCalculate.GrossIncome));
        });
    }



}
