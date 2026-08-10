using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.Social_Media_DTOS;

namespace OnlineEdu.WebUI.ViewComponents.UILayout
{
    public class _UILayoutHeaderSocialMediaComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _UILayoutHeaderSocialMediaComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedias") ?? new List<ResultSocialMediaDto>();
            return View(values);
        }
    }
}
