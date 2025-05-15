namespace APIPruebaToka.DTOs
{
    public class PersonaFisicaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public string RFC { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string UsuarioAgrega { get; set; } = null!;
    }
}
