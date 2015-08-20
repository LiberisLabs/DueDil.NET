using System;
using Liberis.DueDil.Sdk.UriBuilders;

namespace Liberis.DueDil.Sdk
{
    public class DueDilClientFactory
    {
        private readonly DueDilSettings _settings;
        private const string ApiVersion = "v3";

        public DueDilClientFactory(DueDilSettings settings)
        {
            _settings = settings;
        }

        public IDueDilClient CreateClient()
        {
            return new DueDilClient(BuildBaseUri(), CreateSearchCompaniesUriBuilder());
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