using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    public partial class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [JsonProperty("PRGID")]
        
        public long PrgId { get; set; }

        [JsonProperty("PRGNAME")]
        [DisplayName("活動名稱")]
        public string PrgName { get; set; }

        [JsonProperty("PRGACT")]
        public string PrgAct { get; set; }

        [JsonProperty("PRGDATE")]
        public string PrgDate { get; set; }


        [JsonProperty("ORGNAME")]
        public string OrgName { get; set; }

        [JsonProperty("PRGPLACE")]
        public string PrgPlace { get; set; }

        [JsonProperty("ITEMDESC")]
        public string ItemDesc { get; set; }
    }
}

