using AutoMapper;
using GodRift.API.Models;
using GodRift.API.DTOs;

namespace GodRift.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Players, PlayerDTO>();
            CreateMap<CreatePlayerDTO, Players>();
            CreateMap<Users, UserDTO>();
            CreateMap<CreateUserDTO, Users>()
                .ForMember(dest => dest.HashPassword, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
