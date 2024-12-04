using AvoanteDigital.Api.Models.Campaign;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AvoanteDigital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EbookController : ControllerBase
{
    private IBaseService<Ebook> _baseEbookService;

    public EbookController(IBaseService<Ebook> baseCustomerService)
    {
        _baseEbookService = baseCustomerService;
    }
    
    // https://base64.guru/converter/encode/pdf
    [HttpPost("submit-data")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEbookModel request)
    {
        return await ExecuteAsync(() => _baseEbookService.AddAsync<CreateEbookModel, CreateEbookValidator>(request));
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