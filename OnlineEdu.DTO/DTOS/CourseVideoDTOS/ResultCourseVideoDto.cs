using OnlineEdu.DTO.DTOS.CourseDTOS;

namespace OnlineEdu.DTO.DTOS.CourseVideoDTOS
{
    public class ResultCourseVideoDto
    {
        public int CourseVideoId { get; set; }

        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }

        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }
    }
}
