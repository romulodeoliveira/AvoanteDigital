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
    
    // TODO Get All Users
    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        return await ExecuteAsync(() => _baseUserService.GetAsync<GetUserModel>());
    }
    
    [HttpGet("get-user-by-id")]
    public async Task<IActionResult> GetUserById(string email)
    {
        return await ExecuteAsync(() => _userService.GetUserByEmailAsync<GetUserModel>(email));
    }
    
    // TODO Update User
    [Authorize(Policy = "AdminAndManager")]
    [HttpPut("update-profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileModel request)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        return await ExecuteAsync(() => _userService.UpdateUserProfileAsync<UpdateProfileValidator, UpdateProfileModel>(request, email));
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("update-user-activity")]
    public async Task<IActionResult> UpdateUserActivity([FromBody] UserActivityModel request, string email)
    {
        return await ExecuteAsync(() => _userService.UpdateUserActivityAsync<UpdateUserActivityValidator, UserActivityModel>(request, email));
    }
    
    // TODO Delete User
    [Authorize(Policy = "AdminAndManager")]
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser(string email)
    {
        return null;
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