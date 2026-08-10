using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.UserDTOS;
using OnlineEdu.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrete
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, IMapper _mapper) : IUserService
    {
        public async Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto)
        {
            var user = _mapper.Map<AppUser>(userRegisterDto);

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
            }

            return result;
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<List<ResultUserDto>> GetAllTeachers()
        {
            var users = await _userManager.Users.ToListAsync();
            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Result).ToList();
            return _mapper.Map<List<ResultUserDto>>(teachers);
        }

        public async Task<int> GetTeacherCount()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            return teachers.Count();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> LoginAsync(LoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);
            if (!result.Succeeded)
            {
                return null;
            }

            if (await _userManager.IsInRoleAsync(user, "Admin")) return "Admin";
            if (await _userManager.IsInRoleAsync(user, "Teacher")) return "Teacher";
            if (await _userManager.IsInRoleAsync(user, "Student")) return "Student";

            return null;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
