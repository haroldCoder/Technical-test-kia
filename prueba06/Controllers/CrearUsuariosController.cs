using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba06.Models;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace prueba06.Controllers
{
    [Route("api")]
    [ApiController]
    public class CrearUsuariosController : ControllerBase
    {
        ModelDB md = new ModelDB();
        public required Usuarios usuario;


        [HttpPost("usuario")]
        public ActionResult<string> CrearUsuario([FromBody] Usuarios usuario)
        {
            this.usuario = usuario;
            SqlCommand cmd = new SqlCommand($"INSERT INTO Usuario(Nombre, Apellido, Documento) VALUES ('{this.usuario.Nombre}', '{usuario.Apellido}', '{usuario.Documento}')", md.connection());
            int rowAfffected = cmd.ExecuteNonQuery();

            if(rowAfffected > 0)
            {
                return "Usuario Agregado a la DB";
            }
            else
            {
                this.HttpContext.Response.StatusCode = 500;
                return "No se pudo añadir el usuario";
            }
        }
    }
}
