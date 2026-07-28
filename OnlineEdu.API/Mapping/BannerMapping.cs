using AutoMapper;
using OnlineEdu.DTO.DTOS.Banner_Dtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<CreateBannerDTO, Banner>().ReverseMap();
            CreateMap<UpdateBannerDTO, Banner>().ReverseMap();

        }
    }
}
