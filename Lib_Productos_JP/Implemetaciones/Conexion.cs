using Lib_Productos_JP.Entidades;
using Lib_Productos_JP.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Productos_JP.Implemetaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasOne(p => p._Tienda)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.Tienda);
            });
        }

        public string? StringConexion { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Tiendas>? Tiendas { get; set; }
    }
}
