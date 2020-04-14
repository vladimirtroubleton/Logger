using Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Repositories
{
    public class LogRepository : ILogRepository
    {
        private LogContext context;
        private object locker = new object();
        public LogRepository(LogContext context)
        {
            this.context = context;
        }

        public Task LogCreate(LogModel log)
        {
            lock (locker)
            {
                context.Logs.Add(log);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task LogDelete(LogModel log)
        {
            lock (locker)
            {
                context.Logs.Remove(log);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public List<LogModel> LogSortingAndGetByTime()
        {
            return context.Logs.OrderBy(x => x.LogTime).ToList();
        }
    }
}
