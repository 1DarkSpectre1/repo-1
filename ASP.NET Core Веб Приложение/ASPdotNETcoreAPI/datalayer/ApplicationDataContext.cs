using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace datalayer
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}