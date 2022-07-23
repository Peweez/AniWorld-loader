using CleanArchTemplate.Core.DTOs.Customer;
using CleanArchTemplate.Core.Services.Customer;
using System.Threading.Tasks;

namespace CleanArchTemplate.Tests.FakeServices;

public class CustomerServiceFake : ICustomerService
{
    private readonly CustomerResponseDTO _templateResponse;

    public CustomerServiceFake()
    {
        _templateResponse = new CustomerResponseDTO()
        {
            FirstName = "Lara",
            LastName = "Croft",
            Address = "Lara Croft's Address",
            Age = 33
        };
    }

    public Task<CustomerResponseDTO> GetDataFromExternalApiAsync(CustomerRequestDTO request)
    {
        return Task.FromResult(_templateResponse);
    }
}