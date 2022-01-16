using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boleteria.Core.Models;

public class Boleto
{
    [Key]
    int id;
    Viaje recorrido;
    Destino origen;
    Destino destino;
    Cliente pasajero;
    Pago? pago;
    int asiento;
    Cuenta vendedor;
    DateTime fecha_emision;
    DateTime fecha;
    string precio;
    string hora_salida;
    string hora_salida_ad;
    string hora_llegada;
    string estado;

    public Boleto()
    {
    }

    public Boleto(Viaje recorrido, Destino origen, Destino destino, Cliente pasajero, int asiento, DateTime fecha, string precio, string hora_salida, string hora_salida_ad, string hora_llegada, Cuenta vendedor)
    {
        fecha_emision = DateTime.Now;
        this.recorrido = recorrido;
        this.origen = origen;
        this.destino = destino;
        this.pasajero = pasajero;
        this.asiento = asiento;
        this.fecha = fecha;
        this.precio = precio;
        this.hora_salida = hora_salida;
        this.hora_salida_ad = hora_salida_ad;
        this.hora_llegada = hora_llegada;
        this.vendedor = vendedor;
        estado = "PENDIENTE";
    }

    public Boleto(Viaje recorrido, Destino origen, Destino destino, Cliente pasajero, int asiento, DateTime fecha, string precio, string hora_salida, string hora_salida_ad, string hora_llegada, string estado, Cuenta vendedor, DateTime fecha_emision)
    {
        this.fecha_emision = fecha_emision;
        this.recorrido = recorrido;
        this.origen = origen;
        this.destino = destino;
        this.pasajero = pasajero;
        this.asiento = asiento;
        this.fecha = fecha;
        this.precio = precio;
        this.hora_salida = hora_salida;
        this.hora_salida_ad = hora_salida_ad;
        this.hora_llegada = hora_llegada;
        this.vendedor = vendedor;
        this.estado = estado;
    }

    public int ID { get => id; set => id = value; }
    public Viaje Recorrido { get => recorrido; set => recorrido = value; }
    public Destino Origen { get => origen; set => origen = value; }
    public Destino Destino { get => destino; set => destino = value; }
    public Cliente Pasajero { get => pasajero; set => pasajero = value; }
    public Pago Pago { get => pago; set => pago = value; }
    public int Asiento { get => asiento; set => asiento = value; }


    public string Precio { get => precio; set => precio = value; }
    public string HoraSalida { get => hora_salida; set => hora_salida = value; }
    public string HoraSalidaAdicional { get => hora_salida_ad; set => hora_salida_ad = value; }
    public string HoraLlegada { get => hora_llegada; set => hora_llegada = value; }
    public string Estado { get => estado; set => estado = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public DateTime FechaEmision { get => fecha_emision; set => fecha_emision = value; }
    public Cuenta Vendedor { get => vendedor; set => vendedor = value; }
}
