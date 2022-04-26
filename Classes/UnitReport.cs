using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalcompTwoCam
{
    public class UnitReport
    {

        [JsonProperty("_Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("_SerialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("_StatusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("_DateTimeStart")]
        public DateTime DateTimeStart { get; set; }

        [JsonProperty("_DateTimeEnd")]
        public DateTime DateTimeEnd { get; set; }
    }
}
