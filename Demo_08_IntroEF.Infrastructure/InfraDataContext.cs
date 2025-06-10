using Demo_08_IntroEF.Infrastructure.Entity;
using Demo_08_IntroEF.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Demo_08_IntroEF.Infrastructure
{
    public class InfraDataContext : DbContext
    {
        public DbSet<Demo> Demo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=GambitDB;User Id=postgres;Password=Test1234=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ajout manuel des configs
            modelBuilder.ApplyConfiguration(new DemoConfiguration());
            
            // Ajout automatique des confis présente dans le projet
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
