using UserManagerApp.Application.DTOs;

namespace UserManagerApp.Application.Interfaces;

public interface IUsuarioService
{
    Task<List<UsuarioDto>> Listar();

    Task<UsuarioDto?> ObterPorId(int id);

    Task Criar(UsuarioDto dto);

    Task Editar(UsuarioDto dto);

    Task Excluir(int id);
}