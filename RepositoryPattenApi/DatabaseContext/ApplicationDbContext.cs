using Microsoft.EntityFrameworkCore;
using RepositoryPattenApi.Models;

namespace RepositoryPattenApi.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {

        }
        public DbSet<User> users { get; set; }

    }
}
