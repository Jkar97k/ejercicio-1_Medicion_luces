using Api.Entidades;
using Api.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicionLuces.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicionLucesController : ControllerBase
    {
        private readonly IMedicionLucesService _mediicionLucesService;

        public MedicionLucesController(IMedicionLucesService mediicionLucesService)
        {
            _mediicionLucesService = mediicionLucesService;
        }

        [HttpPost("Medicion")]
        public IActionResult Muestra([FromBody] MedicionLuz medida )
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var respuesta = _mediicionLucesService.Validacion(medida);

            return Ok(respuesta);
        }
    }
}
