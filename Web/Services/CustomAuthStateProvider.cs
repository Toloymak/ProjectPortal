using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Types.Models;

namespace Web.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public CustomAuthStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var responseMessage = await _httpClient.GetAsync("auth/me");

            if (!responseMessage.IsSuccessStatusCode)
                return new AuthenticationState(new ClaimsPrincipal());

            var model = responseMessage.Content.ReadFromJsonAsync<PersonModel>().Result;

            if (model == null)
                return new AuthenticationState(new ClaimsPrincipal());

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, model.Login)
            }, "Test authentication type");

            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
    }
}