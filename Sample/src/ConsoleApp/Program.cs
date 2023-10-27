using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ImportXmlService xmlService = new ImportXmlService();

            List<StationExit> datas = xmlService.LoadFormFile(Utils.FilePath.GetFullPath("北捷站點.xml"));

            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", datas.Count));

            datas.ForEach(x =>
            {
                Console.WriteLine(string.Format("編號 :{0} 名稱:{1}({2}) 描述:{3}", x.StationID, x.StationName, x.ExitName, x.LocationDescription));
            });


            var jsonService = new ImportJsonService();


            var jsonDatas = jsonService.LoadFormFile(Utils.FilePath.GetFullPath("高雄活動.json"));

            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", jsonDatas.Count));
            jsonDatas.ForEach(x =>
            {
                Console.WriteLine(string.Format("編號 :{0} 名稱:{1} 地點:{2}", x.Id, x.PrgName, x.PrgPlace));
            });

            Console.ReadKey();
        }
    }
}