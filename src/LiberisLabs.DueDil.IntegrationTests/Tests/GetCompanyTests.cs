using System.Threading.Tasks;
using LiberisLabs.DueDil.Requests.Companies;
using LiberisLabs.DueDil.Requests.SearchCompanies;
using LiberisLabs.DueDil.Responses;
using LiberisLabs.DueDil.Responses.Companies;
using NUnit.Framework;

namespace LiberisLabs.DueDil.IntegrationTests.Tests
{
    [TestFixture]
    public class GetCompanyTests : CompanyTests
    {
        private DueDilClientResponse<Company> _result;

        [SetUp]
        public void WhenSearchingForACompany()
        {
            _result = Client.GetCompany(Locale.Uk, "bbeaf93e71060b699a7ba9922bc286694c0aa5a3").Result;
        }

        [Test]
        public void ThenTheCompanyIsReturned()
        {
            Assert.That(_result.Data.RequestId, Is.Not.Null);
            Assert.That(_result.Data.Response, Is.Not.Null);
        }
    }
}
