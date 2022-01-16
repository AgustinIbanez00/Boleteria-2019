using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Boleteria.Core.Models;
using Boleteria.Models;

namespace Boleteria
{
    public partial class frmAsientosSelect : Form
    {
        public int butaca = 0;

        public frmAsientosSelect()
        {
            InitializeComponent();
        }

        #region Métodos delegados.

        public static void Viajes_LoadReferences(ref List<Viaje> viajes, EntityDataModel db) { FrmDestinos.Viajes_LoadReferences(ref viajes, db); }
        public static void Viaje_LoadReferences(Viaje viaje, EntityDataModel db) { FrmDestinos.Viaje_LoadReferences(viaje, db); }
        public static void Boletos_LoadReferences(ref List<Boleto> boletos, EntityDataModel db) { FrmDestinos.Boletos_LoadReferences(ref boletos, db); }
        public static void Boleto_LoadReferences(Boleto boleto, EntityDataModel db) { FrmDestinos.Boleto_LoadReferences(boleto, db); }
        public static void Distribucion_LoadReferences(Distribucion distribucion, EntityDataModel db) { FrmDestinos.Distribucion_LoadReferences(distribucion, db); }
        public static Viaje GetDBViaje(EntityDataModel db, string nombre_viaje) { return FrmDestinos.GetDBViaje(db, nombre_viaje); }
        public static Distribucion GetDBDistribucion(EntityDataModel db, string nota) { return FrmDestinos.GetDBDistribucion(db, nota); }
        public static Boleto GetDBBoleto(EntityDataModel db, int id) { return FrmDestinos.GetDBBoleto(db, id); }
        public static Destino GetDBDestino(EntityDataModel db, string nombre_destino) { return FrmDestinos.GetDBDestino(db, nombre_destino); }
        public static Cliente GetDBCliente(EntityDataModel db, string nombre_cliente) { return FrmDestinos.GetDBCliente(db, nombre_cliente); }
        public static Cliente GetDBCliente(EntityDataModel db, long dni_cliente) { return FrmDestinos.GetDBCliente(db, dni_cliente); }
        public static DateTime GetDBDateNow(EntityDataModel db) { return FrmDestinos.GetDBDateNow(db); }

        #endregion

        Distribucion distribucion;
        
        Viaje viaje;
        DateTime fecha;
        string hora_salida;
        string origen;
        string destino;

        public frmAsientosSelect(Distribucion distribucion, Viaje viaje, DateTime fecha, string hora_salida, string origen, string destino)
        {
            this.distribucion = distribucion;
            
            this.viaje = viaje;
            this.fecha = fecha;
            this.hora_salida = hora_salida;
            this.origen = origen;
            this.destino = destino;
            InitializeComponent();
        }

        private void frmAsientosSelect_Load(object sender, EventArgs e)
        {
            DrawDistribution();
        }

        private void DrawDistribution()
        {
            const int ESPACIO_NULL = -1;
            const int ESPACIO_PASILLO = 1;
            const int ESPACIO_BUTACA = 2;
            const int ESPACIO_TV = 3;

            if (rbPB.Checked)
            {
                dgvAsientos.Rows.Clear();

                try
                {
                    nudDistrCantidad.Value = distribucion.Matriz_PB.Count * 5;
                }
                catch (ArgumentOutOfRangeException)
                {

                }

                if (!EsDoblePiso(distribucion)) rbPA.Enabled = false;

                DataGridViewButtonCell c;
                for (int i = 0; i < distribucion.Matriz_PB.Count; i++)
                {
                    dgvAsientos.Rows.Add();
                    for (int j = 0; j < 5; j++)
                    {
                        switch (distribucion.GetCellContent("PB", i, j))
                        {
                            case ESPACIO_BUTACA:
                                c = new DataGridViewButtonCell();
                                c.Tag = "A";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_PASILLO:
                                c = new DataGridViewButtonCell();
                                c.Tag = "P";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_TV:
                                c = new DataGridViewButtonCell();
                                c.Tag = "T";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_NULL:
                                c = new DataGridViewButtonCell();
                                c.Tag = "N";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            default:
                                c = new DataGridViewButtonCell();
                                c.Tag = "N";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                        }
                    }
                }
                ContarAsientos();

            }
            else if (rbPA.Checked)
            {
                dgvAsientos.Rows.Clear();

                try
                {
                    nudDistrCantidad.Value = distribucion.Matriz_PA.Count * 5;
                }
                catch (ArgumentOutOfRangeException)
                {

                }

                DataGridViewButtonCell c;
                for (int i = 0; i < distribucion.Matriz_PA.Count; i++)
                {
                    dgvAsientos.Rows.Add();
                    for (int j = 0; j < 5; j++)
                    {
                        switch (distribucion.GetCellContent("PA", i, j))
                        {
                            case ESPACIO_BUTACA:
                                c = new DataGridViewButtonCell();
                                c.Tag = "A";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_PASILLO:
                                c = new DataGridViewButtonCell();
                                c.Tag = "P";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_TV:
                                c = new DataGridViewButtonCell();
                                c.Tag = "T";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_NULL:
                                c = new DataGridViewButtonCell();
                                c.Tag = "N";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            default:
                                c = new DataGridViewButtonCell();
                                c.Tag = "N";
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                        }
                    }
                }
                ContarAsientos();
            }
        }

