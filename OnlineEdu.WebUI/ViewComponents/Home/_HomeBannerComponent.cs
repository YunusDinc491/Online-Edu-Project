using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.Banner_Dtos;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeBannerComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeBannerComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners") ?? new List<ResultBannerDto>();
            return View(values);
        }
    }
}
