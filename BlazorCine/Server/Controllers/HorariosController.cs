using BlazorCine.Server.Model.Entities;
using BlazorCine.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCine.Shared.DTOs.Horarios;

namespace BlazorCine.Server.Controllers
{
    [ApiController, Route("api/horarios")]
    public class HorariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public HorariosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HorarioDTO>>> GetHorarios()
        {
            var horarios = await context.Horarios.ToListAsync();

            var HorariosDto = new List<HorarioDTO>();

            foreach (var horario in horarios)
            {
                var horarioDto = new HorarioDTO();
                horarioDto.Id = horario.Id;
                horarioDto.Hora = horario.Hora;

                HorariosDto.Add(horarioDto);
            }
            return HorariosDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HorarioDTO>> GetHorario(int id)
        {
            var horario = await context.Horarios
                .FirstOrDefaultAsync(x => x.Id == id);

            if (horario == null)
            {
                return NotFound();
            }

            var horarioDto = new HorarioDTO();
            horarioDto.Id = horario.Id;
            horarioDto.Hora = horario.Hora;

            return horarioDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] HorarioDTO horarioDto)
        {
            var horario = new Horario();
            horario.Hora = horarioDto.Hora;

            context.Horarios.Add(horario);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] HorarioDTO horarioDto)
        {
            var horarioDb = await context.Horarios
                .FirstOrDefaultAsync(x => x.Id == horarioDto.Id);

            if (horarioDb == null)
            {
                return NotFound();
            }

            horarioDb.Hora = horarioDto.Hora;

            context.Horarios.Update(horarioDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var horarioDb = await context.Horarios
                .FirstOrDefaultAsync(x => x.Id == id);

            if (horarioDb == null)
            {
                return NotFound();
            }

            context.Horarios.Remove(horarioDb);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
