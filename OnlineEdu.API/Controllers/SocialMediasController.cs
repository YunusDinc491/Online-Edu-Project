using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(IGenericService<SocialMedia> _socialMediaService , IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _socialMediaService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _socialMediaService.TDelete(id);

            return Ok("Sosyal medya silindi");
        }


        [HttpPost]

        public IActionResult Create(CreateSocialMedia createSocialMedia)
        {
            var newValue = _mapper.Map<SocialMedia>(createSocialMedia);
            _socialMediaService.TCreate(newValue);
            return Ok("Yeni sosyal medya oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateSocialMedia updateSocialMedia)
        {
            var Value = _mapper.Map<SocialMedia>(updateSocialMedia);
            _socialMediaService.TUpdate(Value);
            return Ok("Sosyal medya güncellendi");
        }

    }
}
