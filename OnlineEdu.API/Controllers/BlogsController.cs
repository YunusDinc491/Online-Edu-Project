using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.DTO.DTOS.BlogDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IBlogService blogService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = blogService.TGetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = blogService.TGetBlogWithCategory(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            blogService.TDelete(id);

            return Ok("Blog silindi");
        }


        [HttpPost]

        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newValue = _mapper.Map<Blog>(createBlogDto);
            blogService.TCreate(newValue);
            return Ok("Yeni Blog oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var Value = _mapper.Map<Blog>(updateBlogDto);
            blogService.TUpdate(Value);
            return Ok("Blog güncellendi");
        }

        [HttpGet("GetLast4Blogs")]
        public IActionResult GetLast4Blogs()
        {
            var values = blogService.TGetLast4BlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }

        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var blogCount = blogService.TTCount();
            return Ok(blogCount);
        }

        [HttpGet("GetBlogsByCategoryId/{id}")]
        public IActionResult GetBlogsByCategoryId(int id)
        {
            var values = blogService.TGetBlogsByCategoryId(id);
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }

        [HttpGet("GetBlogByWriterId/{id}")]
        public IActionResult GetBlogByWriterId(int id)
        {
            var values = blogService.TGetBlogsWithCategoriesByWriterId(id);
            var mappedValues = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(mappedValues);
        }
    }
}
