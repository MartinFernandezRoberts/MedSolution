using Microsoft.AspNetCore.Mvc;
using MedSolution.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace MedSolution.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FichaController : ControllerBase
    {
        private readonly MedsolutionContext _context;

        public FichaController(MedsolutionContext context)
        {
            _context = context;
        }

        [HttpPost("desfirmar")]
        public async Task<IActionResult> Desfirmar([FromBody] DesfirmarRequest request)
        {
            var ficha = await _context.Fichas.FirstOrDefaultAsync(f =>
                f.IdFicha == request.IdFicha &&
                f.Fecha == request.Fecha &&
                _context.Pacientes.Any(p => p.Rut == request.Rut && p.IdPaciente == f.IdPaciente));

            if (ficha == null)
                return NotFound("Ficha no encontrada.");

            if (request.DesfirmarInformeMedico)
                ficha.FirmaInforme = 0;

            if (request.DesfirmarInformeEnfermeria)
                ficha.FirmaEnfermeria = 0;

            await _context.SaveChangesAsync();

            return Ok("Documentos desfirmados correctamente.");
        }
    }
}
