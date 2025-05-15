using APIPruebaToka.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APIPruebaToka.Repositories
{
    public class PersonaFisicaRepository : IPersonaFisicaRepository
    {
        private readonly string _connectionString;

        public PersonaFisicaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<(int Error, string Message)> CreatePersonaFisicaAsync(CreatePersonaFisicaDTO dto)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_AgregarPersonaFisica", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Nombre", dto.Nombre);
            command.Parameters.AddWithValue("@ApellidoPaterno", dto.ApellidoPaterno);
            command.Parameters.AddWithValue("@ApellidoMaterno", dto.ApellidoMaterno);
            command.Parameters.AddWithValue("@RFC", dto.RFC);
            command.Parameters.AddWithValue("@FechaNacimiento", dto.FechaNacimiento);
            command.Parameters.AddWithValue("@UsuarioAgrega", dto.UsuarioAgrega);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return (
                    Convert.ToInt32(reader["ERROR"]),
                    reader["MENSAJEERROR"].ToString()!
                );
            }

            return (-1, "Error desconocido");
        }

        public async Task<List<PersonaFisicaDTO>> GetPersonasFisicasAsync()
        {
            var persons = new List<PersonaFisicaDTO>();

            using var connection = new SqlConnection(_connectionString);
            var query = @"SELECT IdPersonaFisica AS Id, Nombre, ApellidoPaterno, ApellidoMaterno, RFC, FechaNacimiento, UsuarioAgrega
                  FROM Tb_PersonasFisicas
                  WHERE Activo = 1";

            using var command = new SqlCommand(query, connection);
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                persons.Add(new PersonaFisicaDTO
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString()!,
                    ApellidoPaterno = reader["ApellidoPaterno"].ToString()!,
                    ApellidoMaterno = reader["ApellidoMaterno"].ToString()!,
                    RFC = reader["RFC"].ToString()!,
                    FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                    UsuarioAgrega = reader["UsuarioAgrega"].ToString()!
                });
            }

            return persons;
        }

        public async Task<(int Error, string Message)> UpdatePersonaFisicaAsync(UpdatePersonaFisica dto)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_ActualizarPersonaFisica", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdPersonaFisica", dto.Id);
            command.Parameters.AddWithValue("@Nombre", dto.Nombre ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ApellidoPaterno", dto.ApellidoPaterno ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ApellidoMaterno", dto.ApellidoMaterno ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@RFC", dto.RFC ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FechaNacimiento", dto.FechaNacimiento ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UsuarioAgrega", dto.UsuarioActualiza ?? (object)DBNull.Value);

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return (
                    Convert.ToInt32(reader["ERROR"]),
                    reader["MENSAJEERROR"].ToString()!
                );
            }

            return (-1, "Error desconocido");
        }

        public async Task<(int Error, string Message)> DeletePersonaFisicaAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_EliminarPersonaFisica", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdPersonaFisica", id);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                int error = reader.GetInt32(0);
                string message = reader.GetString(1);
                return (error, message);
            }

            return (-1, "No se recibió respuesta del procedimiento almacenado.");
        }
    }
}
