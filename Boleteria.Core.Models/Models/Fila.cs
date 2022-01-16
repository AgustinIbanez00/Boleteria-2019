using System.ComponentModel.DataAnnotations;

namespace Boleteria.Core.Models
{
    public class Fila
    {
        [Key]
        public int Id { get; set; }
        public List<Celda>? Cells { get; set; }
    }
}
