using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kinder_Backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllData ()
        {
            var result = new TestItem {Id = 1, Name = "Michelle"};
            return new JsonResult (result);
        }
    }
}
    internal class TestItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
