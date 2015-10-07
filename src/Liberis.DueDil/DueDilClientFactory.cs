using System;
using LiberisLabs.DueDil.UriBuilders;

namespace LiberisLabs.DueDil
{
    public class DueDilClientFactory
    {
        private readonly IDueDilSettings _settings;
        private const string ApiVersion = "v3";

        public DueDilClientFactory(IDueDilSettings settings)
        {
            _settings = settings;
        }

        public IDueDilClient CreateClient()
        {
            return new DueDilClient(BuildBaseUri(), CreateSearchCompaniesUriBuilder(), CreateGetCompanyUriBuilder());
        }

        private IGetCompanyUriBuilder CreateGetCompanyUriBuilder()
        {
            return new GetCompanyUriBuilder(_settings.ApiKey);
        }

        private Uri BuildBaseUri()
        {
            var relativepath = ApiVersion + "/";

            if (_settings.SandboxMode)
            {
                relativepath += "sandbox/";
            }

            return new Uri(_settings.BaseUri, relativepath);
        }

        private ISearchCompaniesUriBuilder CreateSearchCompaniesUriBuilder()
        {
            ISearchCompaniesUriBuilder builder = new SearchCompaniesUriBuilder(_settings.ApiKey);
            
            return builder;
        }
    }
}