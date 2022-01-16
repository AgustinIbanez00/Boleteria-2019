using System.ComponentModel.DataAnnotations;

namespace Boleteria.Core.Models
{
    public class Cliente
    {
        [Key]
        int id;
        int dni;
        string nombre;
        string nacionalidad;
        string genero;
        DateTime fechaNac;
        DateTime fechaReg;

        public Cliente() { }

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public DateTime FechaReg { get => fechaReg; set => fechaReg = value; }
        public int DNI { get => dni; set => dni = value; }
        public int ID { get => id; set => id = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Genero { get => genero; set => genero = value; }

        public Cliente(string nombre, int dni, string nacionalidad, string genero, DateTime fechaNac, DateTime fechaReg)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.nacionalidad = nacionalidad;
            this.genero = genero;
            this.fechaNac = fechaNac;
            this.fechaReg = fechaReg;
        }
    }
}
