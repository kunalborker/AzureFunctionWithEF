using AzureFunctionWithEF.Class.Domain;
using AzureFunctionWithEF.Class.Mapper;
using Microsoft.EntityFrameworkCore;


namespace AzureFunctionWithEF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Data> Test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DataConfiguration());
        }
    }
}
