using AvoanteDigital.Api.Models.User;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
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

    [Authorize(Policy = "IsActiveAndAdmin")]
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
    
    [Authorize(Policy = "IsActiveAndAdmin")]
    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        return await ExecuteAsync(() => _baseUserService.GetAsync<GetUserModel>());
    }
    
    [Authorize(Policy = "IsActiveAndAdmin")]
    [HttpGet("get-user-by-id")]
    public async Task<IActionResult> GetUserById(string email)
    {
        return await ExecuteAsync(() => _userService.GetUserByEmailAsync<GetUserModel>(email));
    }
    
    [Authorize(Policy = "IsActiveAndAdminAndManager")]
    [HttpPut("update-profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileModel request)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        return await ExecuteAsync(() => _userService.UpdateUserProfileAsync<UpdateProfileValidator, UpdateProfileModel>(request, email));
    }

    [Authorize(Policy = "IsActiveAndAdmin")]
    [HttpPut("update-user-activity")]
    public async Task<IActionResult> UpdateUserActivity([FromBody] UserActivityModel request, string email)
    {
        return await ExecuteAsync(() => _userService.UpdateUserActivityAsync<UpdateUserActivityValidator, UserActivityModel>(request, email));
    }
    
    [Authorize(Policy = "IsActiveAndAdmin")]
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser(string email)
    {
        return await ExecuteAsync(() => _userService.DeleteUserAsync(email));
    }
    
    private async Task<IActionResult> ExecuteAsync<T>(Func<Task<T>> func)
    {
        try
        {
            var result = await func();
            return Ok(result);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized(new 
            {
                Message = "Você não tem permissão para acessar este recurso."
            });
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