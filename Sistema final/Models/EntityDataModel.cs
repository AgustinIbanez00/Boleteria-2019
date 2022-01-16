using System;
using Boleteria.Core.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Boleteria.Models
{
    public class EntityDataModel : DbContext
    {
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            MySqlConnectionStringBuilder connectionStringBuilder = new();

            connectionStringBuilder.Server = "localhost";
            connectionStringBuilder.UserID = "root";
            connectionStringBuilder.Password = "";
            connectionStringBuilder.Database = "boleteria_2019";
            connectionStringBuilder.PersistSecurityInfo = true;
            connectionStringBuilder.SslMode = MySqlSslMode.None;


            optionsBuilder.UseMySql(connectionStringBuilder.ToString(), new MariaDbServerVersion(new Version(10, 4, 7)));

            base.OnConfiguring(optionsBuilder);
        }
    }
}