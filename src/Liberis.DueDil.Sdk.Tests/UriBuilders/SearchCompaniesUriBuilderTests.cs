using System;
using System.Web;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;
using Liberis.DueDil.Sdk.UriBuilders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Liberis.DueDil.Sdk.Tests.UriBuilders
{
    [TestFixture]
    public class SearchCompaniesUriBuilderTests
    {
        private Uri _actualUri;
        private string _apiKey;
        private string _name;
        private Uri _baseUri;

        [SetUp]
        public void GivenACompanyName_WhenBuildingAUri()
        {
            _baseUri = new Uri("wibble://liberisDevs.co.uk/bla");
            _apiKey = Guid.NewGuid().ToString();
            _name = "Liberis";
            var terms = new Terms() {Name = _name};
            var builder = new SearchCompaniesUriBuilder(_baseUri, _apiKey);

            _actualUri = builder.BuildUri(terms);
        }

        [Test]
        public void ThenTheUriSchemaIsFromBaseUri()
        {
            Assert.That(_actualUri.Scheme, Is.EqualTo(_baseUri.Scheme));
        }

        [Test]
        public void ThenTheUriHostIsFromBaseUri()
        {
            Assert.That(_actualUri.Host, Is.EqualTo(_baseUri.Host));
        }

        [Test]
        public void ThenTheUriPathIsCorrect()
        {
            Assert.That(_actualUri.AbsolutePath, Is.EqualTo("/v3/companies"));
        }

        [Test]
        public void ThenTheUriQueryStringContainsApiKey()
        {
            var query = HttpUtility.ParseQueryString(_actualUri.Query);

            Assert.That(query["api_key"], Is.EqualTo(_apiKey));
        }

        [Test]
        public void ThenTheUriQueryStringContainsTheCorrectFilter()
        {
            var query = HttpUtility.ParseQueryString(_actualUri.Query);
            var filters = JsonConvert.DeserializeObject<JObject>(query["filters"]);
            var namefilter = filters["name"].Value<string>();

            Assert.That(namefilter, Is.EqualTo(_name));
        }
    }
}
