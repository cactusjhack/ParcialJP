using Lib_Productos_JP.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Lib_Productos_JP.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        public DbSet<Auditorias> Auditorias { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Tiendas>? Tiendas { get; set; }
        int SaveChanges();
    }
}