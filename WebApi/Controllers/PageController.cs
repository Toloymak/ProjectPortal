using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PageService : EntityControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var res = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer()
            {
                ClientSecrets = new ClientSecrets()
                {
                    ClientId = "",
                    ClientSecret = ""
                },
                Scopes = new []{"https://www.googleapis.com/auth/gmail.labels"}
            }).CreateAuthorizationCodeRequest("https://testlocalhost.net");

            return res.Build().AbsoluteUri;
        }
    }
}