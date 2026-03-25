namespace UserManagerApp.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public decimal ValorHora { get; private set; }

    public DateTime DataCadastro { get; private set; }

    public bool Ativo { get; private set; }



    // Construtor para EF
    protected Usuario() { }


    // Construtor
    public Usuario(string nome, decimal valorHora, bool ativo)
    {
        Validar(nome, valorHora);

        Nome = nome;
        ValorHora = valorHora;
        Ativo = ativo;
        DataCadastro = DateTime.UtcNow;
    }


    // Método de atualização controlada
    public void Atualizar(string nome, decimal valorHora, bool ativo)
    {
        Validar(nome, valorHora);

        Nome = nome;
        ValorHora = valorHora;
        Ativo = ativo;
    }


    // Regras específicas
    public void Ativar() => Ativo = true;

    public void Desativar() => Ativo = false;


    // Validação centralizada
    private void Validar(string nome, decimal valorHora)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório");

        if (nome.Length > 150)
            throw new ArgumentException("Nome deve ter até 150 caracteres");

        if (valorHora <= 0)
            throw new ArgumentException("ValorHora deve ser maior que zero");
    }
}