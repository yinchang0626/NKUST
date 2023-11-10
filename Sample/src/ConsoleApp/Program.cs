using ConsoleApp.Models;
using ConsoleApp.Services;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IImportService<Parking> csvService = new ImportCsvService();
            IImportService<StationExit> xmlService = new ImportXmlService();
            IImportService<Activity> jsonService = new ImportJsonService();


            List<Parking> csvDatas = csvService.LoadFormFile(Utils.FilePath.GetFullPath("高雄停車場.csv"));

            csvDatas = csvService.Filter(csvDatas);

            csvService.Display(csvDatas);

            Console.ReadKey();


            List<StationExit> xmlDatas = xmlService.LoadFormFile(Utils.FilePath.GetFullPath("北捷站點.xml"));

            xmlDatas = xmlService.Filter(xmlDatas);

            xmlService.Display(xmlDatas);

            Console.ReadKey();


            var jsonDatas = jsonService.LoadFormFile(Utils.FilePath.GetFullPath("高雄活動.json"));

            jsonDatas = jsonService.Filter(jsonDatas);

            jsonService.Display(jsonDatas);

            Console.ReadKey();
        }
    }
}