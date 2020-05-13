using LifeGame.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LifeGame.DAL
{
    public class DefaultContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Moving> Movings { get; set; }
        public DbSet<GameObject> GameObjects { get; set; }

        public DefaultContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder().SetBasePath(path)
                                                   .AddJsonFile("dbsettings.json")
                                                   .Build();


            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
