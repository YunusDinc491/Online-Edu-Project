using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.Social_Media_DTOS;

namespace OnlineEdu.WebUI.ViewComponents.UILayout
{
    public class _UILayoutSocialMedia : ViewComponent
    {
        private readonly HttpClient _client;

        public _UILayoutSocialMedia(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialMedias = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedias") ?? new List<ResultSocialMediaDto>();
            return View(socialMedias);
        }
    }
}
