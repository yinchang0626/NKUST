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
        [Route("apply")]
        public void Apply([FromQuery] long prgId)
        {
            this.activityService.Apply(prgId, User?.Identity?.Name);

            //var result =activityService.List()
        }
    }
}
