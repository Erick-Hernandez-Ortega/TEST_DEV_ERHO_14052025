using APIPruebaToka.DTOs;

namespace APIPruebaToka.Repositories
{
    public interface IPersonaFisicaRepository
    {
        Task<(int Error, string Mensaje)> CreatePersonaFisicaAsync(CreatePersonaFisicaDTO dto);
        Task<List<PersonaFisicaDTO>> GetPersonasFisicasAsync();
    }
}
