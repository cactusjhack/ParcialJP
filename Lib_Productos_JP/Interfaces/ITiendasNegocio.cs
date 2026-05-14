using Lib_Productos_JP.Entidades;

namespace Lib_Productos_JP.Interfaces
{
    public interface ITiendasNegocio
    {
        List<Tiendas> Consultar();
        Tiendas Guardar(Tiendas entidad);
        Tiendas Actualizar(Tiendas entidad);
        bool Eliminar(int id);
    }
}