using System;
using System.Web;
using LiberisLabs.DueDil.Requests.SearchCompanies;
using LiberisLabs.DueDil.UriBuilders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace LiberisLabs.DueDil.Tests.UriBuilders.SearchCompaniesUriBuilderTests
{
    public abstract class SearchCompaniesUriBuilderTestsBase
    {
        private Uri _actualUri;
        private string _apiKey;
        private Uri _baseUri;

        [SetUp]
        public void GivenSomeTerms_WhenBuildingAUri()
        {
            _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");
            _apiKey = Guid.NewGuid().ToString();
            var terms = GetTerms();
            var builder = new SearchCompaniesUriBuilder(_apiKey);

            _actualUri = builder.BuildUri(terms);
        }

        protected abstract Terms GetTerms();


        [Test]
        public void ThenTheUriIsNotAbsolute()
        {
            Assert.That(_actualUri.IsAbsoluteUri, Is.False);
        }

        [Test]
        public void ThenTheUriPathIsCorrect()
        {
            var uri = new Uri(_baseUri, _actualUri);
            Assert.That(uri.AbsolutePath, Is.EqualTo("/bla1/bla2/companies"));
        }

        [Test]
        public void ThenTheUriQueryStringContainsApiKey()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var query = HttpUtility.ParseQueryString(uri.Query);

            Assert.That(query["api_key"], Is.EqualTo(_apiKey));
        }

        protected JObject GetQueryFilters()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            var filters = JsonConvert.DeserializeObject<JObject>(query["filters"]);
            return filters;
        }
    }
}