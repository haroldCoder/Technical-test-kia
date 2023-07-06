using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace prueba06.Models
{
    public class Prestamos
    {
        public int Id;
        public int Id_libro { get; set; }
        public int Id_usuario { get; set; }

        public string nombre { get; set; }

        public string nombre_libro { get; set; }

        public DateTime fecha_final { get; set; }
    }
}
