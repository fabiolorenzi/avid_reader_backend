using Microsoft.EntityFrameworkCore;
using AvidReaderBackend.Models;

namespace AvidReaderBackend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<Book> Books {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var AppData = new ApplicationData();
            var ServerVersion = new MySqlServerVersion(new Version(8, 0, 37));
            optionsBuilder
                .UseMySql(AppData.ConnectionString, ServerVersion)
                .UseLoggerFactory(LoggerFactory.Create(b => b
                    .AddConsole()
                    .AddFilter(level => level >= LogLevel.Information)
                ))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}