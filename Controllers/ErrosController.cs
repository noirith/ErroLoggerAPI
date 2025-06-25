using Microsoft.AspNetCore.Mvc;
using ErroLoggerAPI.Models;
using ErroLoggerAPI.Services;

namespace ErroLoggerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrosController : ControllerBase
{
    private readonly ErroService _erroService;

    public ErrosController(ErroService erroService)
    {
        _erroService = erroService;
    }

    [HttpPost]
    public async Task<IActionResult> SalvarErro([FromBody] ErroReportado erro)
    {
        await _erroService.SalvarErroAsync(erro);
        return Ok(erro);
    }

    [HttpGet]
public async Task<IActionResult> ObterErros()
{
    var erros = await _erroService.ObterErrosAsync();
    return Ok(erros);
}
}