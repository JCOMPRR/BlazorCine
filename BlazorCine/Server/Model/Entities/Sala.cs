using System.ComponentModel.DataAnnotations;

namespace BlazorCine.Server.Model.Entities
{
    public class Sala
    {
        public int Id { get; set; }
       
        [Required]
        public int TipoSala { get; set; }
        public int PrecioSala { get; set; }



        public int CarteleraId { get; set; }
        public Cartelera? Carteleras { get; set; }
    }
}
