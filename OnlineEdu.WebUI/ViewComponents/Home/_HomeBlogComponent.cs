using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.BlogDTOS;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeBlogComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeBlogComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetLast4Blogs") ?? new List<ResultBlogDto>();
            return View(values);
        }
    }
}
