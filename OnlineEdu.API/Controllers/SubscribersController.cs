using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.DTO.DTOS.Subscriber_DTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _genericSubscriber , IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _genericSubscriber.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _genericSubscriber.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _genericSubscriber.TDelete(id);

            return Ok();
        }


        [HttpPost]

        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(createSubscriberDto);
            _genericSubscriber.TCreate(newValue);
            return Ok("Yeni subscriber oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateSubscriberDto updateSubscriberDto)
        {
            var Value = _mapper.Map<Subscriber>(updateSubscriberDto);
            _genericSubscriber.TUpdate(Value);
            return Ok("Subscriber güncellendi");
        }
    }
}
