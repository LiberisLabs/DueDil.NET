using System;
using System.Collections.Generic;
using System.Web;
using LiberisLabs.DueDil.Requests.Companies;
using LiberisLabs.DueDil.UriBuilders;
using NUnit.Framework;

namespace LiberisLabs.DueDil.Tests.UriBuilders
{
    [TestFixture(Locale.Uk)]
    [TestFixture(Locale.Roi)]
    public class GetCompanyUriBuilderTests
    {
        private Uri _actualUri;
        private string _apiKey;
        private Uri _baseUri;
        private string _companyId;
        private readonly Locale _locale;

        public GetCompanyUriBuilderTests(Locale locale)
        {
            _locale = locale;
        }

        [SetUp]
        public void GivenACompanyId_WhenBuildingAUri()
        {
            _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");
            _apiKey = Guid.NewGuid().ToString();
            _companyId = Guid.NewGuid().ToString();
            var builder = new GetCompanyUriBuilder(_apiKey);

            _actualUri = builder.BuildUri(_locale, _companyId);
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
            Assert.That(uri.AbsolutePath, Is.EqualTo($"/bla1/bla2/{_localeMap[_locale]}/companies/{_companyId}"));
        }

        [Test]
        public void ThenTheUriQueryStringContainsApiKey()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var query = HttpUtility.ParseQueryString(uri.Query);

            Assert.That(query["api_key"], Is.EqualTo(_apiKey));
        }

        private readonly IReadOnlyDictionary<Locale, string> _localeMap = new Dictionary<Locale, string>
        {
            {Locale.Uk, "uk"},
            {Locale.Roi, "roi"}
        };

    }
}
