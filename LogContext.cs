using Logger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logger
{
    public class LogContext : DbContext
    {
        public DbSet<LogModel> Logs { get; set; }


       public LogContext(DbContextOptions<LogContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogModel>().HasData(new LogModel { Id = Guid.NewGuid(), LogType = "Ок", LogRecord = "Привет" , LogTime = DateTime.Now });

        }
    }
}
