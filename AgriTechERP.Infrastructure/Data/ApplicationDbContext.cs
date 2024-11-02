using AgriTechERP.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgriTechERP.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SuministradorModel> Suministradores { get; set; }
        public DbSet<ProductoSuministradorModel> ProductosSuministradores { get; set; }

        

    }
}
