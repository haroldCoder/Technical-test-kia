using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba06.Models;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace prueba06.Controllers
{
    [Route("api")]
    [ApiController]
    public class PrestamoSystemController : ControllerBase
    {
        Prestamos prestamo;
        ModelDB md = new ModelDB();
        int cant_stock = 1;

        [HttpPost("prestamo")]
        public string CrearPrestamo([FromBody] Prestamos prestamo) {
            this.prestamo = prestamo;

            SqlCommand cmd2 = new SqlCommand($"SELECT Id_usuario FROM Prestamo WHERE Id_usuario = {prestamo.Id_usuario}", md.connection());
            int count_us = cmd2.ExecuteNonQuery();
            if (count_us > 0)
            {
                return "Ya tienes un prestamo realizado";
            }
            else
            {
                SqlCommand cmd3 = new SqlCommand($"SELECT Id_usuario FROM Prestamo WHERE fecha_final > DATEADD(day, 10, getdate())", md.connection());
                int count_us2 = cmd2.ExecuteNonQuery();
                if (count_us2 > 0)
                {
                    return "Tienes una fecha vencida en tu entrega";
                }
                else
                {
                    SqlCommand cmd4 = new SqlCommand("SELECT Libro.CatidadStock FROM Prestamo JOIN Libro ON Prestamo.Id_libro = Libro.Id WHERE Libro.CatidadStock = 0;", md.connection());
                    int v = cmd4.ExecuteNonQuery();
                    int stock = v;
                    if (stock > 0)
                    {
                        return "Ya no tienes como prestar mas libros, tu stock esta en 0";
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand($"INSERT INTO Prestamo(Id_libro, Id_usuario, fecha_inicio, fecha_final) VALUES({prestamo.Id_libro}, {prestamo.Id_usuario}, getdate(), DATEADD(day, 10, getdate()))", md.connection());
                         int rowAfffected = cmd.ExecuteNonQuery();

                        if (rowAfffected > 0)
                        {
                            SqlCommand cant_stock = new SqlCommand("SELECT Libro.CatidadStock FROM Prestamo JOIN Libro ON Prestamo.Id_libro = Libro.Id WHERE CatidadStock = 0;", md.connection());

                            this.cant_stock = cant_stock.ExecuteNonQuery();
                            SqlCommand reduxstock = new SqlCommand($"UPDATE Libros SET CantidadStock = {this.cant_stock-1} WHERE ID = {prestamo.Id_libro}", md.connection());
                            return "Prestamo Agregado a la DB";
                        }
                        else
                        {
                            return "No se pudo agregar el Prestamo";
                        }
                    }
                }
            }
            }
    }
}
