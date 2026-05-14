using Lib_Productos_JP.Entidades;
using Lib_Productos_JP.Implementaciones;
using Lib_Productos_JP.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_tv_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControllerBase
    {
        private IProductosNegocio? iProductosNegocio;

        public ProductosController()
        {
            iProductosNegocio = new ProductosNegocio();
        }

        [HttpGet]
        public List<Productos> Consultar()
        {
            if (iProductosNegocio == null)
                throw new Exception("No implementado");
            return iProductosNegocio!.Consultar();
        }

        [HttpPost]
        public Productos Guardar([FromBody] Productos entidad)
        {
            if (iProductosNegocio == null)
                throw new Exception("No implementado");
            return iProductosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Productos Actualizar([FromBody] Productos entidad)
        {
            if (iProductosNegocio == null)
                throw new Exception("No implementado");
            return iProductosNegocio!.Actualizar(entidad);
        }

        [HttpDelete("{id}")]
        public bool Eliminar(int id)
        {
            if (iProductosNegocio == null)
                throw new Exception("No implementado");
            return iProductosNegocio!.Eliminar(id);
        }
    }
}
