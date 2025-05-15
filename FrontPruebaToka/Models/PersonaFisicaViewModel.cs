namespace FrontPruebaToka.Models
{
    public class PersonaFisicaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string ApellidoPaterno { get; set; } = "";
        public string ApellidoMaterno { get; set; } = "";
        public string RFC { get; set; } = "";
        public DateTime FechaNacimiento { get; set; }
        public string UsuarioAgrega { get; set; } = "";
    }
}
