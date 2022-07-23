using CleanArchTemplate.Core.DTOs.Customer;
using System.Threading.Tasks;

namespace CleanArchTemplate.Core.Services.Customer
{
    public interface ICustomerService
    {
        Task<CustomerResponseDTO> GetDataFromExternalApiAsync(CustomerRequestDTO request);
    }
}