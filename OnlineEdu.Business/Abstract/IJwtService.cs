using OnlineEdu.DTO.DTOS.UserDTOS;
using OnlineEdu.Entity.Entities;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Abstract
{
    public interface IJwtService
    {
        Task<LoginResponseDto> CreateTokenAsync(AppUser user);
    }
}
