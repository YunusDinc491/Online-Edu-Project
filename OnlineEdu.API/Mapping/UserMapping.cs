using AutoMapper;
using OnlineEdu.DTO.DTOS.UserDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, ResultUserDto>();
        }
    }
}
