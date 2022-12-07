using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCine.Shared.DTOs.Horarios
{
    public class HorarioDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Hora { get; set; }
    }
}
