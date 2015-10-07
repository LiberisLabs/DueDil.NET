using System;

namespace LiberisLabs.DueDil.UriBuilders
{
    public interface IGetCompanyUriBuilder
    {
        Uri BuildUri(string companyId);
    }
}