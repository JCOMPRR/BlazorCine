using System.ComponentModel.DataAnnotations;

namespace BlazorCine.Server.Model.Entities
{
    public class Pelicula
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public string Idioma { get; set; }


        public int CarteleraId { get; set; }
        public Cartelera Carteleras { get; set; }
    }
}
