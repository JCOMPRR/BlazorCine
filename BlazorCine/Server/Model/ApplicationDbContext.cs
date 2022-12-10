using BlazorCine.Server.Model;
using Microsoft.EntityFrameworkCore;
using BlazorCine.Server.Model.Entities;

namespace BlazorCine.Server.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Cartelera> Carteleras { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Sala> Salas{ get; set; }
    }
}
