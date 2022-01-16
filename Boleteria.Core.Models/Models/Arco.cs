using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boleteria.Core.Models
{
    [Table("Arista")]
    public class Arco
    {
        [Key]
        int id;
        [Key]
        Destino origen;
        Destino destino;
        string demora;
        double precio;

        public Arco() { }

        public int Id { get => id; set => id = value; }
        public Destino Origen { get => origen; set => origen = value; }
        public Destino Destino { get => destino; set => destino = value; }
        public string Demora { get => demora; set => demora = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}