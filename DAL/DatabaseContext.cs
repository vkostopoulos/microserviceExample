using BOL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5MTTOS6\SQLEXPRESS;" +
                                                            "Initial Catalog=microserviceExample;" +
                                                            "persist security info = True;Integrated Security = SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Customer>()
                .HasData(
                    new Customer { Id = 1, Name = "test1", Address = "testAddress1", Contact = "1234567890"},
                    new Customer { Id = 2, Name = "test2", Address = "testAddress2", Contact = "2345678901" }
                );
        }
    }
}
