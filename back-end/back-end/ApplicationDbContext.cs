using back_end.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace back_end
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Publicacion> Publicaciones { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<Estado> Estados { get; set; }
    }
}
