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
            return Ok(new { Resultado = _patronLucesService.ObtenerConfiguracion() });
        }

        [HttpPost("NuevaConfig")]
        public IActionResult NuevaConfiguracion([FromBody] PatronLuces Patron)
        {
            var result = _patronLucesService.ConfiguracionLuces(Patron);

            if (result == 0) { return BadRequest("Configuracion Erronea");}

            return Ok("Configuracion Correcta");
        }
    }
}
