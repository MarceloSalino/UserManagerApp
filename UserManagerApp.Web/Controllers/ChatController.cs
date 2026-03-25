using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace UserManagerApp.Web.Controllers;

[Route("chat")]
public class ChatController : Controller
{
    private readonly List<HelpItem> _help;

    public ChatController(IWebHostEnvironment env)
    {
        var path = Path.Combine(env.ContentRootPath, "help.json");

        var json = System.IO.File.ReadAllText(path);

        _help = JsonSerializer.Deserialize<List<HelpItem>>(json)!;
    }


    [HttpPost]
    public IActionResult Perguntar([FromBody] string pergunta)
    {
        if (string.IsNullOrWhiteSpace(pergunta))
            return Ok("Pergunta vazia");

        pergunta = pergunta.ToLower();

        var resposta = _help.FirstOrDefault(x =>
            Normalizar(pergunta).Contains(Normalizar(x.Pergunta))
        );

        if (resposta == null)
            return Ok("Não encontrei essa informação.");

        return Ok(resposta.Resposta);
    }

    string Normalizar(string texto)
    {
        return texto
            .ToLower()
            .Replace("á", "a")
            .Replace("é", "e")
            .Replace("í", "i")
            .Replace("ó", "o")
            .Replace("ú", "u");
    }
}

public class HelpItem
{
    public string Pergunta { get; set; } = "";
    public string Resposta { get; set; } = "";
}