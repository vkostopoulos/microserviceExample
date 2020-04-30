using BOL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5MTTOS6\SQLEXPRESS;" +
                                                            "Initial Catalog=microserviceExample;" +
                                                            "persist security info = True;Integrated Security = SSPI;");
        }
    }
}
