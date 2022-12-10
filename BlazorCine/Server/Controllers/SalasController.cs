using BlazorCine.Server.Model.Entities;
using BlazorCine.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCine.Shared.DTOs.Salas;

namespace BlazorCine.Server.Controllers
{
    [ApiController, Route("api/salas")]
    public class SalasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public SalasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalaDTO>>> GetSalas()
        {
            var salas = await context.Salas.ToListAsync();

            var SalasDto = new List<SalaDTO>();

            foreach (var sala in salas)
            {
                SalaDTO? salaDto = new SalaDTO { Id = sala.Id, TipoSala = sala.TipoSala, PrecioSala = sala.PrecioSala };

                SalasDto.Add(salaDto);
            }
            return SalasDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SalaDTO>> GetSalas(int id)
        {
            var sala = await context.Salas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sala == null)
            {
                return NotFound();
            }

            SalaDTO? salaDto = new()
            {
                Id = sala.Id,
                TipoSala = sala.TipoSala,
                PrecioSala = sala.PrecioSala
            };

            return salaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] SalaDTO salaDto)
        {
            var sala = new Sala
            {
                TipoSala = salaDto.TipoSala,
                PrecioSala = salaDto.PrecioSala
            };

            context.Salas.Add(sala);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] SalaDTO salaDto)
        {
            var salaDb = await context.Salas
                .FirstOrDefaultAsync(x => x.Id == salaDto.Id);

            if (salaDb == null)
            {
                return NotFound();
            }

            salaDb.TipoSala = salaDto.TipoSala;
            salaDb.PrecioSala = salaDto.PrecioSala;

            context.Salas.Update(salaDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var salaDb = await context.Salas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (salaDb == null)
            {
                return NotFound();
            }

            context.Salas.Remove(salaDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
