using LiberisLabs.DueDil.Requests.SearchCompanies;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace LiberisLabs.DueDil.Tests.UriBuilders.SearchCompaniesUriBuilderTests
{
    [TestFixture]
    public class SearchCompaniesUriBuilderTestsForAllTerms : SearchCompaniesUriBuilderTestsBase
    {
        private Terms _terms;

        protected override Terms GetTerms()
        {
            _terms = new Fixture().Create<Terms>();

            return _terms;
        }


        [Test]
        public void ThenTheUriQueryStringContainsAllFilters()
        {
            var filters = GetQueryFilters();

            Assert.That(filters.Value<string>(TermFilterNames.Name), Is.EqualTo(_terms.Name));
            Assert.That(filters.Value<string>(TermFilterNames.Domain), Is.EqualTo(_terms.Domain));
            Assert.That(filters.Value<string>(TermFilterNames.Postcode), Is.EqualTo(_terms.Postcode));
            Assert.That(filters.Value<string>(TermFilterNames.Location), Is.EqualTo(_terms.Location));
        }
    }
}