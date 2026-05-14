using Lib_Productos_JP.Entidades;
using Lib_Productos_JP.Implementaciones;
using Lib_Productos_JP.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPPresentacion_Productos_JP.Pages.Ventanas
{
    public class AuditoriasModel : PageModel
    {
        private IAuditorias? iAuditoriasNegocio;

        [BindProperty] public List<Auditorias>? Lista { get; set; }
        [BindProperty] public Auditorias? Auditoria { get; set; }

        public AuditoriasModel()
        {
            iAuditoriasNegocio = new AuditoriasNegocio();
        }

        public IActionResult OnGet()
        {
            OnPostBtRefrescar();
            return Page();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iAuditoriasNegocio?.Consultar();
                Auditoria = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
    }
}
