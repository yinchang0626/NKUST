using ConsoleApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ParkingController : Controller
    {
        public IActionResult Index()
        {
            ImportCsvService importCsvService = new ImportCsvService();


            var datas = importCsvService.LoadFormFile(@"App_Data/高雄停車場.csv");   


            return View(datas);
        }
    }
}
