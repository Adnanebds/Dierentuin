using Dierentuin.Controllers;
using Dierentuin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dierentuin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZooApiController : ZooController
    {
        private readonly ZooContext _dbContext;

        public ZooApiController(ZooContext dbContext, Zoo zoo) : base(dbContext, zoo)
        {
            _dbContext = dbContext;
        }

        [HttpGet("sunrise")]
        public IActionResult Sunrise()
        {
            base.Sunrise();
            return Ok(new { Message = "Sunrise action executed." });
        }

        [HttpGet("sunset")]
        public IActionResult Sunset()
        {
            base.Sunset();
            return Ok(new { Message = "Sunset action executed." });
        }

        [HttpGet("feedingtime")]
        public IActionResult FeedingTime()
        {
            base.FeedingTime();
            return Ok(new { Message = "Feeding time action executed." });
        }

        [HttpGet("checkconstraints")]
        public IActionResult CheckConstraints()
        {
            base.CheckConstraints();
            return Ok(new { Message = "Check constraints action executed." });
        }

        [HttpPost("autoassign")]
        public IActionResult AutoAssign([FromBody] bool completeExisting)
        {
            base.AutoAssign(completeExisting); // Call inherited method for logic
            return Ok(new { Message = "AutoAssign completed." });
        }
    }
}
