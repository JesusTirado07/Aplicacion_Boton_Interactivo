using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Examen_Aplicativo.Models;

namespace Examen_Aplicativo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajeController : ControllerBase
    {
        
        private readonly ExamenAplicativoContext _context;

        public MensajeController(ExamenAplicativoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMensaje()
        {
            var mensaje = await _context.Mensajes.OrderByDescending(m => m.Fecha).FirstOrDefaultAsync();

            if (mensaje == null)
            {
                return NotFound(new { mensaje = "No hay mensajes en la base de datos" });
            }

            return Ok(new { mensaje = $"Hola Mundo - {mensaje.Fecha}" });
        }
    }
}
