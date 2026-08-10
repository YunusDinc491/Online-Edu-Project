using OnlineEdu.WebUI.DTOS.TeacherSocialDtos;
using System.Collections.Generic;

namespace OnlineEdu.WebUI.DTOS.UserDtos
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public List<ResultTeacherSocialDto> TeacherSocials { get; set; } = new();
    }
}
