using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        public Task<IActionResult> GetAsync()
        {
            return Task.FromResult<IActionResult>(new JsonResult(from c in User.Claims select new { c.Type, c.Value }));
        }
    }
}
