using GerenciadorTextos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTextos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Documento> Documentos { get; set; }

    }
}
