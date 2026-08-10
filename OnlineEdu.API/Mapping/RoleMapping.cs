using AutoMapper;
using OnlineEdu.DTO.DTOS.RoleDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<CreateRoleDto, AppRole>();
        }
    }
}
