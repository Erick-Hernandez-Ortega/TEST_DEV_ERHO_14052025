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
        public async Task<IActionResult> CreateOne([FromBody] CreatePersonaFisicaDTO dto)
        {
            var (error, message) = await _repo.CreatePersonaFisicaAsync(dto);

            if (error < 0)
                return BadRequest(new { error, message });

            return Ok(new { id = error, message });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _repo.GetPersonasFisicasAsync();
            return Ok(persons);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOne([FromBody] UpdatePersonaFisica dto)
        {
            if (dto.Id <= 0)
                return BadRequest("Id inválido");

            var (error, message) = await _repo.UpdatePersonaFisicaAsync(dto);

            if (error > 0)
                return Ok(message);
            else
                return NotFound(message);
        }
    }
}
