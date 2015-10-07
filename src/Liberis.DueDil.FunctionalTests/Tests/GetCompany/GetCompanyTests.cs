using System;
using LiberisLabs.DueDil.FunctionalTests.MockApi;
using LiberisLabs.DueDil.Requests.Companies;
using LiberisLabs.DueDil.Responses;
using LiberisLabs.DueDil.Responses.Companies;
using NUnit.Framework;

namespace LiberisLabs.DueDil.FunctionalTests.Tests.GetCompany
{
    [TestFixture(false)]
    [TestFixture(true)]
    public class GetCompanyTests
    {
        private Api _api;
        private DueDilClientResponse<Company> _actual;
        private MockResource _resource;
        private readonly bool _sandboxMode;

        public GetCompanyTests(bool sandboxMode)
        {
            _sandboxMode = sandboxMode;
        }

        [TestFixtureSetUp]
        public void GivenARunningApiWhenGettingACompany()
        {
            var companyId = Guid.NewGuid().ToString();
            var apiKey = Guid.NewGuid().ToString();
            _resource = new MockResource(new ResourceIdentifier("GET", CreateCompanyPath(companyId), $"?api_key={apiKey}"));
            _resource.ReturnsBody(JsonSearchResponse);

            _api = new Api();
            _api.RegisterResource(_resource);
            _api.Start();

            var client = new DueDilClientFactory(new DueDilSettings(_api.Uri, apiKey, _sandboxMode)).CreateClient();

            _actual = client.GetCompany(Locale.Uk, companyId).Result;
        }

        private string CreateCompanyPath(string companyId)
        {
            var v3Path = "/v3";
            var sandboxPath = _sandboxMode ? "/sandbox" : null;
            var companiesPath = "/uk/companies";

            return $"{v3Path}{sandboxPath}{companiesPath}/{companyId}";
        }

        [Test]
        public void ThenTheResourceIsCalled()
        {
            Assert.That(_resource.Verify(), Is.True);
        }

        [Test]
        public void ThenARequestIdIsReturned()
        {
            Assert.That(_actual.Data.RequestId, Is.Not.Null);
        }

        [Test]
        public void ThenTheCompanyResultIsReturned()
        {
            Assert.That(_actual.Data.Response.Id, Is.EqualTo("23423425"));
            Assert.That(_actual.Data.Response.Name, Is.EqualTo("Joey Blogss"));
            Assert.That(_actual.Data.Response.CompanyType, Is.EqualTo("Private limited with share capital"));
            Assert.That(_actual.Data.Response.AccountsType, Is.EqualTo("Total Exemption Full"));
            Assert.That(_actual.Data.Response.AccountsUrl, Is.EqualTo("http://accounts"));
            Assert.That(_actual.Data.Response.Description, Is.EqualTo("desc"));
            Assert.That(_actual.Data.Response.DirectorsUrl, Is.EqualTo("http://directors"));
            Assert.That(_actual.Data.Response.DirectorshipsUrl, Is.EqualTo("http://directorship"));
            Assert.That(_actual.Data.Response.DocumentsUrl, Is.EqualTo("http://documents"));
            Assert.That(_actual.Data.Response.IncorporationDate, Is.EqualTo(new DateTime(2015, 08, 21, 08, 47, 25)));
            Assert.That(_actual.Data.Response.LastUpdate, Is.EqualTo(new DateTime(2015, 08, 21, 08, 47, 25)));
            Assert.That(_actual.Data.Response.LatestAccountsDate, Is.EqualTo(new DateTime(2015, 08, 21, 08, 47, 25)));
            Assert.That(_actual.Data.Response.LatestAnnualReturnDate, Is.EqualTo(new DateTime(2015, 08, 21, 08, 47, 25)));
            Assert.That(_actual.Data.Response.MortgagesUrl, Is.EqualTo("http://mortgages"));
            Assert.That(_actual.Data.Response.RegisteredAddressPostcode, Is.EqualTo("NG1 WAT"));
            Assert.That(_actual.Data.Response.RegisteredAreaCode, Is.EqualTo("area code"));
            Assert.That(_actual.Data.Response.RegisteredPhone, Is.EqualTo("01243487512"));
            Assert.That(_actual.Data.Response.RegisteredTps, Is.EqualTo("tps"));
            Assert.That(_actual.Data.Response.RegisteredWeb, Is.EqualTo("http://liberis.co.uk"));
            Assert.That(_actual.Data.Response.ShareholdingsUrl, Is.EqualTo("http://sharholdings"));
            Assert.That(_actual.Data.Response.Sic2007Code, Is.EqualTo(10001));
            Assert.That(_actual.Data.Response.SicCode, Is.EqualTo(1002));
            Assert.That(_actual.Data.Response.SicDescription, Is.EqualTo("Sic"));
            Assert.That(_actual.Data.Response.Status, Is.EqualTo("status"));
            Assert.That(_actual.Data.Response.SubsidiariesUrl, Is.EqualTo("http://subsidiaries"));
            Assert.That(_actual.Data.Response.TradingAddress1, Is.EqualTo("trading address1"));
            Assert.That(_actual.Data.Response.TradingAddress2, Is.EqualTo("trading address2"));
            Assert.That(_actual.Data.Response.TradingAddress3, Is.EqualTo("trading address3"));
            Assert.That(_actual.Data.Response.TradingAddress4, Is.EqualTo("trading address4"));
            Assert.That(_actual.Data.Response.TradingAddressPostcode, Is.EqualTo("trading postcode"));
        }

        [TestFixtureTearDown]
        public void Kill()
        {
            _api.Stop();
        }

        private const string JsonSearchResponse = @"{
   ""response"":{
      ""id"":""23423425"",
      ""last_update"":""2015-08-21T08:47:25Z"",
      ""name"":""Joey Blogss"",
      ""description"":""desc"",
      ""status"":""status"",
      ""incorporation_date"":""2015-08-21T08:47:25Z"",
      ""latest_annual_return_date"":""2015-08-21T08:47:25Z"",
      ""latest_accounts_date"":""2015-08-21T08:47:25Z"",
      ""company_type"":""Private limited with share capital"",
      ""accounts_type"":""Total Exemption Full"",
      ""sic_code"":1002,
      ""sic_description"":""Sic"",
      ""shareholdings_url"":""http://sharholdings"",
      ""accounts_url"":""http://accounts"",
      ""directors_url"":""http://directors"",
      ""directorships_url"":""http://directorship"",
      ""subsidiaries_url"":""http://subsidiaries"",
      ""documents_url"":""http://documents"",
      ""mortgages_url"":""http://mortgages"",
      ""reg_address_postcode"":""NG1 WAT"",
      ""reg_area_code"":""area code"",
      ""reg_phone"":""01243487512"",
      ""reg_tps"":""tps"",
      ""reg_web"":""http://liberis.co.uk"",
      ""sic2007code"":10001,
      ""trading_address1"":""trading address1"",
      ""trading_address2"":""trading address2"",
      ""trading_address3"":""trading address3"",
      ""trading_address4"":""trading address4"",
      ""trading_address_postcode"":""trading postcode""
   },
   ""request_id"":""55d6e32bdc945""
}";
    }
}
