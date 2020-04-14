using Logger.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logger.Repositories
{
    public interface ILogRepository
    {
        Task LogCreate(LogModel log);
        Task LogDelete(LogModel log);
        List<LogModel> LogSortingAndGetByTime();
    }
}