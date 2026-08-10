using System;

namespace OnlineEdu.DTO.DTOS.UserDTOS
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
