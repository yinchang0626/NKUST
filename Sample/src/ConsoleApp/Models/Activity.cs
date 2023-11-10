using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public partial class Activity
    {
        public long Id { get; set; }
        [JsonProperty("PRGID")]
        public long PrgId { get; set; }

        [JsonProperty("PRGNAME")]
        public string PrgName { get; set; }

        [JsonProperty("PRGACT")]
        public string PrgAct { get; set; }

        [JsonProperty("PRGDATE")]
        public string PrgDate { get; set; }

        [JsonProperty("PRGSTIME")]
        public string PrgStime { get; set; }

        [JsonProperty("PRGETIME")]
        public string PrgEtime { get; set; }

        [JsonProperty("ORGNAME")]
        public string OrgName { get; set; }

        [JsonProperty("PRGPLACE")]
        public string PrgPlace { get; set; }

        [JsonProperty("PRGAG")]
        public string PrgAg { get; set; }

        [JsonProperty("PRGCONT")]
        public string PrgCont { get; set; }

        [JsonProperty("PRGTICKET")]
        public string PrgTicket { get; set; }

        [JsonProperty("TICKETSYSURL")]
        public string TicketSysUrl { get; set; }

        [JsonProperty("ITEMDESC")]
        public string ItemDesc { get; set; }

        [JsonProperty("IMAGE1")]
        public string Image1 { get; set; }

        [JsonProperty("IMAGE2")]
        public string Image2 { get; set; }

        public override string ToString()
        {
            return $"名稱:{this.PrgName}, 地點:{this.PrgPlace}, 時間:{this.PrgDate} {this.PrgStime}";
        }
    }
}

