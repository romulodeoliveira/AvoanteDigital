using AvoanteDigital.Api.Models.User;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Service.Services;
using AvoanteDigital.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvoanteDigital.Api.Controllers;

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
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUserModel user)
    {
        return await ExecuteAsync(() => _baseUserService.AddAsync<CreateUserModel, UserModel, RegisterUserValidator>(user));
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserModel request)
    {
        var (isValid, response) = await _userService.CheckCredentialsAsync(request.Email, request.Password);
        return isValid 
            ? Ok(new { token = response }) 
            : Unauthorized(new { message = response });
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