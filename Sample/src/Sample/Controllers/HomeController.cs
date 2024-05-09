using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Hosting.Internal;
using Sample.Models;
using Sample.Services;
using Sample.ViewModels.Home;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ActivityService activityService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(
            ILogger<HomeController> logger,
            ActivityService activityService,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _logger = logger;
            this.activityService = activityService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public ViewResult Index(string? filter, bool? apply)
        {
            string webRootPath = webHostEnvironment.WebRootPath;

            var datas = activityService
                .List()
                .OrderByDescending(x => x.PrgId)
                .ToList();

            var applies = this.activityService.GetApplies();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                datas = datas
                    .Where(x => x.PrgName.Contains(filter))
                    .ToList();
            }

            if (apply.HasValue && apply.Value)
            {
                datas = applies.Where(x => x.UserName == User?.Identity?.Name)
                    .Select(x => datas.Single(y => y.PrgId == x.PrgId)).ToList();
            }

            var model = new IndexViewModel()
            {
                Activities = datas,
                ActivityApplies = applies,
                Filter = filter,
                UserName = User?.Identity?.Name,
                Apply = apply
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(long prgId)
        {
            this.activityService.Remove(prgId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var newPrgId = this.activityService.List().Max(x => x.PrgId) + 1;

            return View(new Activity()
            {
                PrgId = newPrgId,
            });
        }

        [HttpPost]
        public IActionResult Create(Activity activity)
        {
            this.activityService.Add(activity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var model = this.activityService.List().FirstOrDefault(x => x.PrgId == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Activity activity)
        {
            this.activityService.Update(activity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Apply(long prgId)
        {
            this.activityService.Apply(prgId, User?.Identity?.Name);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult CancelApply(long prgId)
        {
            this.activityService.CancelApply(prgId, User?.Identity?.Name);
            return RedirectToAction("Index");
        }


    }
}
