using APIPruebaToka.DTOs;

namespace APIPruebaToka.Repositories
{
    public interface IPersonaFisicaRepository
    {
        Task<(int Error, string Mensaje)> CreatePersonaFisicaAsync(CreatePersonaFisica dto);
    }
}
