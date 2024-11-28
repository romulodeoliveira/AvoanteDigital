using AvoanteDigital.Api.Models.Customer;
using AvoanteDigital.Api.Models.Responses;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AvoanteDigital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private IBaseService<Customer> _baseCustomerService;

    public CustomerController(IBaseService<Customer> baseCustomerService)
    {
        _baseCustomerService = baseCustomerService;
    }

    [HttpGet("pull-all-data")]
    public async Task<IActionResult> PullAllDataAsync()
    {
        return await ExecuteAsync(() => _baseCustomerService.GetAsync<GetCustomerModel>());
    }

    [HttpPost("submit-data")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerModel customer)
    {
        return await ExecuteAsync(() => _baseCustomerService.AddAsync<CreateCustomerModel, CustomerModel, CustomerValidator>(customer));
    }
    
    private async Task<IActionResult> ExecuteAsync<T>(Func<Task<T>> func)
    {
        try
        {
            var result = await func();
            return Ok(result);
        }
        catch (Exception error)
        {
            return BadRequest(new 
            {
                Message = "Ocorreu um erro ao processar a solicitação.",
                Details = error.Message
            });
        }
    }
}