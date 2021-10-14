namespace Sistema_final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Windows.Forms;

    public class EntityDataModel : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'EntityDataModel' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'Sistema_final.Models.EntityDataModel' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'EntityDataModel'  en el archivo de configuración de la aplicación.
        public EntityDataModel()
            : base("name=EntityDataModel")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        //public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Arco> Arcos { get; set; }
        public virtual DbSet<Boleto> Boletos { get; set; }
        public virtual DbSet<Celda> Celdas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }       
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Destino> Destinos { get; set; }
        public virtual DbSet<Distribucion> Distribuciones { get; set; }
        public virtual DbSet<Fila> Filas { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Viaje> Viajes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destino>()
                  .Ignore(i => i.Boton);
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            
            /*
            modelBuilder.Entity<Cuenta>().HasIndex(c => c.Usuario).IsUnique();
            modelBuilder.Entity<Cliente>().HasIndex(c => c.DNI).IsUnique();
            modelBuilder.Entity<Destino>().HasIndex(d => d.Nombre).IsUnique();
            modelBuilder.Entity<Distribucion>().HasIndex(d => d.Nota).IsUnique();
            modelBuilder.Entity<Viaje>().HasIndex(v => v.Nombre).IsUnique();
            */
        }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

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
    [Table("Boleto")]
    public class Boleto
    {
        [Key]
        int id;
        Viaje recorrido;
        Destino origen;
        Destino destino;
        Cliente pasajero;
        Pago pago;
        int asiento;
        Cuenta vendedor;
        DateTime fecha_emision;
        DateTime fecha;
        string precio;
        string hora_salida;
        string hora_salida_ad;
        string hora_llegada;
        string estado;

        public Boleto ()
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
    [Table("Cliente")]
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

        public Cliente () { }
        
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
    [Table("Cuenta")]
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
    [Table("Destino")]
    public class Destino
    {
        [Key]
        int id;
        [Key]
        [StringLength(128)]
        string nombre;
        double lat;
        double lng;
        RadioButton radio_id;

        public Destino () { }

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
        public RadioButton Boton { get => radio_id; set => radio_id = value; }
    }
    [Table("Celda")]
    public class Celda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id;
        int value;
        DateTime fecha_registro;

        public int Id { get => id; set => id = value; }
        public int Value { get => value; set => this.value = value; }
        public DateTime Fecha_registro { get => fecha_registro; set => fecha_registro = value; }

        public Celda() { }
    }
    [Table("Fila")]
    public class Fila
    {
        [Key]
        int id;
        
        List<Celda> cells;

        public int Id { get => id; set => id = value; }
        public List<Celda> Cells { get => cells; set => cells = value; }
    }
    [Table("Distribucion")]
    public class Distribucion
    {
        [Key]
        int id;
        [Key]
        [StringLength(128)]
        string nota;
        int cant_PB = 25;
        int cant_PA = 25;
        bool unPiso;
        List<Fila> matriz_PB;
        List<Fila> matriz_PA;

        public static int ESPACIO_NULL = -1;
        public static int ESPACIO_PASILLO = 1;
        public static int ESPACIO_BUTACA = 2;
        public static int ESPACIO_TV = 3;

        public Distribucion() { }

        public Distribucion(int cantidad_PB)
        {
            this.cant_PB = cantidad_PB;
            if (cantidad_PB / 5 > 0)
            {
                matriz_PB = InicializarListaCeldas((cantidad_PB / 5), 5);
            }
            //unPiso = true;
        }

        public Distribucion(int cantidad_PB, int cantidad_PA)
        {
            this.cant_PB = cantidad_PB;
            this.cant_PA = cantidad_PA;
            if (cantidad_PB / 5 > 0)
            {              
                matriz_PB = InicializarListaCeldas((cantidad_PB / 5), 5);                
            }
            if (cantidad_PA / 5 > 0)
            {
                matriz_PA = InicializarListaCeldas((cantidad_PA / 5), 5);                
            }
            //unPiso = false;
        }
        
        public List<Fila> InicializarListaCeldas(int rows, int columns)
        {
            List<Fila> row_list = new List<Fila>();

            for (int i = 0; i < rows; i++)
            {
                Fila fila = new Fila();
                fila.Cells = new List<Celda>();

                for (int j = 0; j < columns; j++)
                {
                    Celda celda = new Celda()
                    {
                        Value = 0,
                        Fecha_registro = DateTime.Now                     
                    };
                    fila.Cells.Add(celda);
                }
                row_list.Add(fila);
            }
            return row_list;
        }
        
        public void AddRowCells(string matriz, int rows)
        {
            List<Fila> matriz_list = null;
            int rows_temp = -1;

            if (matriz == "PB") {
                matriz_list = matriz_PB;
                rows_temp = matriz_PB.Count;
            }
            else if (matriz == "PA") {
                matriz_list = matriz_PA;
                rows_temp = matriz_PA.Count;
            }

            if(matriz_list != null && rows_temp != -1)
            {
                for (int i = 0; i < rows; i++)
                {
                    Fila row = new Fila();
                    row.Cells = new List<Celda>();
                    for (int j = 0; j < 5; j++)
                    {
                        Celda cell = new Celda()
                        {
                            Value = 0,
                            Fecha_registro = DateTime.Now
                        };
                        row.Cells.Add(cell);
                    }
                    matriz_list.Add(row);
                }                
            }
        }

        public void RemoveRowCells(string matriz, int rows)
        {
            List<Fila> matriz_list = null;
            int rows_temp = -1;

            if (matriz == "PB")
            {
                matriz_list = matriz_PB;
                rows_temp = matriz_PB.Count;
            }
            else if (matriz == "PA")
            {
                matriz_list = matriz_PA;
                rows_temp = matriz_PB.Count;
            }

            if(matriz_list != null && rows_temp != -1)
            {
                for (int i = 0; i < rows; i++)
                {
                    matriz_list.Remove(matriz_list.Last());
                }
            }
        }


        public void SetCellContent(string matriz, int fila, int columna, int value)
        {
            List<Fila> matriz_list = null;

            if (matriz == "PB") matriz_list = matriz_PB;
            else if (matriz == "PA") matriz_list = matriz_PA;               
            
            if(matriz_list != null)
            {
                matriz_list[fila].Cells[columna].Value = value;
            }
        }

        public int GetCellContent(string matriz, int fila, int columna)
        {
            List<Fila> matriz_list = null;

            if (matriz == "PB") matriz_list = matriz_PB;
            else if (matriz == "PA") matriz_list = matriz_PA;

            if (matriz_list != null) return matriz_list[fila].Cells[columna].Value;           
            return -1;
        }

        public void AgregarPasilloPB(int x, int y)
        {
            SetCellContent("PB", x, y, ESPACIO_PASILLO);            
        }

        public void AgregarButacaPB(int x, int y)
        {
            SetCellContent("PB", x, y, ESPACIO_BUTACA);            
        }

        public void AgregarTVPB(int x, int y)
        {
            SetCellContent("PB", x, y, ESPACIO_TV);            
        }

        public void RemoverPB(int x, int y)
        {
            SetCellContent("PB", x, y, ESPACIO_NULL);           
        }

        public void AgregarPasilloPA(int x, int y)
        {
            SetCellContent("PA", x, y, ESPACIO_PASILLO);           
        }

        public void AgregarButacaPA(int x, int y)
        {
            SetCellContent("PA", x, y, ESPACIO_BUTACA);           
        }

        public void AgregarTVPA(int x, int y)
        {
            SetCellContent("PA", x, y, ESPACIO_TV);            
        }

        public void RemoverPA(int x, int y)
        {
            SetCellContent("PA", x, y, ESPACIO_NULL);            
        }

        public int Id { get => id; set => id = value; }
        public List<Fila> Matriz_PB { get => matriz_PB; set => matriz_PB = value; }
        public List<Fila> Matriz_PA { get => matriz_PA; set => matriz_PA = value; }
        public string Nota { get => nota; set => nota = value; }
        public bool UnPiso { get => unPiso; set => unPiso = value; }

        /*
public int FilasPB { get => filas_pb;
set
{
if (matriz_PB == null && value != 0) matriz_PB = InicializarListaCeldas(value, 5);

if (value != filas_pb && filas_pb != 0)
{
if(value > filas_pb)
{
AddRowCells("PB", value-filas_pb);
}
else if(value < filas_pb)
{
RemoveRowCells("PB", filas_pb-value);
}
}
filas_pb = value;
}
}
public int FilasPA { get => filas_pa;
set
{
if (matriz_PA == null && value != 0) matriz_PA = InicializarListaCeldas(value, 5);

if (value != filas_pa && filas_pa != 0)
{
if (value > filas_pa)
{
AddRowCells("PA", value-filas_pa);
}
else if (value < filas_pa)
{
RemoveRowCells("PA", filas_pa-value);
}
}
filas_pa = value;
}
}
*/
        public int ContarAsientos()
        {
            int c = 0;
            for (int i = 0; i < matriz_PA.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GetCellContent("PA", i, j) == ESPACIO_BUTACA)
                        c++;
                }
            }
            for (int i = 0; i < matriz_PB.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GetCellContent("PB", i, j) == ESPACIO_BUTACA)
                        c++;
                }
            }
            return c;
        }

    }
    [Table("Horario")]
    public class Horario
    {
        [Key]
        int id;    
        string hora;
        Fila frecuencia;
        Distribucion distribucion;

        public Horario()
        { }

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
    [Table("Pago")]
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

        public Pago () { }

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
    [Table("Viaje")]
    public class Viaje
    {
        [Key]
        int id;
        [Key]
        [StringLength(128)]
        string nombre;
        List<Horario> horarios;
        List<Arco> arcos;

        public Viaje() {
            
        }

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
    [NotMapped]
    public static class SecurePasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;

        public static string Hash(string password, int iterations)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);

            return string.Format("$MYHASH$V1${0}${1}", iterations, base64Hash);
        }

        public static string Hash(string password)
        {
            return Hash(password, 10000);
        }

        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$MYHASH$V1$");
        }

        public static bool Verify(string password, string hashedPassword)
        {
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }
            var splittedHashString = hashedPassword.Replace("$MYHASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }


}