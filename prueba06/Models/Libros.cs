using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace prueba06.Models
{
    public class Libros
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        [NotNull]
        public string ISBN { get; set; }
        [NotNull]
        public int CantidadStock { get; set; }
    }
}
