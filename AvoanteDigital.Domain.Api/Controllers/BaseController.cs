using AvoanteDigital.Domain.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AvoanteDigital.Domain.Api.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult Execute(Func<object> func)
    {
        try
        {
            var result = func();
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Operação realizada com sucesso.",
                Data = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse
            {
                Success = false,
                Message = "Ocorreu um erro inesperado ao processar sua solicitação.",
                Data = null
            });
        }
    }
}