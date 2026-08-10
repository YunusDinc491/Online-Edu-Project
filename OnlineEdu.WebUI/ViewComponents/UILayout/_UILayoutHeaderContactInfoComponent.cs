using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.ContacDTOS;

namespace OnlineEdu.WebUI.ViewComponents.UILayout
{
    public class _UILayoutHeaderContactInfoComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _UILayoutHeaderContactInfoComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts") ?? new List<ResultContactDto>();
            return View(values);
        }
    }
}
