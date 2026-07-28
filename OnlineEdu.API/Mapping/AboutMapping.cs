using AutoMapper;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class AboutMapping : Profile

    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

        }
    }
}
