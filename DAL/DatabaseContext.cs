using BOL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5MTTOS6\SQLEXPRESS;" +
                                                            "Initial Catalog=microserviceExample;" +
                                                            "persist security info = True;Integrated Security = SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var cryptoHelper = new Helpers.CryptoHelper();

            builder
                .Entity<Customer>()
                .HasData(
                    new Customer { Id = 1, Name = "test1", Address = "testAddress1", Contact = "1234567890"},
                    new Customer { Id = 2, Name = "test2", Address = "testAddress2", Contact = "2345678901" }
                );

            builder
            .Entity<User>()
            .HasData(
                new User { Id = 1, Name = "Admin", Address = "testAddress1", Username = "admin", Password = cryptoHelper.Encrypt("admin")},
                new User { Id = 2, Name = "Employee", Address = "testAddress2", Username = "employee", Password = cryptoHelper.Encrypt("employee") }
            );
        }
    }
}
