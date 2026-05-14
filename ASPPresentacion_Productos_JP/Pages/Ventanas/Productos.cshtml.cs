using Lib_Productos_JP.Entidades;
using Lib_Productos_JP.Implementaciones;
using Lib_Productos_JP.Interfaces;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPPresentacion_Productos_JP.Pages.Ventanas
{
    public class ProductosModel : PageModel
    {
        private IProductosNegocio? iProductosNegocio;

        [BindProperty] public List<Productos>? Lista { get; set; }
        [BindProperty] public Productos? Producto { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public ProductosModel()
        {
            iProductosNegocio = new ProductosNegocio();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iProductosNegocio?.Consultar();
                Producto = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            ModelState.Clear();
            Producto = new Productos();
            Borrando = false;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Producto == null) return;
                if (Producto.Id == 0)
                    Producto = iProductosNegocio!.Guardar(Producto);
                else
                    Producto = iProductosNegocio!.Actualizar(Producto);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Producto = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Producto = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Producto == null) return;
                iProductosNegocio!.Eliminar(Producto.Id);
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
