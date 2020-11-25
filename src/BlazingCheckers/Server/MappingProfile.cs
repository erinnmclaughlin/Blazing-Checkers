using AutoMapper;
using BlazingCheckers.Server.Data.Entities;
using BlazingCheckers.Shared.Dtos;

namespace BlazingCheckers.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameDto>();
        }
    }
}
