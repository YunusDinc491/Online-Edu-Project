using System;

namespace OnlineEdu.WebUI.DTOS.LoginDtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
