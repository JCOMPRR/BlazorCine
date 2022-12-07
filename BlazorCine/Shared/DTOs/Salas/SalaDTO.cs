using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCine.Shared.DTOs.Salas
{
    public class SalaDTO
    {
        public int Id { get; set; }

        [Required]
        public string TipoSala { get; set; }
        public int PrecioSala { get; set; }
    }
}
