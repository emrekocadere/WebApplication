using Microsoft.EntityFrameworkCore;
using WebApplication.Entity;

namespace WebApplication.Data
{
    public class DataContext:DbContext
    {
        // !!!-- THIS FILE REPRESENTS THE CONNECTION TO TE DATABASE
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            ///veri kaynağını seçmemize olanak tanır -- OnConfiguring
            optionsBuilder.UseSqlServer("Server=EMREVIVO;Database=WebApplication;Trusted_Connection=True;");
        }
        public DbSet<User> User { get; set; }
       // public DbSet<Info> Info { get; set; }

    }
}
