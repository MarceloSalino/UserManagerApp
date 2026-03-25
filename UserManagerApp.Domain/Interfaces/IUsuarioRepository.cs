using UserManagerApp.Domain.Entities;

namespace UserManagerApp.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<List<Usuario>> ObterTodos();

    Task<Usuario?> ObterPorId(int id);

    Task Adicionar(Usuario usuario);

    Task Atualizar(Usuario usuario);

    Task Remover(Usuario usuario);
}