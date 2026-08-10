using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.DTO.DTOS.CourseDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseService.TGetAllCoursesWithCategories();
            var courses = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseService.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _courseService.TDelete(id);

            return Ok();
        }


        [HttpPost]

        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var newValue = _mapper.Map<Course>(createCourseDto);
            _courseService.TCreate(newValue);
            return Ok("Yeni course oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var Value = _mapper.Map<Course>(updateCourseDto);
            _courseService.TUpdate(Value);
            return Ok("Course güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetActiveCourses")]
        public IActionResult GetActiveCourses()
        {
            var values = _courseService.TGetAllCoursesWithCategories(x => x.IsShown == true);
            var courses = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(courses);
        }

        [HttpGet("GetCourseCount")]
        public IActionResult GetCourseCount()
        {
            var courseCount = _courseService.TTCount();
            return Ok(courseCount);
        }

        [HttpGet("GetCoursesByCategoryId/{id}")]
        public IActionResult GetCoursesByCategoryId(int id)
        {
            var values = _courseService.TGetAllCoursesWithCategories(x => x.CourseCategoryId == id);
            var courses = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(courses);
        }

        [HttpGet("GetCoursesByTeacherId/{id}")]
        public IActionResult GetCoursesByTeacherId(int id)
        {
            var values = _courseService.TGetCoursesByTeacherId(id);
            var mappedValues = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(mappedValues);
        }
    }
}
