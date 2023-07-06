using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace prueba06.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
    }
}
