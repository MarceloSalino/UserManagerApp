using AutoMapper;
using UserManagerApp.Application.DTOs;
using UserManagerApp.Domain.Entities;

namespace UserManagerApp.Application.Mappings;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, UsuarioDto>();

        CreateMap<UsuarioDto, Usuario>()
            .ConstructUsing(dto => new Usuario(dto.Nome, dto.ValorHora, dto.Ativo));
    }
}