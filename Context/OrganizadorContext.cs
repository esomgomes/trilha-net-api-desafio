using Microsoft.EntityFrameworkCore;
using Npgsql;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Status)
                .HasConversion<int>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Host=localhost;Database=postgres;Username=postgres;Password=Majo2010@;";
                optionsBuilder.UseNpgsql(connectionString, options => options.SetPostgresVersion(9, 6));
            }
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
