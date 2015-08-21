using System.Threading.Tasks;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;
using Liberis.DueDil.Sdk.Responses;
using Liberis.DueDil.Sdk.Responses.Companies;

namespace Liberis.DueDil.Sdk
{
    public interface IDueDilClient
    {
        Task<DueDilClientResponse<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>> SearchCompanies(Terms terms);

        Task<DueDilClientResponse<DueDilResponse<CompanyResult>>> GetCompany(string companyId);
    }
}