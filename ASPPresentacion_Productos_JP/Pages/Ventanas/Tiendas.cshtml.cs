using Lib_Productos_JP.Entidades;
using Lib_Productos_JP.Implementaciones;
using Lib_Productos_JP.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPPresentacion_Productos_JP.Pages.Ventanas
{
    public class TiendasModel : PageModel
    {
        private ITiendasNegocio? iTiendasNegocio;

        [BindProperty] public List<Tiendas>? Lista { get; set; }
        [BindProperty] public Tiendas? Tienda { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public TiendasModel()
        {
            iTiendasNegocio = new TiendasNegocio();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iTiendasNegocio?.Consultar();
                Tienda = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Tienda = new Tiendas();
            Borrando = false;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Tienda == null) return;
                if (Tienda.Id == 0)
                    Tienda = iTiendasNegocio!.Guardar(Tienda);
                else
                    Tienda = iTiendasNegocio!.Actualizar(Tienda);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Tienda = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Tienda = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Tienda == null) return;
                iTiendasNegocio!.Eliminar(Tienda.Id);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
