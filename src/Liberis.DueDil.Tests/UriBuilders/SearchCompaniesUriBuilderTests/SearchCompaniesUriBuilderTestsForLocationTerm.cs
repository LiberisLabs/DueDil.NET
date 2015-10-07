using LiberisLabs.DueDil.Requests.SearchCompanies;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace LiberisLabs.DueDil.Tests.UriBuilders.SearchCompaniesUriBuilderTests
{
    [TestFixture]
    public class SearchCompaniesUriBuilderTestsForLocationTerm : SearchCompaniesUriBuilderTestsBase
    {
        private string _location;

        protected override Terms GetTerms()
        {
            _location = "Nottingham";
            return new Terms() { Location = _location};
        }


        [Test]
        public void ThenTheUriQueryStringContainsTheCorrectLocationFilter()
        {
            var filters = GetQueryFilters();

            var namefilter = filters["location"].Value<string>();

            Assert.That(namefilter, Is.EqualTo(_location));
        }
    }
}