using ConsoleApp.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class ImportCsvService : IImportService<Parking>
    {
        public void Display(List<Parking> datas)
        {
            datas.ForEach(x =>
            {
                Console.WriteLine(x);
            });
            
        }

        public List<Parking> Filter(List<Parking> datas)
        {
            return datas.ToList();
        }

        public List<Parking> LoadFormFile(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Parking>().ToList();

            return records;

        }

        public bool SaveFormFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
