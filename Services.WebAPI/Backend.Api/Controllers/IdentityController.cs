using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> logger;

        public IdentityController(ILogger<IdentityController> logger)
        {
            this.logger = logger;
        }

        public Task<IActionResult> GetAsync()
        {
            var test = 10;
            logger.LogInformation("Some text {test}", test);
            return Task.FromResult<IActionResult>(new JsonResult(from c in User.Claims select new { c.Type, c.Value }));
        }
    }
}
