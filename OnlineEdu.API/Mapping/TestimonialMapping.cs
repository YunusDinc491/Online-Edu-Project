using AutoMapper;
using OnlineEdu.DTO.DTOS.TestimonialDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class TestimonialMapping :Profile
    {
        public TestimonialMapping()
        {
            CreateMap<CreateTestimonialDto , Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();

        }
    }
}
