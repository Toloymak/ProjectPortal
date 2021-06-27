using System;
using Microsoft.AspNetCore.Mvc;
using Types.Models;
using WebApi.TestData;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlocksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(TestBlockModels.BlockModels);
        }

        [HttpGet]
        [Route("{blockId}")]
        public IActionResult Get(Guid blockId)
        {
            return Ok(new BlockModel());
        }
    }
}