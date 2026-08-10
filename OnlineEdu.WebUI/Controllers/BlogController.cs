using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.BlogDTOS;
using OnlineEdu.WebUI.DTOS.Subscriber_DTOS;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client;

        public BlogController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto model)
        {
            await _client.PostAsJsonAsync("subscribers", model);
            return NoContent();
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _client.GetFromJsonAsync<ResultBlogDto>("blogs/" + id);
            return View(blog);
        }

        public async Task<IActionResult> BlogsByCategory(int id)
        {
            var blogs = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetBlogsByCategoryId/" + id) ?? new List<ResultBlogDto>();
            ViewBag.categoryName = blogs.Select(x => x.blogCategory?.Name).FirstOrDefault();
            return View(blogs);
        }
    }
}
