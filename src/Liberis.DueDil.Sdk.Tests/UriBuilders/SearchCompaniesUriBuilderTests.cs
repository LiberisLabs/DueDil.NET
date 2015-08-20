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
            _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");
            _apiKey = Guid.NewGuid().ToString();
            _name = "Liberis";
            var terms = new Terms() {Name = _name};
            var builder = new SearchCompaniesUriBuilder(_apiKey);

            _actualUri = builder.BuildUri(terms);
        }


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

        [Test]
        public void ThenTheUriQueryStringContainsTheCorrectFilter()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            var filters = JsonConvert.DeserializeObject<JObject>(query["filters"]);
            var namefilter = filters["name"].Value<string>();

            Assert.That(namefilter, Is.EqualTo(_name));
        }
    }
}
