using AutoMapper;
using MySecrets.Dtos;
using MySecrets.Models;

namespace MySecrets.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Tajne, TajneDto>().ReverseMap();
            CreateMap<Tajne,GetTajneDto>().ReverseMap();
        }
    }
}
