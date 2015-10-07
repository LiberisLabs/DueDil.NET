using System.Threading.Tasks;
using LiberisLabs.DueDil.Requests.SearchCompanies;
using LiberisLabs.DueDil.Responses;
using LiberisLabs.DueDil.Responses.Companies;

namespace LiberisLabs.DueDil
{
    public interface IDueDilClient
    {
        Task<DueDilClientResponse<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>> SearchCompanies(Terms terms);

        Task<DueDilClientResponse<DueDilResponse<CompanyResult>>> GetCompany(string companyId);
    }
}