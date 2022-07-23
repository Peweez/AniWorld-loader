using AutoMapper;
using CleanArchTemplate.ApiModels.Customer;
using CleanArchTemplate.Controllers;
using CleanArchTemplate.Core.Services.Customer;
using CleanArchTemplate.Mappings;
using CleanArchTemplate.Tests.FakeServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchTemplate.Tests.Controllers;

public class CustomerControllerTest
{
    private readonly CustomerController _controller;
    private readonly ICustomerService _service;
    private readonly IMapper _mapper;

    public CustomerControllerTest()
    {
        _service = new CustomerServiceFake();
        if (_mapper == null)
        {
            MapperConfiguration mappingConfig = new(mc =>
            {
                mc.AddProfile(new CustomerMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        _controller = new CustomerController(_service, _mapper);
    }
    [Fact]
    public async Task GetCustomerAsyncApi_ReturnsOkResult()
    {
        // Arrange
        CustomerRequestModel testRequest = new() { FirstName = "Lara", LastName = "Croft", Age = 33, Address = "Lara Croft's Address" };

        // Act
        IActionResult okResult = await _controller.GetCustomerAsync(testRequest);

        // Assert
        Assert.IsType<OkObjectResult>(okResult);
    }
}