using System.ComponentModel.DataAnnotations;

namespace Boleteria.Core.Models;

public class Viaje
{
    [Key]
    int id;
    [Key]
    [StringLength(128)]
    string nombre;
    List<Horario> horarios;
    List<Arco> arcos;
    public Viaje(string nombre)
    {
        this.nombre = nombre;
    }

    public Viaje(string nombre, Horario horario)
    {
        this.nombre = nombre;
        horarios.Add(horario);
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public List<Horario> Horarios { get => horarios; set => horarios = value; }
    public List<Arco> Arcos { get => arcos; set => arcos = value; }
}
