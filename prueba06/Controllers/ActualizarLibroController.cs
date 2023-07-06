using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba06.Models;
using System.Data.SqlClient;

namespace prueba06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualizarLibroController : ControllerBase
    {
        Libros libro;
        ModelDB md = new ModelDB();

        public string ActualizarUsuario([FromBody] Libros libro, [FromHeader] int Id)
        {
            this.libro = libro;
            SqlCommand cmd = new SqlCommand($"UPDATE Libro SET Nombre = '{libro.Nombre}', ISBN = '{libro.ISBN}', CantidadStock = '{libro.CantidadStock} WHERE Id = {Id}'", md.connection());
            int rowAfffected = cmd.ExecuteNonQuery();

            if (rowAfffected > 0)
            {
                return "Usuario Agregado a la DB";
            }
            else
            {
                return "No se pudo agregar el usuario";
            }
        }
    }
}
