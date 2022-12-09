using BlazorCine.Server.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCine.Server.Model
{
    public class ApplicationDbContext : DbContext
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public ApplicationDbContext(
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
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
