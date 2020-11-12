using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PageService : EntityControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Ok!";
        }
    }
}