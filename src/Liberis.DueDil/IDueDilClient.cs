using System.Threading.Tasks;
using LiberisLabs.DueDil.Requests.Companies;
using LiberisLabs.DueDil.Requests.SearchCompanies;
using LiberisLabs.DueDil.Responses;
using LiberisLabs.DueDil.Responses.Companies;
using LiberisLabs.DueDil.Responses.SearchCompanies;
using LiberisLabs.DueDil.UriBuilders;

namespace LiberisLabs.DueDil
{
    public interface IDueDilClient
    {
        Task<DueDilClientResponse<SearchCompany>> SearchCompanies(Terms terms);

        Task<DueDilClientResponse<Company>> GetCompany(Locale locale, string companyId);
    }
}