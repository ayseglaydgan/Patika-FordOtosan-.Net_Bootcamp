using Microsoft.EntityFrameworkCore;
using NiceAPI.DataLayer.Model;
using System.Reflection;

namespace NiceAPI.DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            

        }
        public DbSet<Person>? Person { get; set; }
        public DbSet<Account>? Account { get; set; }
        //  you have defined entity type configurations in your project 
        //and you want to ensure that those configurations are applied to the model when you use Entity Framework Core to interact with the database.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}


