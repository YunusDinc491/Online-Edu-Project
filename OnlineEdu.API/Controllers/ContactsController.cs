using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.About_DTOS;
using OnlineEdu.DTO.DTOS.ContacDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _contactService.TDelete(id);

            return Ok("Contact silindi");
        }


        [HttpPost]

        public IActionResult Create(CreateContactDto createContactDto)
        {
            var newValue = _mapper.Map<Contact>(createContactDto);
            _contactService.TCreate(newValue);
            return Ok("Yeni contact oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var Value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(Value);
            return Ok("Contact güncellendi");
        }
    }
}
