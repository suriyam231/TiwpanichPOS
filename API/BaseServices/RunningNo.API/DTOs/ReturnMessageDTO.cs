using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningNo.API.DTOs
{
    public class ReturnMessageDTO
    {
        [JsonProperty("TypeCode")]
        public string TypeCode { get; set; }
        [JsonProperty("TypeName")]
        public string TypeName { get; set; }
        [JsonProperty("Digit")]
        public int Digit { get; set; }
        [JsonProperty("Format")]
        public string Format { get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
        [JsonProperty("Code")]
        public string Code { get; set; }
        [JsonProperty("Message")]
        public string Message { get; set; }


    }
}
