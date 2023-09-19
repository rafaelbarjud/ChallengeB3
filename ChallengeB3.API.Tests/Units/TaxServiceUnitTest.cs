using ChallengeB3.Domain.Interfaces.Services;
using ChallengeB3.Services;
using NUnit.Framework;

namespace ChallengeB3.API.Tests.Units;

public class TaxServiceUnitTest
{

    [Test]
    [TestCase(100, 1, 77.50)]
    [TestCase(100.50, 1, 77.89)]
    [TestCase(200, 2, 155)]
    [TestCase(300, 3, 232.50)]
    [TestCase(400, 4, 310)]
    [TestCase(500, 5, 387.50)]
    [TestCase(600, 6, 465)]
    [TestCase(100, 7, 80)]
    [TestCase(200, 8, 160)]
    [TestCase(300, 9, 240)]
    [TestCase(400, 10, 320)]
    [TestCase(500, 11, 400)]
    [TestCase(600, 12, 480)]
    [TestCase(100, 13, 82.50)]
    [TestCase(200, 14, 165)]
    [TestCase(300, 15, 247.50)]
    [TestCase(400, 16, 330)]
    [TestCase(500, 17, 412.5)]
    [TestCase(600, 18, 495)]
    [TestCase(700, 19, 577.50)]
    [TestCase(800, 20, 660)]
    [TestCase(900, 21, 742.50)]
    [TestCase(1000, 22, 825)]
    [TestCase(1100, 23, 907.50)]
    [TestCase(1200, 24, 990)]
    [TestCase(1300, 25, 1105)]
    public void TesttTax(decimal amount, int month, decimal expectedResult)
    {
        ITaxService taxService = new TaxService();

        decimal valueReturned = decimal.Round(taxService.IncomeTaxDiscountForCDB(amount, month), 2, MidpointRounding.AwayFromZero);
        
        Assert.That(expectedResult, Is.EqualTo(valueReturned));
    }
}
