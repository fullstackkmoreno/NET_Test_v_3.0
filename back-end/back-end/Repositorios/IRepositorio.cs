using back_end.Entidades;

namespace back_end.Repositorios
{
    public interface IRepositorio
    {
        List<Comentario> ObtenerTodosLosComentarios();

        List<Publicacion> ObtenerTodosLasPublicaciones();

        Task<Publicacion> ObtenerPorIdPublicacion(int id);

        Task<Comentario> ObtenerPorIdComentario(int id);
    }
}
