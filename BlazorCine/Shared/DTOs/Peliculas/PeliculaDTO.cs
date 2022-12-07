using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCine.Shared.DTOs.Peliculas
{
    public class PeliculaDTO
    {
        public string IdPelicula { get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public string Idioma { get; set; }

    }
}
