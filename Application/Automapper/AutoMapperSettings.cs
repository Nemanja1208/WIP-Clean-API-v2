using Application.Dtos.Animal;
using Application.Dtos.Users;
using AutoMapper;
using Domain.Models.Animal;
using Domain.Models.User;

namespace Application.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<AnimalModel, AnimalDto>();
            //CreateMap<UserAnimalModel, UserAnimalDto>();
            CreateMap<UserDto, UserModel>();
            CreateMap<AnimalDto, AnimalModel>();
            //CreateMap<UserAnimalDto, UserAnimalModel>();
            // Add reverse mappings if needed for POST/PUT operations
        }
    }
}
