using Lib_Productos_JP.Entidades;
using Lib_Productos_JP.Implemetaciones;
using Lib_Productos_JP.Interfaces;
using Lib_Productos_JP.Nucleo;

namespace Lib_Productos_JP.Implementaciones
{
    public class AuditoriasNegocio : IAuditorias
    {
        private IConexion? iConexion;

        public List<Auditorias> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var lista = this.iConexion.Auditorias!.ToList();

            return lista;
        }
    }
}