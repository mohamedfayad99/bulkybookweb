using Bulky_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Razor.Data
{
    public class ApplicationDBContext :DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