        private void ContarAsientos()
        {
            using (EntityDataModel db = new EntityDataModel())
            {

                int i = 0;
                if (rbPA.Checked)
                {
                    i = 1;
                    for (int j = 0; j < distribucion.Matriz_PB.Count; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (distribucion.GetCellContent("PB", j, k) == 2)
                                i++;
                        }
                    }
                }
                else if (rbPB.Checked)
                {
                    i = 1;
                }
                foreach (DataGridViewRow d in dgvAsientos.Rows)
                {
                    foreach (DataGridViewButtonCell c in d.Cells)
                    {
                        switch (c.Tag)
                        {
                            case "A":
                                c.Value = i.ToString();
                                c.ToolTipText = "Butaca disponible";
                                i++;
                                c.Style.BackColor = Color.LightGreen;
                                c.Style.ForeColor = Color.Black;
                                c.Style.SelectionForeColor = Color.Black;
                                c.FlatStyle = FlatStyle.Flat;

                                int asiento = Convert.ToInt32(c.Value);

                                var boletos = db.Boletos.Where(b => b.HoraSalida == hora_salida && b.Recorrido.Id == viaje.Id && b.Fecha.Year == fecha.Year && b.Fecha.Month == fecha.Month && b.Fecha.Day == fecha.Day && b.Asiento == asiento).ToList();
                                Boletos_LoadReferences(ref boletos, db);

                                foreach (Boleto b in boletos)
                                {
                                    List<string> siguientes = new List<string>();
                                    frmPrincipal.MostrarSiguientes(viaje, siguientes, origen, destino);
                                    siguientes.Add(origen);

                                    List<string> siguientes_boleto = new List<string>();
                                    frmPrincipal.MostrarSiguientes(viaje, siguientes_boleto, b.Origen.Nombre, b.Destino.Nombre);
                                    siguientes_boleto.Add(b.Origen.Nombre);

                                    foreach (var str in siguientes_boleto)
                                    {
                                        if (siguientes.Contains(str))
                                        {
                                            if (b.Estado == "PENDIENTE")
                                            {
                                                c.Style.BackColor = Color.Orange;
                                                c.ToolTipText = "BUTACA RESERVADA" + Environment.NewLine + Environment.NewLine + " - Pasajero: " + b.Pasajero.Nombre + Environment.NewLine + " - Desde: " + b.Origen.Nombre + Environment.NewLine + " - Hasta: " + b.Destino.Nombre;
                                            }
                                            else if (b.Estado == "VENDIDO")
                                            {
                                                c.Style.BackColor = Color.Tomato;
                                                c.ToolTipText = "BUTACA NO DISPONIBLE" + Environment.NewLine + Environment.NewLine + " - Pasajero: " + b.Pasajero.Nombre + Environment.NewLine + " - Desde: " + b.Origen.Nombre + Environment.NewLine + " - Hasta: " + b.Destino.Nombre;
                                            }
                                            c.ReadOnly = true;
                                        }
                                    }

                                }
                                break;
                            case "P":
                                c.Value = c.Tag;
                                c.ToolTipText = "Pasillo";
                                c.Style.BackColor = Color.White;
                                c.Style.ForeColor = Color.Silver;
                                c.Style.SelectionForeColor = Color.Black;
                                c.FlatStyle = FlatStyle.Flat;
                                break;
                            case "T":
                                c.Value = "TV";
                                c.ToolTipText = "Televisión";
                                c.Style.BackColor = Color.LightSkyBlue;
                                c.Style.ForeColor = Color.Blue;
                                c.Style.SelectionForeColor = Color.Blue;
                                c.FlatStyle = FlatStyle.Flat;
                                break;
                            case "N":
                                c.Value = c.Tag;
                                c.Style.BackColor = Color.White;
                                c.Style.ForeColor = Color.Silver;
                                c.Style.SelectionForeColor = Color.Black;
                                c.FlatStyle = FlatStyle.Flat;
                                break;
                        }
                    }
                }
            }
        }

        private void dgvAsientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewButtonCell d in dgvAsientos.SelectedCells)
            {
                if(d.Tag.ToString() == "A" && d.Style.BackColor == Color.LightGreen)
                {
                    butaca = Convert.ToInt32(d.Value);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                }
            }
        }


        private bool EsDoblePiso(Distribucion distribucion)
        {
            if (distribucion != null)
            {
                for (int i = 0; i < distribucion.Matriz_PA.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (distribucion.GetCellContent("PA", i, j) > 0)
                            return true;
                    }
                }
            }
            return false;
        }

        private void rbPA_CheckedChanged(object sender, EventArgs e)
        {
            DrawDistribution();
        }

        private void rbPB_CheckedChanged(object sender, EventArgs e)
        {
            DrawDistribution();
        }
        /*
        private bool ExisteOtroBoleto(List<string> list)
        {

            foreach (Boleto bol in boletos) if (list.Exists(sig => sig.Equals(bol.Origen.Nombre) || sig.Equals(bol.Destino.Nombre))) return true;
            return false;
        }

        private bool ExisteOtroOrigen(List<string> list)
        {
            foreach (Boleto bol in boletos) if (list.Exists(sig => sig.Equals(bol.Origen.Nombre))) return true;                            
            return false;
        }

        private bool ExisteOtroDestino(List<string> list)
        {
            foreach (Boleto bol in boletos) if (list.Exists(sig => sig.Equals(bol.Destino.Nombre))) return true;
            return false;
        }
        */

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void dgvAsientos_SelectionChanged(object sender, EventArgs e)
        { 
            foreach(DataGridViewRow r in dgvAsientos.SelectedRows)
            {
                foreach(DataGridViewCell d in dgvAsientos.SelectedCells)
                {
                    int R = 0;
                    int G = 0;
                    int B = 0;
                    if (d.Style.BackColor.R - 50 >= 0) R = d.Style.BackColor.R - 50;
                    if (d.Style.BackColor.G - 50 >= 0) G = d.Style.BackColor.G - 50;
                    if (d.Style.BackColor.B - 50 >= 0) B = d.Style.BackColor.B - 50;

                    r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(d.Style.BackColor.A, R, G, B);
                    return;
                }
            }
        }
    }
}
