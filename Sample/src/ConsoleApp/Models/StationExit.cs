using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class StationExit
    {
        public long Id { get; set; }
        public string StationID { get; set; }
        public string UpdateTime { get; set; }
        public string LocationDescription { get; set; }
        public bool Elevator { get; set; }
        public string StationName { get; set; }
        public string ExitName { get; set; }
    }
}
