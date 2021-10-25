using Microsoft.EntityFrameworkCore;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Arbitro> Arbitro { get; set; }
        public DbSet<Cancha> Cancha { get; set; }
        public DbSet<Deportista> Deportista { get; set; }
        public DbSet<Entrenador> Entrenador { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Escenario> Escenario { get; set; }
        public DbSet<EscuelaArbitro> Escuela { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Patrocinador> Patrocinador { get; set; }
        public DbSet<Torneo> Torneo { get; set; }
        public DbSet<TorneoEquipo> TorneoEquipo { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if(!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EscenarioDeportivo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TorneoEquipo>().HasKey(x=> new{x.TorneoId,x.EquipoId});
        }
    }
}