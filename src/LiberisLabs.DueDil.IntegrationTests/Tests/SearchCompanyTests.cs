using LiberisLabs.DueDil.Requests.SearchCompanies;
using LiberisLabs.DueDil.Responses;
using LiberisLabs.DueDil.Responses.SearchCompanies;
using NUnit.Framework;

namespace LiberisLabs.DueDil.IntegrationTests.Tests
{
    [TestFixture]
    public class SearchCompanyTests : CompanyTests
    {
        private DueDilClientResponse<SearchCompany> _result;
        
        [SetUp]
        public void WhenSearchingForACompany()
        {
            _result = Client.SearchCompanies(new Terms() {Name = "L"}).Result;
        }

        [Test]
        public void ThenSomeResultsAreReturned()
        {
            Assert.That(_result.Data.RequestId, Is.Not.Null);
            Assert.That(_result.Data.Response.Data, Is.Not.Empty);
        }
    }
}
