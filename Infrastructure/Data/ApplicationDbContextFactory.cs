namespace BookStore1.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    namespace BookStore1.Infrastructure.Data
    {
        public class ApplicationDbContextFactory
            : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(
                    configuration.GetConnectionString("BookStoreConnection")
                );

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
    }

}
