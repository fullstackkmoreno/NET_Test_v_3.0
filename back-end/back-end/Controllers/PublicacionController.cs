using back_end.DTOs;
using back_end.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace back_end.Controllers
{
    [Route("api/publicaciones")]
    public class PublicacionController : ControllerBase
    {
        private readonly ILogger<PublicacionController> _loggerPublicacion;
        private readonly ApplicationDbContext _context;
        public PublicacionController(ILogger<PublicacionController> publicacionLogger,
            ApplicationDbContext context)
        {
            _loggerPublicacion = publicacionLogger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PublicacionDTO>>> Get()
        {
            
            var publicaciones = await _context.Publicaciones
                .Where(p => p.Activo == true).ToListAsync();
            var estados = await _context.Estados.ToArrayAsync();
            var resultado = new List<PublicacionDTO>();

            foreach(var publicacion in publicaciones)
            {
                resultado.Add(new PublicacionDTO()
                {
                    IdPublicacion = publicacion.IdPublicacion,
                    Titulo = publicacion.Titulo,
                    Texto = publicacion.Texto,
                    Fecha = publicacion.Fecha,
                    Autor = publicacion.Autor,
                    IdEstado = publicacion.Estado.IdEstado,
                    NombreEstado = publicacion.Estado.Nombre
                });
            }

            return resultado;
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<PublicacionDTO>> Get(int Id)
        {
            var publicacion = await _context.Publicaciones
                .Where(x => x.IdPublicacion == Id)
                .Include(y => y.Estado)
                .FirstAsync();
            var resultado = new PublicacionDTO();

            resultado.IdPublicacion = publicacion.IdPublicacion;
            resultado.Titulo = publicacion.Titulo;
            resultado.Texto = publicacion.Texto;
            resultado.Fecha = publicacion.Fecha;
            resultado.IdEstado = publicacion.Estado.IdEstado;
            resultado.NombreEstado = publicacion.Estado.Nombre;
            resultado.Activo = publicacion.Activo;

            return resultado; 

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PublicacionDTO publicacionDTO)
        {
            var publicacion = new Publicacion();

            publicacion.IdPublicacion = publicacionDTO.IdPublicacion;
            publicacion.Titulo = publicacionDTO.Titulo;
            publicacion.Texto = publicacionDTO.Texto;
            publicacion.Fecha = publicacionDTO.Fecha;
            publicacion.Estado.IdEstado = publicacionDTO.IdEstado;
            publicacion.Estado.Nombre = publicacionDTO.NombreEstado;
            publicacion.Activo = publicacionDTO.Activo;

            _context.Add(publicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put([FromBody] PublicacionDTO publicacionDTO)
        {
            var publicacion = new Publicacion();

            publicacion.IdPublicacion = publicacionDTO.IdPublicacion;
            publicacion.Titulo = publicacionDTO.Titulo;
            publicacion.Texto = publicacionDTO.Texto;
            publicacion.Fecha = publicacionDTO.Fecha;
            publicacion.Estado.IdEstado = publicacionDTO.IdEstado;
            publicacion.Estado.Nombre = publicacionDTO.NombreEstado;
            publicacion.Activo = publicacionDTO.Activo;

            _context.Update(publicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var publicacion = await _context.Publicaciones.Where(x => x.IdPublicacion == Id).FirstAsync();

            publicacion.Activo = false;
            _context.Update(publicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
