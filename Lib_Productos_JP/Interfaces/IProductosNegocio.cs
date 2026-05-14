using Lib_Productos_JP.Entidades;

namespace Lib_Productos_JP.Interfaces
{
    public interface IProductosNegocio
    {
        List<Productos> Consultar();
        Productos Guardar(Productos entidad);
        Productos Actualizar(Productos entidad);
        bool Eliminar(int id);
    }
}