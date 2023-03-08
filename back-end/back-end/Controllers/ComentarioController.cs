using back_end.DTOs;
using back_end.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [Route("api/comentarios")]
        public class ComentarioController : ControllerBase
        {
            private readonly ILogger<ComentarioController> _loggerComentario;
            private readonly ApplicationDbContext _context;

            public ComentarioController(ILogger<ComentarioController> comentarioLogger,
                ApplicationDbContext context)
            {
                _loggerComentario = comentarioLogger;
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<List<ComentarioDTO>>> Get()
            {
            var comentarios = await _context.Comentarios
                                    .Where(p => p.Activo == true)
                                    .ToListAsync();
            var estados = await _context.Estados.ToArrayAsync();
            var resultado = new List<ComentarioDTO>();

            foreach (var comentario in comentarios)
            {
                resultado.Add(new ComentarioDTO()
                {
                    IdComentario = comentario.IdComentario,
                    IdPublicacion = comentario.Publicacion.IdPublicacion,
                    TituloPublicacion = comentario.Publicacion.Titulo,
                    Texto = comentario.Texto,
                    Fecha = comentario.Fecha,
                    Autor = comentario.Autor,
                    Activo = comentario.Activo
                }) ;
            }

            return resultado;
        }

        [HttpGet("{IdPublicacion:int}")]
        public async Task<ActionResult<List<ComentarioDTO>>> Get(int IdPublicacion)
        {
            var comentarios = await _context.Comentarios
                                    .Where(x => x.Publicacion.IdPublicacion == IdPublicacion)
                                     .Include(y => y.Publicacion)
                                     .ToArrayAsync();
            var resultado = new List<ComentarioDTO>();

            foreach (var comentario in comentarios)
            {
                resultado.Add(new ComentarioDTO()
                {
                    IdComentario = comentario.IdComentario,
                    IdPublicacion = comentario.Publicacion.IdPublicacion,
                    TituloPublicacion = comentario.Publicacion.Titulo,
                    Texto = comentario.Texto,
                    Fecha = comentario.Fecha,
                    Autor = comentario.Autor,
                    Activo = comentario.Activo
                });
            }

            return resultado;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ComentarioDTO comentarioDTO)
        {

            var comentario = new Comentario();

            comentario.IdComentario = comentarioDTO.IdComentario;
            comentario.Publicacion.IdPublicacion = comentarioDTO.IdPublicacion;
            comentario.Publicacion.Titulo = comentarioDTO.TituloPublicacion;
            comentario.Texto = comentarioDTO.Texto;
            comentario.Fecha = comentarioDTO.Fecha;
            comentario.Autor = comentarioDTO.Autor;
            comentario.Activo = comentarioDTO.Activo;

            _context.Add(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put([FromBody] ComentarioDTO comentarioDTO)
        {
            var comentario = new Comentario();

            comentario.IdComentario = comentarioDTO.IdComentario;
            comentario.Publicacion.IdPublicacion = comentarioDTO.IdPublicacion;
            comentario.Publicacion.Titulo = comentarioDTO.TituloPublicacion;
            comentario.Texto = comentarioDTO.Texto;
            comentario.Fecha = comentarioDTO.Fecha;
            comentario.Autor = comentarioDTO.Autor;
            comentario.Activo = comentarioDTO.Activo;

            _context.Update(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var comentario = await _context.Comentarios.Where(x => x.IdComentario == Id).FirstAsync();

            comentario.Activo = false;
            _context.Update(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        }
    }

