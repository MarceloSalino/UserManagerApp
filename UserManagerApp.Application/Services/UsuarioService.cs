using AutoMapper;
using UserManagerApp.Application.DTOs;
using UserManagerApp.Application.Interfaces;
using UserManagerApp.Domain.Entities;
using UserManagerApp.Domain.Interfaces;

namespace UserManagerApp.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<UsuarioDto>> Listar()
    {
        var usuarios = await _repo.ObterTodos();
        return _mapper.Map<List<UsuarioDto>>(usuarios);
    }

    public async Task<UsuarioDto?> ObterPorId(int id)
    {
        var usuario = await _repo.ObterPorId(id);
        return usuario == null ? null : _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task Criar(UsuarioDto dto)
    {
        var usuario = new Usuario(dto.Nome, dto.ValorHora, dto.Ativo);
        await _repo.Adicionar(usuario);
    }

    public async Task Editar(UsuarioDto dto)
    {
        var usuario = await _repo.ObterPorId(dto.Id);

        if (usuario == null)
            throw new Exception("Usuário não encontrado");

        usuario.Atualizar(dto.Nome, dto.ValorHora, dto.Ativo);

        await _repo.Atualizar(usuario);
    }

    public async Task Excluir(int id)
    {
        var usuario = await _repo.ObterPorId(id);

        if (usuario == null)
            throw new Exception("Usuário não encontrado");

        await _repo.Remover(usuario);
    }
}