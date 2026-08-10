using Microsoft.AspNetCore.Identity;
using OnlineEdu.WebUI.DTOS.UserDtos;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            var result = await _client.PostAsJsonAsync("roleAssigns", assignRoleDto);
            return result.IsSuccessStatusCode;
        }

        public Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            return await _client.GetFromJsonAsync<List<UserViewModel>>("roleAssigns");
        }

        public async Task<List<AssignRoleDto>> GetUserForRoleAssign(int id)
        {
            return await _client.GetFromJsonAsync<List<AssignRoleDto>>("roleAssigns/" + id);
        }

        public async Task<List<ResultUserDto>> GetAllTeachers()
        {
            return await _client.GetFromJsonAsync<List<ResultUserDto>>("users/TeacherList") ?? new List<ResultUserDto>();
        }

        public Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
