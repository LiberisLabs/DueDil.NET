using System;
using LiberisLabs.DueDil.Requests.Companies;

namespace LiberisLabs.DueDil.UriBuilders
{
    public interface IGetCompanyUriBuilder
    {
        Uri BuildUri(Locale locale, string companyId);
    }
}