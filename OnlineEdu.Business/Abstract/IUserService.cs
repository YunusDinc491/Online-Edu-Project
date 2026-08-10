using Microsoft.AspNetCore.Identity;
using OnlineEdu.DTO.DTOS.UserDTOS;
using OnlineEdu.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto);

        Task<string> LoginAsync(LoginDto userLoginDto);
        Task LogoutAsync();

        Task<List<AppUser>> GetAllUsersAsync();

        Task<AppUser> GetUserByIdAsync(int id);

        Task<List<ResultUserDto>> GetAllTeachers();

        Task<int> GetTeacherCount();
    }
}
