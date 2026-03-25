using Microsoft.AspNetCore.Mvc;
using UserManagerApp.Application.DTOs;
using UserManagerApp.Application.Interfaces;

namespace UserManagerApp.Web.Controllers;

[Route("usuario")]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _service;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(IUsuarioService service, ILogger<UsuarioController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var usuarios = await _service.Listar();
        return Json(usuarios);
    }

    [HttpPost("criar")]
    public async Task<IActionResult> Criar([FromBody] UsuarioDto dto)
    {
        try
        {
            if (dto == null)
                return BadRequest("DTO veio nulo");

            await _service.Criar(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar usuário");
            return StatusCode(500, "Erro ao criar usuário");
        }
    }

    [HttpPost("editar")]
    public async Task<IActionResult> Editar([FromBody] UsuarioDto dto)
    {
        try
        {
            if (dto == null || dto.Id == 0)
                return BadRequest("Dados inválidos");

            await _service.Editar(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao editar usuário");
            return StatusCode(500);
        }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            await _service.Excluir(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir usuário");
            return StatusCode(500);
        }
    }
}