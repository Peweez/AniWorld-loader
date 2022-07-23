using AutoMapper;
using CleanArchTemplate.Core.DTOs.Customer;
using CleanArchTemplate.Core.Http;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchTemplate.Core.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(IHttpRequestSender httpRequestSender, IMapper mapper)
        {
            _httpRequestSender = httpRequestSender;
            _mapper = mapper;
        }

        private readonly IHttpRequestSender _httpRequestSender;
        private readonly IMapper _mapper;

        public async Task<CustomerResponseDTO> GetDataFromExternalApiAsync(CustomerRequestDTO request)
        {
            // For template returning custom object for real version delete this line and use code below
            CustomerResponseDTO serviceTemplateResponse = new()
            {
                Address = request.Address,
                Age = request.Age,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            return serviceTemplateResponse;

            string requestUri = $"Your url here from appsettings.json using options pattern";
            var thirdPartyApiRequestModel = new
            {
                request.Address,
                request.Age,
                request.FirstName,
                request.LastName
            };
            Func<HttpResponseMessage, Task<object>> deserializer = GetDeserializer<object>();
            dynamic thirdPartyApiResponseModel = await _httpRequestSender.SendPostRequest(requestUri, thirdPartyApiRequestModel, deserializer);
            CustomerResponseDTO serviceTemplateResponse1 = new()
            {
                Address = thirdPartyApiResponseModel.Address,
                Age = thirdPartyApiResponseModel.Age,
                FirstName = thirdPartyApiResponseModel.FirstName,
                LastName = thirdPartyApiResponseModel.LastName
            };
            return serviceTemplateResponse1;
        }

        private static Func<HttpResponseMessage, Task<TModel>> GetDeserializer<TModel>()
        {
            return async response => JsonSerializer.Deserialize<TModel>(await response.Content.ReadAsStringAsync());
        }
    }
}
