using System.ComponentModel.DataAnnotations;

namespace Boleteria.Core.Models;
public class Pago
{
    [Key]
    int id;
    string codigo;
    int boleto;
    string tipo;
    string titular;
    long dni;
    string correo;
    string tarjeta;
    long nro_tarjeta;
    DateTime fecha_vencimiento;
    int precio;

    public Pago() { }

    public Pago(string codigo, int boleto, string tipo, string titular, long dni, string correo, string tarjeta, long nro_tarjeta, DateTime fecha_vencimiento, int precio)
    {
        this.codigo = codigo;
        this.boleto = boleto;
        this.tipo = tipo;
        this.titular = titular;
        this.dni = dni;
        this.correo = correo;
        this.tarjeta = tarjeta;
        this.nro_tarjeta = nro_tarjeta;
        this.fecha_vencimiento = fecha_vencimiento;
        this.precio = precio;
    }

    public int Id { get => id; set => id = value; }
    public string Codigo { get => codigo; set => codigo = value; }
    public int Boleto { get => boleto; set => boleto = value; }
    public string Tipo { get => tipo; set => tipo = value; }
    public string Titular { get => titular; set => titular = value; }
    public long Dni { get => dni; set => dni = value; }
    public string Correo { get => correo; set => correo = value; }
    public string Tarjeta { get => tarjeta; set => tarjeta = value; }
    public long Nro_tarjeta { get => nro_tarjeta; set => nro_tarjeta = value; }
    public DateTime Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
    public int Precio { get => precio; set => precio = value; }
}
