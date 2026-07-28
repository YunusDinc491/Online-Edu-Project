using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.DTO.DTOS.Banner_Dtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _bannerService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _bannerService.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _bannerService.TDelete(id);

            return Ok("Banner alanı silindi");
        }


        [HttpPost]

        public IActionResult Create(CreateBannerDTO createBannerDto)
        {
            var newValue = _mapper.Map<Banner>(createBannerDto);
            _bannerService.TCreate(newValue);
            return Ok("Banner alanı oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateBannerDTO updateBannerDto)
        {
            var Value = _mapper.Map<Banner>(updateBannerDto);
            _bannerService.TUpdate(Value);
            return Ok("Banner alanı güncellendi");
        }
    }
}
