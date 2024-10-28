using LogicaDeNegocios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AccesoADatos
{
    public class Contexto : DbContext
    {
        public DbSet<Tarea> Tareas;
        public Contexto(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>(t => t.HasKey(t => t.Id));

            base.OnModelCreating(modelBuilder); 
        }

    }
}
