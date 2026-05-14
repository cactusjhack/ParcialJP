using Lib_Productos_JP.Entidades;
using Lib_Productos_JP.Implemetaciones;
using Lib_Productos_JP.Interfaces;
using Lib_Productos_JP.Nucleo;

namespace Lib_Productos_JP.Implementaciones
{
    public class TiendasNegocio : ITiendasNegocio
    {
        private IConexion? iConexion;

        public List<Tiendas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var lista = this.iConexion.Tiendas!.ToList();

            return lista;
        }

        public Tiendas Guardar(Tiendas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.Tiendas!.Add(entidad!);
            this.iConexion.SaveChanges();

            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Tiendas",
                Accion = $"Se guardo el studio {entidad.Nombre} con id {entidad.Id}",
                Fecha = DateTime.Now
            });

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Tiendas Actualizar(Tiendas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("La tienda no existe");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.Tiendas!.Update(entidad!);
            this.iConexion.SaveChanges();

            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Tiendas",
                Accion = $"Se actualizo la tienda {entidad.Nombre} con id {entidad.Id}",
                Fecha = DateTime.Now
            });

            this.iConexion.SaveChanges();
            return entidad;
        }

        public bool Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = this.iConexion.Tiendas!.FirstOrDefault(x => x.Id == id);
            if (entidad == null)
                throw new Exception("La tienda no existe");


            this.iConexion.Tiendas!.Remove(entidad!);
            this.iConexion.SaveChanges();

            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Tiendas",
                Accion = $"Se elimino la tienda {entidad.Nombre} con id {entidad.Id}",
                Fecha = DateTime.Now
            });

            this.iConexion.SaveChanges();
            return true;
        }

    }
}