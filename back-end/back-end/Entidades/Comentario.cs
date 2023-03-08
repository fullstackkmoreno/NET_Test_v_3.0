using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }
        public Publicacion Publicacion { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; }
        public bool Activo { get; set; }
    }
}
