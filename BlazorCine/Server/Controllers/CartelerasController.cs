using BlazorCine.Server.Model.Entities;
using BlazorCine.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCine.Shared.DTOs.Carteleras;

namespace BlazorCine.Server.Controllers
{
    [ApiController, Route("api/carteleras")]

    public class CartelerasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CartelerasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarteleraDTO>>> GetCarteleras()
        {
            var carteleras = await context.Carteleras.ToListAsync();

            var cartelerasDto = new List<CarteleraDTO>();

            foreach (var cartelera in carteleras)
            {
                var carteleraDto = new CarteleraDTO();
                carteleraDto.Id = cartelera.Id;
                carteleraDto.Nombre = cartelera.Nombre;
                carteleraDto.Horario = cartelera.Horario;
                carteleraDto.Sala = cartelera.Sala;


                cartelerasDto.Add(carteleraDto);
            }
            return cartelerasDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarteleraDTO>> GetCartelera(int id)
        {
            var cartelera = await context.Carteleras
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cartelera == null)
            {
                return NotFound();
            }

            var carteleraDto = new CarteleraDTO();
            carteleraDto.Id = cartelera.Id;
            carteleraDto.Nombre = cartelera.Nombre;
            carteleraDto.Horario = cartelera.Horario;
            carteleraDto.Sala = cartelera.Sala;

            return carteleraDto;
        }

        //Funcion agregada por fallo del "return carteleraDto, Eliminar si no es necesario"
        private ActionResult<CarteleraDTO> NotFound()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CarteleraDTO carteleraDto)
        {
            var cartelera = new Cartelera();
            cartelera.Nombre = carteleraDto.Nombre;
            cartelera.Horario = carteleraDto.Horario;
            cartelera.Sala = carteleraDto.Sala;

            context.Carteleras.Add(cartelera);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Funcion agregada por fallo del "return Ok(), Eliminar si no es necesario"
        private ActionResult Ok()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] CarteleraDTO carteleraDto)
        {
            var carteleraDb = await context.Carteleras
                .FirstOrDefaultAsync(x => x.Id == carteleraDto.Id);

            if (carteleraDb == null)
            {
                //Eliminar lo que esta en el () por si acaso 
                return NotFound(carteleraDb);
            }

            carteleraDb.Nombre = carteleraDto.Nombre;
            carteleraDb.Horario = carteleraDto.Horario;
            carteleraDb.Sala = carteleraDto.Sala;

            context.Carteleras.Update(carteleraDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var carteleraDb = await context.Carteleras
                .FirstOrDefaultAsync(x => x.Id == id);

            if (carteleraDb == null)
            {
                //Eliminar lo que esta en el () por si acaso
                return NotFound(carteleraDb);
            }

            context.Carteleras.Remove(carteleraDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

