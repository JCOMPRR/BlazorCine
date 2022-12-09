using System.ComponentModel.DataAnnotations;

namespace BlazorCine.Server.Model.Entities
{
    public class Horario
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int Hora { get; set; }


        public int CarteleraId { get; set; }
        public Cartelera? Carteleras { get; set; }
    }
}
