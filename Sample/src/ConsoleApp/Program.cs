using ConsoleApp.Models;
using ConsoleApp.Services;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

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

            var csvSet = csvDatas
                .GroupBy(x => x.行政區)
                .ToDictionary(x => x.Key, y => y.ToList());

            var 三民區停車場s = csvSet["三民區"];


            var t = csvDatas
                .Select(x => x.行政區)
                .Distinct()
                .Aggregate((x, y) =>
                {
                    return $"{x} ,{y}";
                });



            var stt = Newtonsoft.Json.JsonConvert.SerializeObject(csvSet);

            File.WriteAllText(Utils.FilePath.GetFullPath("高雄停車場.json"), stt);




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