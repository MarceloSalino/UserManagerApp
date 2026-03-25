using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using UserManagerApp.Domain.Entities;

namespace UserManagerApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.HasKey(u => u.Id);

            entity.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(u => u.ValorHora)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            entity.Property(u => u.DataCadastro)
                .IsRequired();

            entity.Property(u => u.Ativo)
                .IsRequired();
        });
    }
}