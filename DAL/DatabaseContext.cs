using DesafioPagueVeloz.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPagueVeloz.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
