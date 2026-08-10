using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.Banner_Dtos;
using OnlineEdu.WebUI.DTOS.BlogCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _client.DeleteAsync($"banners/{id}");
            return RedirectToAction((nameof(Index)));
        }
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDTO createBannerDto)
        {
            await _client.PostAsJsonAsync("banners", createBannerDto);
            return RedirectToAction((nameof(Index)));
        }
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBannerDTO>($"banners/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDTO updateBannerDto)
        {
            await _client.PutAsJsonAsync("banners", updateBannerDto);
            return RedirectToAction((nameof(Index)));
        }
    }
}
