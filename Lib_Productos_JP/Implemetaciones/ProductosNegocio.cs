using Lib_Productos_JP.Entidades;
using Lib_Productos_JP.Implemetaciones;
using Lib_Productos_JP.Interfaces;
using Lib_Productos_JP.Nucleo;

namespace Lib_Productos_JP.Implementaciones
{
    public class ProductosNegocio : IProductosNegocio
    {
        private IConexion? iConexion;

        public List<Productos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var lista = this.iConexion.Productos!.ToList();

            return lista;
        }

        public Productos Guardar(Productos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            //var serie = this.iConexion.Series!.FirstOrDefault(x => x.Id == entidad.Id);
            //if (serie == null)
                //throw new Exception("La serie no existe");

            this.iConexion.Productos!.Add(entidad!);
            this.iConexion.SaveChanges();

            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Productos",
                Accion = $"Se guardo el producto {entidad.Nombre} con id {entidad.Id}",
                Fecha = DateTime.Now
            });

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Productos Actualizar(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("La serie no existe");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.Productos!.Update(entidad!);
            this.iConexion.SaveChanges();

            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Productos",
                Accion = $"Se actualizo el producto {entidad.Nombre} con id {entidad.Id}",
                Fecha = DateTime.Now
            });

            this.iConexion.SaveChanges();
            return entidad;
        }

        public bool Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = this.iConexion.Productos!.FirstOrDefault(x => x.Id == id);
            if (entidad == null)
                throw new Exception("La serie no existe");


            this.iConexion.Productos!.Remove(entidad!);
            this.iConexion.SaveChanges();

            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Productos",
                Accion = $"Se elimino Productos {entidad.Nombre} con id {entidad.Id}",
                Fecha = DateTime.Now
            });

            this.iConexion.SaveChanges();
            return true;
        }

    }
}