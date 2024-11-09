using marketApp.Back.Core.Domain;
using marketApp.Back.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using static marketApp.Back.Persistance.Configurations.AppUserConfiguration;

namespace marketApp.Back.Persistance.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => this.Set<Product>();

        public DbSet<Category> Categories => this.Set<Category>();

        public DbSet<AppUser> AppUsers => this.Set<AppUser>(); 

        public DbSet<AppRole> AppRoles => this.Set<AppRole>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
