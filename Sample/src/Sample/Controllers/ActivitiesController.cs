using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Services;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ActivityService activityService;

        public ActivitiesController(
            ActivityService activityService
            )
        {
            this.activityService = activityService;
        }

        [HttpPost]
        [Route("apply/{prgId}")]
        public IActionResult Apply(long prgId)
        {
           // this.activityService.Apply(prgId, User?.Identity?.Name);

            return Ok();

            //var result =activityService.List()
        }

        [HttpPost]
        [Route("cancel-apply/{prgId}")]
        public IActionResult CancelApply(long prgId)
        {
            // this.activityService.Apply(prgId, User?.Identity?.Name);

            return Ok();

            //var result =activityService.List()
        }
    }
}
