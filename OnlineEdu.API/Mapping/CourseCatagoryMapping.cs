using AutoMapper;
using OnlineEdu.DTO.DTOS.CourseCategoryDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseCatagoryMapping : Profile
    {
        public CourseCatagoryMapping()
        {
            CreateMap<CreateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<ResultCourseCategoryDto, CourseCategory>().ReverseMap();
        }
    }
}
