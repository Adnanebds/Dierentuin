using Microsoft.AspNetCore.Mvc;
using Dierentuin.Models;
using Microsoft.EntityFrameworkCore;

namespace Dierentuin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalApiController : AnimalController
    {
        public AnimalApiController(ZooContext context) : base(context)
        {
        }


        // Example: Additional API method
        [HttpGet("special")]
        public ActionResult<string> SpecialAnimalAction()
        {
            // Example logic for a special action
            return "This is a special API action for animals.";
        }
    }
}
