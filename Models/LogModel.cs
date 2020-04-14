using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Models
{
    public class LogModel
    {
        [JsonProperty("logId")]
        [Key]
        public Guid Id { get; set; }

        [JsonProperty("logType")]
        public string LogType { get; set; }

        [JsonProperty("logRecord")]
        public string  LogRecord { get; set; }

        [JsonProperty("logTime")]
        public DateTime LogTime { get; set; }

    }
}
