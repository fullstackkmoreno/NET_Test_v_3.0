namespace back_end.DTOs
{
    public class PublicacionDTO
    {
        public int IdPublicacion { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public bool Activo { get; set; }
    }
}
