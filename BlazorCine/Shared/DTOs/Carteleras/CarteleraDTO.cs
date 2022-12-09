using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCine.Shared.DTOs.Carteleras
{
    public class CarteleraDTO
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public int Horario { get; set; }

        [Required]
        public int Sala { get; set; }
    }
}
