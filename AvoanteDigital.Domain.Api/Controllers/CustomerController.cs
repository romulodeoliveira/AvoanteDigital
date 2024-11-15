using AvoanteDigital.Domain.Api.Models;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Domain.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AvoanteDigital.Domain.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private IBaseService<Customer> _baseCustomerService;

    public CustomerController(IBaseService<Customer> baseCustomerService)
    {
        _baseCustomerService = baseCustomerService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCustomerModel customer)
    {
        return Execute(() => _baseCustomerService.Add<CreateCustomerModel, CustomerModel, CustomerValidator>(customer));
    }

    private IActionResult Execute(Func<object> func)
    {
        try
        {
            var result = func();
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