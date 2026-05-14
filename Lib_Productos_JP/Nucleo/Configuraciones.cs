namespace Lib_Productos_JP.Nucleo
{
    public class Configuraciones
    {
        public static string obtener(string clave)
        {
            return "server=localhost;integrated Security=True;TrustServerCertificate=true;database=db_tienda;";
        }
    }
}