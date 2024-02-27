using Dominio.Model;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

    }
}
