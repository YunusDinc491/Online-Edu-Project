using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Entity.Entities;
using AutoMapper;
using OnlineEdu.DTO.DTOS.About_DTOS;


namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _aboutService.TDelete(id);

            return Ok();
        }


        [HttpPost]

        public IActionResult Create(CreateAboutDto createAboutDto)
        {
            var newValue = _mapper.Map<About>(createAboutDto);
            _aboutService.TCreate(newValue);
            return Ok("Yeni about oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            var Value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(Value);
            return Ok("About güncellendi");
        }


    }
}
