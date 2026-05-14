using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPPresentacion_Productos_JP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostBtSalir()
        {
            var lifetime = HttpContext.RequestServices
                .GetRequiredService<IHostApplicationLifetime>();
            lifetime.StopApplication();
            return Content("Aplicaion cerrada.");
        }
    }
}
