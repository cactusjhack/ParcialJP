using Lib_Productos_JP.Implemetaciones;
using Lib_Productos_JP.Interfaces;

Console.WriteLine("Conexion a base de datos");
IConexion conexion = new Conexion();
conexion.StringConexion = "server=localhost;integrated Security=True;TrustServerCertificate=true;database=db_tienda;";
var lista_auditorias = conexion.Auditorias!.ToList();
var lista_productos = conexion.Productos!.ToList();
var lista_tiendas = conexion.Tiendas!.ToList();

Console.WriteLine("Productos");
foreach (var c in lista_productos)
{
    Console.WriteLine($"{c.Id} - {c.Nombre}  ");
}

Console.WriteLine("Final");