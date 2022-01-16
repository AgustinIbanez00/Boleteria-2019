using System.ComponentModel.DataAnnotations;

namespace Boleteria.Core.Models
{
    public class Destino
    {
        [Key]
        int id;
        [Key]
        [StringLength(128)]
        string nombre;
        double lat;
        double lng;
        //RadioButton radio_id;

        public Destino() { }

        public Destino(string nombre, double lat, double lng)
        {
            this.nombre = nombre;
            this.lat = lat;
            this.lng = lng;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double Latitud { get => lat; set => lat = value; }
        public double Longitud { get => lng; set => lng = value; }

        public int Id { get => id; set => id = value; }
        //public RadioButton Boton { get => radio_id; set => radio_id = value; }
    }
}
