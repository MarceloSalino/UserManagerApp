using Microsoft.EntityFrameworkCore;
using UserManagerApp.Domain.Entities;
using UserManagerApp.Domain.Interfaces;
using UserManagerApp.Infrastructure.Data;

namespace UserManagerApp.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> ObterTodos()
    {
        return await _context.Usuarios
            .AsNoTracking()
            .OrderBy(u => u.Nome)
            .ToListAsync();
    }

    public async Task<Usuario?> ObterPorId(int id)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task Adicionar(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Remover(Usuario usuario)
    {
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}