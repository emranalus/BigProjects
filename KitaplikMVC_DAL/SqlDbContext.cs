using KitaplikMVC_DAL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace KitaplikMVC_DAL
{
    public class SqlDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }

        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=DbKitaplikMVC;User Id=sa;Password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasQueryFilter(p => p.State == 0);
        }

    }
}
