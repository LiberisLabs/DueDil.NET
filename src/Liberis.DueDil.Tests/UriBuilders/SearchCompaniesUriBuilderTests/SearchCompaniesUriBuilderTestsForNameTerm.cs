using LiberisLabs.DueDil.Requests.SearchCompanies;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace LiberisLabs.DueDil.Tests.UriBuilders.SearchCompaniesUriBuilderTests
{
    [TestFixture]
    public class SearchCompaniesUriBuilderTestsForNameTerm : SearchCompaniesUriBuilderTestsBase
    {
        private string _name;

        protected override Terms GetTerms()
        {
            _name = "Liberis";

            return new Terms() {Name = _name};
        }


        [Test]
        public void ThenTheUriQueryStringContainsTheCorrectNameFilter()
        {
            var filters = GetQueryFilters();

            Assert.That(filters.Value<string>(TermFilterNames.Name), Is.EqualTo(_name));
        }

    }
}
