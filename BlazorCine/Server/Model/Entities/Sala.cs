using System.ComponentModel.DataAnnotations;

namespace BlazorCine.Server.Model.Entities
{
    public class Sala
    {
        public int IdSala { get; set; }
       
        [Required]
        public string TipoSala { get; set; }
        public int PrecioSala { get; set; }



        public int CarteleraId { get; set; }
        public Cartelera Carteleras { get; set; }
    }
}
