using AvoanteDigital.Domain.Api.Models.User;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Domain.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AvoanteDigital.Domain.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IBaseService<User> _baseUserService;
    
    public UserController(IBaseService<User> baseUserService)
    {
        _baseUserService = baseUserService;
    }

    [HttpPost]
    public IActionResult Register([FromBody] CreateUserModel user)
    {
        return Execute(() => _baseUserService.Add<CreateUserModel, UserModel, UserValidator>(user));
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