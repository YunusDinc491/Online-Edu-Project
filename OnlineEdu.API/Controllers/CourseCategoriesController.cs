using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.DTO.DTOS.CourseCategoryDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(ICourseCategoryService _courseCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseCategoryService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseCategoryService.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _courseCategoryService.TDelete(id);

            return Ok();
        }


        [HttpPost]

        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDto);
            _courseCategoryService.TCreate(newValue);
            return Ok("Yeni course category oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var Value = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
            _courseCategoryService.TUpdate(Value);
            return Ok("Course category güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseCategoryService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseCategoryService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _courseCategoryService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("GetCourseCategoryCount")]
        public IActionResult GetCourseCategoryCount()
        {
            var count = _courseCategoryService.TTCount();
            return Ok(count);
        }
    }
}
