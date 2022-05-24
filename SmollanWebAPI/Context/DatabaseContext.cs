using Microsoft.EntityFrameworkCore;
using SmollanWebAPI.Entities;

namespace SmollanWebAPI.Context
{
    public class DatabaseContext : DbContext
    {
        private IConfiguration Configuration { get; set; }
        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("SmollanDBConnectionString");

            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<User> Users { get; set; }
    }
}
