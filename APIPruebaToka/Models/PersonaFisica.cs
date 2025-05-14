namespace APIPruebaToka.Models
{
    public class PersonaFisica
    {
        public int IdPersonaFisica { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public string RFC { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public int UsuarioAgrega { get; set; }
    }
}
