using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.LoginDtos;
using OnlineEdu.WebUI.DTOS.UserDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _client;

        public LoginController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var result = await _client.PostAsJsonAsync("users/login", userLoginDto);
            if (!result.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View(userLoginDto);
            }

            var handler = new JwtSecurityTokenHandler();
            var response = await result.Content.ReadFromJsonAsync<LoginResponseDto>();
            var token = handler.ReadJwtToken(response.Token);
            var claims = token.Claims.ToList();

            if (response.Token != null)
            {
                claims.Add(new Claim("Token", response.Token));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    ExpiresUtc = response.ExpireDate,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            return View(userLoginDto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
