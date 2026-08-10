using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.ContacDTOS;
using OnlineEdu.WebUI.DTOS.MessageDTOS;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts") ?? new List<ResultContactDto>();
            ViewBag.map = values.Select(x => x.MapUrl).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto model)
        {
            await _client.PostAsJsonAsync("messages", model);
            return NoContent();
        }
    }
}
