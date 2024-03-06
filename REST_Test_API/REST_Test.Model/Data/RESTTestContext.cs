using Microsoft.EntityFrameworkCore;
using REST_Test.Model.Models;

namespace REST_Test.Data.Data
{
    public class RESTTestContext : DbContext
    {
        public RESTTestContext(DbContextOptions<RESTTestContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
