using AutoMapper;
using OnlineEdu.DTO.DTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<CreateSocialMedia, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMedia, SocialMedia>().ReverseMap();
        }
    }
}
