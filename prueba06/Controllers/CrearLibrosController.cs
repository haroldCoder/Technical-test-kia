using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba06.Models;
using System.Data.SqlClient;

namespace prueba06.Controllers
{
    [Route("api")]
    [ApiController]
    public class CrearLibrosController : ControllerBase
    {
        ModelDB md = new ModelDB();
        Libros libro;

        [HttpPost("libro")]
        public string PublicarLibro([FromBody] Libros libro)
        {
            this.libro = libro;
            SqlCommand cmd = new SqlCommand($"INSERT INTO Libro(Nombre, ISBN, CatidadStock) VALUES ('{libro.Nombre}', '{libro.ISBN}', {libro.CantidadStock})", md.connection());
            int rowAfffected = cmd.ExecuteNonQuery();

            if (rowAfffected > 0)
            {
                return "Libro Agregado a la DB";
            }
            else
            {
                return "No se pudo agregar el Libro";
            }
        }
    }
}
