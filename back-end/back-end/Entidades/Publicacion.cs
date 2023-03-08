using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Publicacion
    {
        [Key]
        public int IdPublicacion { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; }
        public Estado Estado { get; set; }
        public bool Activo { get; set; }
    }
}
