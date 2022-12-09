using System.ComponentModel.DataAnnotations;

namespace BlazorCine.Server.Model.Entities
{
    public class Cartelera
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public int Horario { get; set; }

        [Required]
        public int Sala { get; set; }



        public List<Horario>? Horarios { get; set; }
        public List<Sala>? Salas { get; set; }
        public List<Pelicula>? Peliculas { get; set; }


    }
}
