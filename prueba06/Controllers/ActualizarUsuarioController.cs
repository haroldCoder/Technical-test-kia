using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba06.Models;
using System.Data.SqlClient;

namespace prueba06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualizarUsuarioController : ControllerBase
    {
        Usuarios usuarios;
        ModelDB md = new ModelDB();

        public string ActualizarUsuario([FromBody] Usuarios user, [FromHeader] int Id)
        {
            usuarios = user;
            SqlCommand cmd = new SqlCommand($"UPDATE Usuario SET Nombre = '{usuarios.Nombre}', Apellido = '{usuarios.Apellido}', Documento = '{usuarios.Documento} WHERE Id = {Id}'", md.connection());

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
