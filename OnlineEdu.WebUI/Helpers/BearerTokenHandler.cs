using OnlineEdu.WebUI.Services.TokenServices;
using System.Net.Http.Headers;

namespace OnlineEdu.WebUI.Helpers
{
    public class BearerTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BearerTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenService = _httpContextAccessor.HttpContext?.RequestServices.GetService(typeof(ITokenService)) as ITokenService;
            var token = tokenService?.GetUserToken;

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
