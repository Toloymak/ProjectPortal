using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Portal.Server.TestData;
using Types.Models;

namespace Portal.Server.Controllers
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
            return Ok(new BlockModel()
            {
                Links = new List<LinkModel>()
                {
                    new LinkModel()
                    {
                        Description = "Test",
                        Link = "test",
                        Order = 2,
                        Title = "Test title"
                    },
                    new LinkModel()
                    {
                        Description = "Test",
                        Link = "test",
                        Order = 2,
                        Title = "Test title"
                    }
                }
            });
        }
    }
}