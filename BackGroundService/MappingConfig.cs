using AutoMapper;
using BackGroundTask.Modelos.Dto;
using BackGroundTask.Modelos;

namespace BackGroundTask
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<UsuarioAplicacion, UsuarioDto>().ReverseMap();
        }
    }
}
