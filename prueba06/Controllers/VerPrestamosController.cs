using Microsoft.AspNetCore.Mvc;
using prueba06.Models;
using System.Data.SqlClient;

namespace prueba06.Controllers
{
    [Route("api")]
    [ApiController]
    public class VerPrestamosController : Controller
    {
        ModelDB modeldb = new ModelDB();
        Prestamos prestamo;


        [HttpGet("prestamos")]
        public List<Prestamos> VerPrestamos()
        {
            SqlCommand cmd = new SqlCommand("SELECT Usuario.Nombre, Libro.Nombre, Prestamo.fecha_final FROM Prestamo JOIN Usuario ON Prestamo.Id_usuario = Usuario.Id JOIN Libro ON Prestamo.Id_libro = Libro.Id", modeldb.connection());
            var reader = cmd.ExecuteReader();
            var prestamos = new List<Prestamos>();
            while (reader.Read())
            {
                var prestamo = new Prestamos()
                {
                    nombre = reader.GetString(0),
                    nombre_libro = reader.GetString(1),
                    fecha_final = reader.GetDateTime(2)
                };
                prestamos.Add(prestamo);
            }
            var cm2 = new SqlCommand("DELETE FROM Prestamo WHERE Prestamo.fecha_final = DATEADD(day, 10, getdate())", modeldb.connection());
            return prestamos;
        }
    }
}
