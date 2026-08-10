using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.DTO.DTOS.TestimonialDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IGenericService<Testimonial> _testimonialService , IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _testimonialService.TDelete(id);

            return Ok("Testimonial silindi");
        }


        [HttpPost]

        public IActionResult Create(CreateTestimonialDto createTestimonialDto)
        {
            var newValue = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TCreate(newValue);
            return Ok("Yeni testimonial oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var Value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(Value);
            return Ok("Testimonial güncellendi");
        }

        [HttpGet("GetTestimonialCount")]
        public IActionResult GetTestimonialCount()
        {
            var count = _testimonialService.TTCount();
            return Ok(count);
        }
    }
}
