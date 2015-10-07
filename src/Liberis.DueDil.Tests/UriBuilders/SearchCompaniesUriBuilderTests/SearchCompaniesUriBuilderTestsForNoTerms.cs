using LiberisLabs.DueDil.Requests.SearchCompanies;
using NUnit.Framework;

namespace LiberisLabs.DueDil.Tests.UriBuilders.SearchCompaniesUriBuilderTests
{
    [TestFixture]
    public class SearchCompaniesUriBuilderTestsForNoTerms : SearchCompaniesUriBuilderTestsBase
    {
        protected override Terms GetTerms()
        {
            return new Terms();
        }


        [Test]
        public void ThenTheUriQueryStringContainsNoFilters()
        {
            var filters = GetQueryFilters();

            Assert.That(filters, Is.Empty);
        }
    }
}
