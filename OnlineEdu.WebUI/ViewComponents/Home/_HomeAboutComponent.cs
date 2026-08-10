using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.About_DTOS;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeAboutComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts") ?? new List<ResultAboutDto>();
            return View(about);
        }
    }
}
