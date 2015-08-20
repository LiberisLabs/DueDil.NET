using System.Threading.Tasks;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;
using Liberis.DueDil.Sdk.Responses;
using Liberis.DueDil.Sdk.Responses.SearchCompanies;

namespace Liberis.DueDil.Sdk
{
    public interface IDueDilClient
    {
        Task<DueDilClientResponse<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>> SearchCompanies(Terms terms);
    }
}