using Lib_Productos_JP.Implementaciones;
using Lib_Productos_JP.Interfaces;
using Lib_Productos_JP.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ASP_tv_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControllerBase
    {
        private IAuditorias? IAuditoriasNegocio;

        public AuditoriasController()
        {
            IAuditoriasNegocio = new AuditoriasNegocio();
        }

        [HttpGet]
        public List<Auditorias> Consultar()
        {
            if (IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return IAuditoriasNegocio!.Consultar();
        }
    }
}