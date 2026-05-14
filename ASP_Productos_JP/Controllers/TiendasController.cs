using Lib_Productos_JP.Interfaces;
using Lib_Productos_JP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Lib_Productos_JP.Implementaciones;

namespace ASP_Productos_JP.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TiendasController : ControllerBase
    {
        private ITiendasNegocio? ITiendasNegocio;

        public TiendasController()
        {
            ITiendasNegocio = new TiendasNegocio();
        }

        [HttpGet]
        public List<Tiendas> Consultar()
        {
            if (ITiendasNegocio == null)
                throw new Exception("No implementado");
            return ITiendasNegocio!.Consultar();
        }

        [HttpPost]
        public Tiendas Guardar([FromBody] Tiendas entidad)
        {
            if (ITiendasNegocio == null)
                throw new Exception("No implementado");
            return ITiendasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Tiendas Actualizar([FromBody] Tiendas entidad)
        {
            if (ITiendasNegocio == null)
                throw new Exception("No implementado");
            return ITiendasNegocio!.Actualizar(entidad);
        }

        [HttpDelete("{id}")]
        public bool Eliminar(int id)
        {
            if (ITiendasNegocio == null)
                throw new Exception("No implementado");
            return ITiendasNegocio!.Eliminar(id);
        }
    }
}