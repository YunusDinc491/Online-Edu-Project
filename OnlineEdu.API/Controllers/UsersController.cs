using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.UserDTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, IJwtService _jwtService, IMapper _mapper) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Bu Email Sistemde Kayıtlı Değil");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
            }

            var token = await _jwtService.CreateTokenAsync(user);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, "Student");
            return Ok("Kullanıcı Kaydı Başarılı");
        }

        [HttpGet("TeacherList")]
        public async Task<IActionResult> TeacherList()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            return Ok(_mapper.Map<List<ResultUserDto>>(teachers));
        }

        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            return Ok(_mapper.Map<List<ResultUserDto>>(students));
        }

        [HttpGet("Get4Teachers")]
        public async Task<IActionResult> Get4Teachers()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            var last4 = teachers.OrderByDescending(x => x.Id).Take(4).ToList();
            return Ok(_mapper.Map<List<ResultUserDto>>(last4));
        }
    }
}
