using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.CourseDTOS;

namespace OnlineEdu.WebUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses") ?? new List<ResultCourseDto>();
            return View(courses);
        }

        public async Task<IActionResult> GetCoursesByCategoryId(int id)
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetCoursesByCategoryId/" + id) ?? new List<ResultCourseDto>();
            var category = (from x in courses
                             select x.CourseCategory.CategoryName).FirstOrDefault();
            ViewBag.category = category;
            return View(courses);
        }
    }
}
