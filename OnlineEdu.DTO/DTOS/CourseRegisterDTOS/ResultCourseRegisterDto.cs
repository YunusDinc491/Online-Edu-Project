using OnlineEdu.DTO.DTOS.CourseDTOS;
using OnlineEdu.DTO.DTOS.UserDTOS;

namespace OnlineEdu.DTO.DTOS.CourseRegisterDTOS
{
    public class ResultCourseRegisterDto
    {
        public int CourseRegisterId { get; set; }

        public int AppUserId { get; set; }
        public ResultUserDto AppUser { get; set; }

        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
    }
}
