using ConsoleApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp.Services
{
    public class ImportXmlService : IImportService<StationExit>
    {
        public void Display(List<StationExit> datas)
        {
            datas.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public List<StationExit> Filter(List<StationExit> datas)
        {
            return datas.ToList();
        }

        public List<StationExit> LoadFormFile(string filePath)
        {
            var str = System.IO.File.ReadAllText(filePath);

            XDocument? xDocument = System.Xml.Linq.XDocument.Parse(str);

            if (xDocument == null) return new List<StationExit>();
            List<XElement> targets = xDocument.Descendants("StationExit").ToList();

            return targets
                .Select(x =>
                {
                    var item = new StationExit();
                    item.StationID = x.Element("StationID").Value;
                    item.UpdateTime = x.Element("UpdateTime").Value;
                    item.LocationDescription = x.Element("LocationDescription").Value;
                    item.Elevator = bool.Parse(x.Element("Elevator").Value);
                    var stationNameNode = x.Element("StationName");
                    var exitNameNode = x.Element("ExitName");
                    item.StationName = stationNameNode.Element("Zh_tw").Value;
                    item.ExitName = exitNameNode.Element("Zh_tw").Value;
                    return item;
                })
                .ToList();
        }

        public bool SaveFormFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
