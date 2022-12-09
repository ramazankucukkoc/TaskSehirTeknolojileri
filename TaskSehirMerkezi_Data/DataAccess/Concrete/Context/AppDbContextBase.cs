using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskSehirTeknolojileri_Data.Entities.Concrete;

namespace TaskSehirTeknolojileri_Data.DataAccess.Concrete.Context
{
    public class AppDbContextBase : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public AppDbContextBase()
        {

        }
        public AppDbContextBase(DbContextOptions<AppDbContextBase> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TaskSehirMerkezi;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }

    }
}
