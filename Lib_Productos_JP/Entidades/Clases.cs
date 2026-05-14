
namespace Lib_Productos_JP.Entidades
{
    public class Auditorias
    {
        public int Id {  get; set; }
        public string? Tabla { get; set; }
        public DateTime Fecha {  get; set; }
        public string? Descripcion { get; set; }
        public string? Accion {  get; set; }
    }

    public class Tiendas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaFundacion { get; set; }
        public List<Productos>? Productos { get; set; }
    }

    public class Productos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public int Stock { get; set; }
        public int Tienda { get; set; }
        public Tiendas? _Tienda { get; set; }
    }
}
