using Microsoft.AspNetCore.Identity;
using OnlineEdu.WebUI.DTOS.UserDtos;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);

        Task<string> LoginAsync(UserLoginDto userLoginDto);
        Task LogoutAsync();

        Task<List<UserViewModel>> GetAllUsersAsync();

        Task<List<AssignRoleDto>> GetUserForRoleAssign(int id);

        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);

        Task<List<ResultUserDto>> GetAllTeachers();
    }
}
