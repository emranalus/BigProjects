using FairWorks.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FairWorks.Infrastructure.Contexts
{
    public class SqlDbContext : IdentityDbContext<AppUser>
    {

        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

    }
}
