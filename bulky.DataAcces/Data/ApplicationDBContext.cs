using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Bulky.DataAcces.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Applicationuser> Applicationusers { get; set; }

        // public DbSet<productcategory> productcategory { get; set; }


    }
}
