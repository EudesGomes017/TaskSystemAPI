using AutoMapper;
using Domain.Dto;
using Domain.Models;

namespace Domain.Helps
{
    public class ApiSistemaProfile : Profile
    {
        public ApiSistemaProfile()
        {
            CreateMap<ModelUser, ModelUserDto>().ReverseMap();
            CreateMap<ModelTask, ModelTaskDto>().ReverseMap();
        }
    }
}
