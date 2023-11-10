using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class ImportJsonService : IImportService<Activity>
    {
        public void Display(List<Activity> datas)
        {
            datas.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public List<Activity> Filter(List<Activity> datas)
        {
            return datas.ToList();
        }

        public List<Activity> LoadFormFile(string filePath)
        {
            var str = System.IO.File.ReadAllText(filePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Activity>>(str);
        }

        public bool SaveFormFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
