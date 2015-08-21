using System;
using System.Web;
using Liberis.DueDil.Sdk.UriBuilders;
using NUnit.Framework;

namespace Liberis.DueDil.Sdk.Tests.UriBuilders
{
    [TestFixture]
    public class GetCompanyUriBuilderTests
    {
        private Uri _actualUri;
        private string _apiKey;
        private Uri _baseUri;
        private string _companyId;

        [SetUp]
        public void GivenACompanyId_WhenBuildingAUri()
        {
            _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");
            _apiKey = Guid.NewGuid().ToString();
            _companyId = Guid.NewGuid().ToString();
            var builder = new GetCompanyUriBuilder(_apiKey);

            _actualUri = builder.BuildUri(_companyId);
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
            Assert.That(uri.AbsolutePath, Is.EqualTo($"/bla1/bla2/companies/{_companyId}"));
        }

        [Test]
        public void ThenTheUriQueryStringContainsApiKey()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var query = HttpUtility.ParseQueryString(uri.Query);

            Assert.That(query["api_key"], Is.EqualTo(_apiKey));
        }
    }
}
