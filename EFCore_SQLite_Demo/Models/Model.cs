using Microsoft.EntityFrameworkCore;

namespace EFCore_SQLite_Demo.Models
{
    public class TasksContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=c:\temp\TasksDB.db");
        }
    }

    public class Tasks
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

    }
}
