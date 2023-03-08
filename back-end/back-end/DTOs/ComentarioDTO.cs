using back_end.Entidades;

namespace back_end.DTOs
{
    public class ComentarioDTO
    {
        public int IdComentario { get; set; }
        public int IdPublicacion { get; set; }
        public string TituloPublicacion { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; }
        public bool Activo { get; set; }
    }
}
