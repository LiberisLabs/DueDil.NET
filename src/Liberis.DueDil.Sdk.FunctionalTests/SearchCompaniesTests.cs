using System;
using System.Linq;
using Liberis.DueDil.Sdk.FunctionalTests.MockApi;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;
using Liberis.DueDil.Sdk.Responses;
using Liberis.DueDil.Sdk.Responses.Companies;
using NUnit.Framework;

namespace Liberis.DueDil.Sdk.FunctionalTests
{
    [TestFixture]
    public class SearchCompaniesTests
    {
        private Api _api;
        private DueDilClientResponse<DueDilResponse<PaginatedResponse<SearchCompanyResult>>> _actual;

        [TestFixtureSetUp]
        public void GivenARunningApiWhenSearchingForACompany()
        {
            var name = "GG";
            var apiKey = Guid.NewGuid().ToString();
            var resource = new MockResource(new ResourceIdentifier("GET", "/v3/companies", string.Format("?api_key={0}&filters={{\"name\":\"{1}\"}}", apiKey, name)));
            resource.ReturnsBody(JsonSearchResponse);

            _api = new Api();
            _api.RegisterResource(resource);
            _api.Start();

            var client = new DueDilClientFactory(new DueDilSettings(_api.Uri, apiKey, false)).CreateClient();

            _actual = client.SearchCompanies(new Terms(){Name = name}).Result;
        }
        
        [Test]
        public void ThenARequestIdIsReturned()
        {
            Assert.That(_actual.Data.RequestId, Is.Not.Null);
        }

        [Test]
        public void ThenAThePaginationIsReturned()
        {
            Assert.That(_actual.Data.Response.Pagination.PreviousUrl, Is.EqualTo("http://previousUrl"));
            Assert.That(_actual.Data.Response.Pagination.NextUrl, Is.EqualTo("http://nextUrl"));
            Assert.That(_actual.Data.Response.Pagination.Total, Is.EqualTo(49));
        }

        [Test]
        public void ThenTheSearchResultsAreReturned()
        {
            Assert.That(_actual.Data.Response.Data.Count, Is.EqualTo(3));

            var company1 = _actual.Data.Response.Data.First(x => x.Id == "eab4cb062e62b3f988dd76a2aff5363897962a83");
            var company2 = _actual.Data.Response.Data.First(x => x.Id == "6382f7f23b111e3bd82809f8a5f88cc76b44e4bf");
            var company3 = _actual.Data.Response.Data.First(x => x.Id == "bcf8065f283d785947b66f41f65ef88b38bfd708");

            Assert.That(company1.Name, Is.EqualTo("Gg-ymwwlxbg Acrp Dtwqgcz"));
            Assert.That(company1.CompanyUrl, Is.EqualTo("http://duedil.io/v3/uk/companies/eab4cb062e62b3f988dd76a2aff5363897962a83"));
            Assert.That(company1.Locale, Is.EqualTo("uk"));

            Assert.That(company2.Name, Is.EqualTo("Gg. Udwqe Lbrbn Imtdyonxh Jjxtflwredh Pbjjdjx"));
            Assert.That(company2.CompanyUrl, Is.EqualTo("http://duedil.io/v3/uk/companies/6382f7f23b111e3bd82809f8a5f88cc76b44e4bf"));
            Assert.That(company2.Locale, Is.EqualTo("uk"));

            Assert.That(company3.Name, Is.EqualTo("Ggxtlc Culwzng"));
            Assert.That(company3.CompanyUrl, Is.EqualTo("http://duedil.io/v3/roi/companies/bcf8065f283d785947b66f41f65ef88b38bfd708"));
            Assert.That(company3.Locale, Is.EqualTo("roi"));
        }

        [TestFixtureTearDown]
        public void Kill()
        {
            _api.Stop();
        }
        
        private const string JsonSearchResponse = @"{
  ""response"": {
    ""pagination"": {
      ""previous_url"": ""http://previousUrl"",
      ""next_url"": ""http://nextUrl"",
      ""total"": 49
    },
    ""data"": [
      {
        ""id"": ""eab4cb062e62b3f988dd76a2aff5363897962a83"",
        ""locale"": ""uk"",
        ""name"": ""Gg-ymwwlxbg Acrp Dtwqgcz"",
        ""company_url"": ""http://duedil.io/v3/uk/companies/eab4cb062e62b3f988dd76a2aff5363897962a83""
      },
      {
        ""id"": ""6382f7f23b111e3bd82809f8a5f88cc76b44e4bf"",
        ""locale"": ""uk"",
        ""name"": ""Gg. Udwqe Lbrbn Imtdyonxh Jjxtflwredh Pbjjdjx"",
        ""company_url"": ""http://duedil.io/v3/uk/companies/6382f7f23b111e3bd82809f8a5f88cc76b44e4bf""
      },
      {
        ""id"": ""bcf8065f283d785947b66f41f65ef88b38bfd708"",
        ""locale"": ""roi"",
        ""name"": ""Ggxtlc Culwzng"",
        ""company_url"": ""http://duedil.io/v3/roi/companies/bcf8065f283d785947b66f41f65ef88b38bfd708""
      }
    ]
  },
  ""request_id"": ""55d45acf569fc""
}";
    }
}
