using AutoMapper;
using OnlineEdu.DTO.DTOS.CourseRegisterDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseRegisterMapping : Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<CreateCourseRegisterDto, CourseRegister>().ReverseMap();
            CreateMap<UpdateCourseRegisterDto, CourseRegister>().ReverseMap();
            CreateMap<ResultCourseRegisterDto, CourseRegister>().ReverseMap();
        }
    }
}
