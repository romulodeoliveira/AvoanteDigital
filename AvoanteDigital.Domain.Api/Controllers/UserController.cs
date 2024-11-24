using AvoanteDigital.Domain.Api.Models.User;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Domain.Service.Services;
using AvoanteDigital.Domain.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvoanteDigital.Domain.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IBaseService<User> _baseUserService;
    private IUserService _userService;
    
    public UserController(IBaseService<User> baseUserService, IUserService userService)
    {
        _baseUserService = baseUserService;
        _userService = userService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("register")]
    public IActionResult Register([FromBody] CreateUserModel user)
    {
        return Execute(() => _baseUserService.Add<CreateUserModel, UserModel, RegisterUserValidator>(user));
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserModel request)
    {
        var (isValid, response) = _userService.CheckCredentials(request.Email, request.Password);
        return isValid 
            ? Ok(new { token = response }) 
            : Unauthorized(new { message = response });
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