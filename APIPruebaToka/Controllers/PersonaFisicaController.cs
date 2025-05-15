using APIPruebaToka.DTOs;
using APIPruebaToka.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIPruebaToka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaFisicaController : ControllerBase
    {
        private readonly IPersonaFisicaRepository _repo;

        public PersonaFisicaController(IPersonaFisicaRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreatePersonaFisica dto)
        {
            var (error, mensaje) = await _repo.CreatePersonaFisicaAsync(dto);

            if (error < 0)
                return BadRequest(new { error, mensaje });

            return Ok(new { id = error, mensaje });
        }
    }
}
