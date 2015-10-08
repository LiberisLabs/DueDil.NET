using LiberisLabs.DueDil.Requests.SearchCompanies;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace LiberisLabs.DueDil.Tests.UriBuilders.SearchCompaniesUriBuilderTests
{
    [TestFixture]
    public class SearchCompaniesUriBuilderTestsForDomainTerm : SearchCompaniesUriBuilderTestsBase
    {
        private string _domain;

        protected override Terms GetTerms()
        {
            _domain = "liberislabs.com";

            return new Terms() { Domain = _domain };
        }


        [Test]
        public void ThenTheUriQueryStringContainsTheCorrectDomainFilter()
        {
            var filters = GetQueryFilters();

            Assert.That(filters.Value<string>(TermFilterNames.Domain), Is.EqualTo(_domain));
        }
    }
}