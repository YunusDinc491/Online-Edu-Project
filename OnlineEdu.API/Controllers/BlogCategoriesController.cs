using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.DTO.DTOS.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IGenericService<BlogCategory> _blogCategoryService , IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogCategoryService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _blogCategoryService.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _blogCategoryService.TDelete(id);

            return Ok();
        }


        [HttpPost]

        public IActionResult Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var newValue = _mapper.Map<BlogCategory>(createBlogCategoryDto);
            _blogCategoryService.TCreate(newValue);
            return Ok("Yeni BlogCategory oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var Value = _mapper.Map<BlogCategory>(updateBlogCategoryDto);
            _blogCategoryService.TUpdate(Value);
            return Ok("BlogCategory güncellendi");
        }
    }
}
