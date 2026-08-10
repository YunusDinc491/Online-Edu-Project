using System.Collections.Generic;

namespace OnlineEdu.DTO.DTOS.UserDTOS
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
