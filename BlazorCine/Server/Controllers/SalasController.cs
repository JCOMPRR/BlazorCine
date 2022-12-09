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
                var salaDto = new SalaDTO();
                salaDto.Id = sala.Id;
                salaDto.TipoSala = sala.TipoSala;
                salaDto.PrecioSala = sala.PrecioSala;

                SalasDto.Add(salaDto);
            }
            return SalasDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SalaDTO>> GetSalas(int id, SalaDTO salaDto)
        {
            var sala = await context.Salas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sala == null)
            {
                return NotFound();
            }

            new SalaDTO().Id = sala.Id;
            new SalaDTO().TipoSala = sala.TipoSala;
            new SalaDTO().PrecioSala = sala.PrecioSala;

            return new SalaDTO();
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] SalaDTO salaDto)
        {
            var sala = new Sala();
            sala.TipoSala = salaDto.TipoSala;
            sala.PrecioSala = salaDto.PrecioSala;

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
