using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Models;
using Sample.Services;

namespace Sample.Controllers
{
    [Route("api/activities-api")]
    [ApiController]
    public class ActivitiesApiController : ControllerBase
    {
        private readonly ActivityService activityService;

        public ActivitiesApiController(
            ActivityService activityService
            )
        {
            this.activityService = activityService;
        }

        [HttpGet]
        [Route("list")]

        public List<Activity> List() 
        {
            return this.activityService.List();
        }

        [HttpPost]
        [Route("apply/{prgId}")]
        public IActionResult Apply(long prgId)
        {
            this.activityService.Apply(prgId, User?.Identity?.Name);
            return Ok();
        }

        [HttpPost]
        [Route("cancel-apply/{prgId}")]
        public IActionResult CancelApply(long prgId)
        {
            this.activityService.CancelApply(prgId, User?.Identity?.Name);
            return Ok();
        }
    }
}
