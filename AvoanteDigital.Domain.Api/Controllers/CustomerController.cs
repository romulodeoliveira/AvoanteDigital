using AvoanteDigital.Domain.Api.Models.Customer;
using AvoanteDigital.Domain.Api.Models.Responses;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Domain.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AvoanteDigital.Domain.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : BaseController
{
    private IBaseService<Customer> _baseCustomerService;

    public CustomerController(IBaseService<Customer> baseCustomerService)
    {
        _baseCustomerService = baseCustomerService;
    }

    [HttpGet]
    public IActionResult PullAllData()
    {
        return Execute(() => _baseCustomerService.Get<GetCustomerModel>());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCustomerModel customer)
    {
        return Execute(() => _baseCustomerService.Add<CreateCustomerModel, CustomerModel, CustomerValidator>(customer));
    }
}