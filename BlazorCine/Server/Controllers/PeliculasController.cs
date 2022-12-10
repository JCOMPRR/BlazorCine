using BlazorCine.Server.Model.Entities;
using BlazorCine.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCine.Shared.DTOs.Peliculas;


namespace BlazorCine.Server.Controllers
{
    [ApiController, Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PeliculasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PeliculaDTO>>> GetPeliculas()
        {
            var peliculas = await context.Peliculas.ToListAsync();

            var PeliculasDto = new List<PeliculaDTO>();

            foreach (var pelicula in peliculas)
            {
                PeliculaDTO? peliculaDto = new() { Id = pelicula.Id, Nombre = pelicula.Nombre, Duracion = pelicula.Duracion };

                PeliculasDto.Add(peliculaDto);
            }
            return PeliculasDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetPeliculas(int id)
        {
            var pelicula = await context.Peliculas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }

            var peliculaDto = new PeliculaDTO
            {
                Id = pelicula.Id,
                Nombre = pelicula.Nombre,
                Duracion = pelicula.Duracion
            };

            return peliculaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PeliculaDTO peliculaDto)
        {
            var pelicula = new Pelicula
            {
                Nombre = peliculaDto.Nombre,
                Duracion = peliculaDto.Duracion
            };

            context.Peliculas.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] PeliculaDTO peliculaDto)
        {
            var peliculaDb = await context.Peliculas
                .FirstOrDefaultAsync(x => x.Id == peliculaDto.Id);

            if (peliculaDb == null)
            {
                return NotFound();
            }

            peliculaDb.Nombre = peliculaDto.Nombre;
            peliculaDb.Duracion = peliculaDto.Duracion;

            context.Peliculas.Update(peliculaDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var peliculaDb = await context.Peliculas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (peliculaDb == null)
            {
                return NotFound();
            }

            context.Peliculas.Remove(peliculaDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
