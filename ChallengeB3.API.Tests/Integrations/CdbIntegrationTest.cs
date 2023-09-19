

using ChallengeB3.API.Controllers;
using ChallengeB3.Domain.Interfaces.Services;
using ChallengeB3.Services;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ChallengeB3.API.Tests.Integrations;

[TestFixture]
public class CdbIntegrationTest
{

    [Test]
    [TestCase(100, 1)]
    [TestCase(100, 6)]
    [TestCase(100, 12)]
    [TestCase(100, 24)]
    public async Task GetCalculateCdbSucess(decimal amount, int month)
    {
        ITaxService taxService = new TaxService();
        ICdbService cdbService = new CdbService(taxService);
        CdbController cdbController = new(cdbService)
        {
            ControllerContext = new() { HttpContext = new DefaultHttpContext() }
        };

        await cdbController.GetCdbCalculate(amount, month);

        Assert.Multiple(() =>
        {
            Assert.That(cdbController.Response, Is.Not.Null);
            Assert.That(cdbController.Response.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        });
    }
}
