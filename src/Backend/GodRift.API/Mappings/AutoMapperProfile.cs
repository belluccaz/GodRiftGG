using AutoMapper;
using GodRift.API.Models;
using GodRift.API.DTOs;
using GodRiftGG.API.Models;
using GodRiftGG.API.DTOs;

namespace GodRift.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Player, PlayerDTO>();
            CreateMap<CreatePlayerDTO, Player>();
            CreateMap<User, UserDTO>();
            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.HashPassword, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<Lane, ReadLaneDTO>();
            CreateMap<ReadLaneDTO, Lane>();
        }
    }
}
