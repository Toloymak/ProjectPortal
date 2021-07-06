using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Types.Models;
using Web.Models.Configs;

namespace Web.Services
{
    public interface ILoginService
    {
        Task<ExecutionResult> Login(LoginModel loginModel);
    }

    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<LoginService> _logger;

        public LoginService(IConfiguration configuration,
                            HttpClient httpClient,
                            ILogger<LoginService> logger)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ExecutionResult> Login(LoginModel loginModel)
        {
            var sectionConfig = _configuration.Get<ConfigModel>();
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{sectionConfig.Server.Url}auth/login"),
                Content = JsonContent.Create(loginModel)
            };
        
            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadFromJsonAsync<LoginResultModel>();
                if (loginResult == null)
                    throw new NullReferenceException("Login result cannot be null");
                
                _logger.LogInformation($"Authorized. Login: {loginResult.Person.Login}");
                return ExecutionResult.CreateSuccessResult();
            }
            
            return ExecutionResult.CreateErrorResult($"Error: {response.ReasonPhrase} ({(int) response.StatusCode})");
        }
    }
}