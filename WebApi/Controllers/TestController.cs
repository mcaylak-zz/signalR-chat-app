using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Business.Abstract.Chat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Bismillahirrahmanirrahim");
        }
    }
}