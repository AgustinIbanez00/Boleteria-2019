using System.ComponentModel.DataAnnotations;

namespace Boleteria.Core.Models;

public class Cuenta
{
    [Key]
    int id;
    [Key]
    string usuario;
    string contraseña;
    string correo;
    DateTime fechanac;
    DateTime fechareg;
    string sexo;
    string tipo;

    public Cuenta() { }

    public Cuenta(string usuario, string contraseña, string correo, DateTime fechanac, DateTime fechareg, string sexo, string tipo)
    {
        this.usuario = usuario;
        this.contraseña = contraseña;
        this.correo = correo;
        this.fechanac = fechanac;
        this.fechareg = fechareg;
        this.sexo = sexo;
        this.tipo = tipo;
    }

    public int Id { get => id; set => id = value; }
    public string Usuario { get => usuario; set => usuario = value; }
    public string Contraseña { get => contraseña; set => contraseña = value; }
    public string Correo { get => correo; set => correo = value; }
    public DateTime Fechanac { get => fechanac; set => fechanac = value; }
    public DateTime Fechareg { get => fechareg; set => fechareg = value; }
    public string Sexo { get => sexo; set => sexo = value; }
    public string Tipo { get => tipo; set => tipo = value; }
}
