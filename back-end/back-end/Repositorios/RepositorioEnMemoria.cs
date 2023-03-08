using back_end.Controllers;
using back_end.Entidades;

namespace back_end.Repositorios 
{
    
    public class RepositorioEnMemoria : IRepositorio
    {
        private readonly List<Comentario> _comentarios = new List<Comentario>();
        private readonly List<Publicacion> _publicaciones = new List<Publicacion>();

        public RepositorioEnMemoria()
        {
         }

        public List<Publicacion> ObtenerTodosLasPublicaciones()
        {
            return _publicaciones;
        }

        public List<Comentario> ObtenerTodosLosComentarios()
        {
            return _comentarios;
        }

        public async Task<Publicacion> ObtenerPorIdPublicacion(int id)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return _publicaciones.FirstOrDefault(x => x.IdPublicacion == id);
        }

        public async Task<Comentario> ObtenerPorIdComentario(int id)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return _comentarios.FirstOrDefault(x => x.IdComentario == id);
        }
    }


}
