using KitaplikMVC_DAL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace KitaplikMVC_DAL
{
    public class AdminDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }

        public AdminDbContext()
        {

        }

        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=DbKitaplikMVC;User Id=sa;Password=123");
        }

    }
}
