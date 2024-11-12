using AgriTechERP.Core.Entidades;
using AgriTechERP.Core.Entidades.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgriTechERP.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SuministradorModel> Suministradores { get; set; }
        public DbSet<ProductoSuministradorModel> ProductosSuministradores { get; set; }
        public DbSet<OrdenCarritoModel> OrdenCarritos { get; set; }
        public DbSet<InventarioModel> Inventarios { get; set; }
        public DbSet<ProduccionModel> ProductosProduccion {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventarioModel>()
                .HasOne(i => i.OrdenCarrito)
                .WithMany()
                .HasForeignKey(i => i.OrdenCarritoId)
                .OnDelete(DeleteBehavior.SetNull);

          
        }

    }
}
