using Api.Entidades;
using Api.service;
using Microsoft.AspNetCore.Mvc;


namespace MedicionLuces.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronLucesController : ControllerBase
    {
        private readonly IPatronLucesService _patronLucesService;

        public PatronLucesController(IPatronLucesService patronLucesService)
        {
            _patronLucesService = patronLucesService;
        }

        [HttpGet("Get")]
        public IActionResult VerConfiguracion()
        {
            var configuracion = _patronLucesService.ObtenerConfiguracion();
            return Ok(new { Resultado = configuracion });
        }

        [HttpPost("NuevaConfig")]
        public IActionResult NuevaConfiguracion([FromBody] PatronLuces patron)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = _patronLucesService.ConfiguracionLuces(patron);

            if (resultado)
            {
                return Ok(new { Message = "Configuración exitosa" });
            }
            else
            {
                return StatusCode(500, new { Message = "Error al configurar las luces" });
            }
        }
    }
}
