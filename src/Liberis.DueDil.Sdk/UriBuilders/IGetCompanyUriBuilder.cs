using System;

namespace Liberis.DueDil.Sdk.UriBuilders
{
    public interface IGetCompanyUriBuilder
    {
        Uri BuildUri(string companyId);
    }
}