using System.ComponentModel.DataAnnotations;

namespace Boleteria.Core.Models
{
    public class Horario
    {
        [Key]
        int id;
        string hora;
        Fila frecuencia;
        Distribucion distribucion;

        public Horario()
        {
        }

        public Horario(string hora, List<Celda> frecuencia, Distribucion distribucion)
        {
            this.hora = hora;
            this.distribucion = distribucion;
        }

        public int Id { get => id; set => id = value; }
        public string Hora { get => hora; set => hora = value; }

        public Distribucion Distribucion { get => distribucion; set => distribucion = value; }
        public Fila Frecuencia { get => frecuencia; set => frecuencia = value; }
    }
}
