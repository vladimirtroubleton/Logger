using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logger.Models;
using Logger.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Logger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository logRepository;

        public LogController(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        [HttpPost("sendlog")]
        public string CreateLog(object log)
        {
           LogModel desirializedLog = DeserializeObject<LogModel>(log.ToString());

            logRepository.LogCreate(desirializedLog);

            return "Saved";
        }

        [HttpPost("getlogs")]
        public string GetAllLogs()
        {

            LogModel[] logModels = logRepository.LogSortingAndGetByTime().ToArray();

            return SerializeObject(logModels) ;
        }



        private TResult DeserializeObject<TResult>(string derializeObject)
        {
            return JsonConvert.DeserializeObject<TResult>(derializeObject);
        }

        private  string SerializeObject(LogModel[] serializeObject)
        {
            return JsonConvert.SerializeObject(serializeObject);
        }
    }
}