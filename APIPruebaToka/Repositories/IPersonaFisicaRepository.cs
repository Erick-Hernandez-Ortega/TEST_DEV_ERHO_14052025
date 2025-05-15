using APIPruebaToka.DTOs;

namespace APIPruebaToka.Repositories
{
    public interface IPersonaFisicaRepository
    {
        Task<(int Error, string Message)> CreatePersonaFisicaAsync(CreatePersonaFisicaDTO dto);
        Task<List<PersonaFisicaDTO>> GetPersonasFisicasAsync();
        Task<(int Error, string Message)> UpdatePersonaFisicaAsync(UpdatePersonaFisica dto);
        Task<(int Error, string Message)> DeletePersonaFisicaAsync(int id);
    }
}
