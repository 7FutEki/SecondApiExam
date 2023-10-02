using Microsoft.EntityFrameworkCore;
using SecondApiExam.Models;

namespace SecondApiExam.Data
{
    public class ApplicationContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = SecondApiExam.db");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
