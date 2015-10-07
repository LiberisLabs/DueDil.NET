using LiberisLabs.DueDil.Requests.SearchCompanies;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace LiberisLabs.DueDil.Tests.UriBuilders.SearchCompaniesUriBuilderTests
{
    [TestFixture]
    public class SearchCompaniesUriBuilderTestsForPostCodeTerm : SearchCompaniesUriBuilderTestsBase
    {
        private string _postCode;

        protected override Terms GetTerms()
        {
            _postCode = "NG1 5FW";
            return new Terms() { Postcode = _postCode };
        }

        [Test]
        public void ThenTheUriQueryStringContainsTheCorrectPostcodeFilter()
        {
            var filters = GetQueryFilters();

            Assert.That(filters.Value<string>(TermFilterNames.Postcode), Is.EqualTo(_postCode));
        }
    }
}