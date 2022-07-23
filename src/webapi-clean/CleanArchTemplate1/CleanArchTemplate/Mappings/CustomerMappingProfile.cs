using AutoMapper;
using CleanArchTemplate.ApiModels.Customer;
using CleanArchTemplate.Core.DTOs.Customer;

namespace CleanArchTemplate.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CustomerRequestModel, CustomerRequestDTO>();
        CreateMap<CustomerResponseDTO, CustomerResponseModel>()
            .ForPath(c => c.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
    }
}