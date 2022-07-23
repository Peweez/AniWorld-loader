using AutoMapper;
using CleanArchTemplate.ApiModels.Customer;
using CleanArchTemplate.Core.DTOs.Customer;
using CleanArchTemplate.Core.Services.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CleanArchTemplate.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class CustomerController : ControllerBase
{
    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Get Data From External Api
    /// </summary>
    /// <returns></returns>
    /// <response code="200">The request has succeeded.</response>
    /// <response code="400">The server cannot or will not process the request due to something that is perceived to be a client error (e.g., malformed request syntax, invalid request message framing, or deceptive request routing).</response>
    /// <response code="401">The request has not been applied because it lacks valid authentication credentials for the target resource.</response>
    /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request.</response>     
    [HttpPost]
    [ProducesResponseType(typeof(CustomerResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetCustomerAsync([FromBody] CustomerRequestModel request)
    {
        CustomerRequestDTO apiRequestModel = _mapper.Map<CustomerRequestModel, CustomerRequestDTO>(request);
        CustomerResponseDTO apiResponseModel = await _customerService.GetDataFromExternalApiAsync(apiRequestModel);
        CustomerResponseModel response = _mapper.Map<CustomerResponseDTO, CustomerResponseModel>(apiResponseModel);
        return Ok(response);
    }
}