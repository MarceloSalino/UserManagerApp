namespace UserManagerApp.Application.DTOs;

public class UsuarioDto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public decimal ValorHora { get; set; }

    public bool Ativo { get; set; }

    public DateTime DataCadastro { get; set; }
}