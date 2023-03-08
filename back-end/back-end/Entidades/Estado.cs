using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
