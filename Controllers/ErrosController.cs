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
    public void SalvarErro([FromBody] ErroReportado erro)
    {
        _erroService.SalvarErroAsync(erro);
    }

    [HttpGet]
    public async Task<IActionResult> ObterErros([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
    {
        var erros = await _erroService.ObterErrosPaginadosAsync(pagina, tamanhoPagina);
        return Ok(erros);
    }

}