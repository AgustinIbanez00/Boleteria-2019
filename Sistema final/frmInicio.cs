using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using Sistema_final.Models;

namespace Sistema_final
{
    public partial class frmPrincipal : Form
    {
        int cuenta_id = 0;

        public frmPrincipal(int cuenta_id)
        {
            InitializeComponent();
            this.cuenta_id = cuenta_id;
        }
        bool actualizando = false;
        bool force_reload = true;

        int pagina = 1;
        int filasPorPagina = 15;

        string[,] horario_valores = new string[1, 1];

        List<Boleto> boletos_dibujados = new List<Boleto>();
        

        #region Métodos estáticos.

        public static void Viajes_LoadReferences(ref List<Viaje> viajes, EntityDataModel db) { frmDestinos.Viajes_LoadReferences(ref viajes, db); }
        public static void Viaje_LoadReferences(Viaje viaje, EntityDataModel db) { frmDestinos.Viaje_LoadReferences(viaje, db); }
        public static void Boletos_LoadReferences(ref List<Boleto> boletos, EntityDataModel db) { frmDestinos.Boletos_LoadReferences(ref boletos, db); }
        public static void Boleto_LoadReferences(Boleto boleto, EntityDataModel db) { frmDestinos.Boleto_LoadReferences(boleto, db); }
        public static void Distribucion_LoadReferences(Distribucion distribucion, EntityDataModel db) { frmDestinos.Distribucion_LoadReferences(distribucion, db); }
        public static Viaje GetDBViaje(EntityDataModel db, string nombre_viaje) { return frmDestinos.GetDBViaje(db, nombre_viaje); }
        public static Distribucion GetDBDistribucion(EntityDataModel db, string nota) { return frmDestinos.GetDBDistribucion(db, nota); }
        public static Boleto GetDBBoleto(EntityDataModel db, int id) { return frmDestinos.GetDBBoleto(db, id); }
        public static Destino GetDBDestino(EntityDataModel db, string nombre_destino) { return frmDestinos.GetDBDestino(db, nombre_destino); }
        public static Cliente GetDBCliente(EntityDataModel db, string nombre_cliente) { return frmDestinos.GetDBCliente(db, nombre_cliente); }
        public static Cliente GetDBCliente(EntityDataModel db, int dni_cliente) { return frmDestinos.GetDBCliente(db, dni_cliente); }
        public static DateTime GetDBDateNow(EntityDataModel db) { return frmDestinos.GetDBDateNow(db); }

        #endregion

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {

                using (EntityDataModel db = new EntityDataModel())
                {
                    DateTime fecha_server = GetDBDateNow(db);

                    tcHoraServer.Date = fecha_server;

                    ShowWaitDialog(new Action(RecargarViajes), "Cargando recorridos.. por favor espere.");
                    RecargarBoletos();
                    dtpFechaIda.MinDate = fecha_server;
                    dtpFechaIda.MaxDate = fecha_server.AddMonths(5);
                    dtpFechaVuelta.MinDate = fecha_server;
                    dtpFechaVuelta.MaxDate = fecha_server.AddMonths(5);

                    if (cbBoleto.Items.Count > 0) cbBoleto.SelectedIndex = 0;
                    if (cbTrayecto.Items.Count > 0) cbTrayecto.SelectedIndex = 0;
                    if (cbInformeTrayecto.Items.Count > 0) cbInformeTrayecto.SelectedIndex = 0;

                    rbFiltrosRecorrido.Checked = true;

                    ActualizarListaPasajeros();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Error interno", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMasOrigen_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                frmDestinos form = new frmDestinos();
                if (form.ShowDialog() != DialogResult.None)
                {
                    try
                    {
                        ShowWaitDialog(new Action(RecargarViajes), "Actualizando destinos.. por favor espere.");
                        db.SaveChanges();
                        RecargarBoletos();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("Los nuevos destinos se cargarán al volver a abrir el menú para reservar pasajes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void btnMasAsientos_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());

                if (viaje != null)
                {
                    if (cbHoraSalidaIda.SelectedItem != null)
                    {
                        int index = -1;
                        int length = horario_valores.GetUpperBound(0) + 1;

                        for (int i = 0; i < length; i++)
                        {
                            if (horario_valores[i, 1] == cbHoraSalidaIda.SelectedItem.ToString())
                            {
                                index = i;
                            }
                        }

                        if (index != -1)
                        {
                            Horario horario = viaje.Horarios.Find(h => h.Hora == horario_valores[index, 0]);
                            if (horario != null)
                            {

                                frmAsientosSelect form = new frmAsientosSelect(horario.Distribucion, viaje, dtpFechaIda.Value.Date, horario.Hora.ToString(), cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString());
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    if (form.butaca > 0)
                                    {
                                        tbAsientoIda.Text = ((int)form.butaca).ToString();
                                    }
                                }
                            }
                            else MessageBox.Show("Error inesperado: No se encontro el horario especificado.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("Error inesperado: Horario inválido.", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("No hay ningún horario seleccionado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("No hay ningún viaje seleccionado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMasPasajeros_Click(object sender, EventArgs e)
        {
            frmPasaje form = new frmPasaje();
            if (form.ShowDialog() == DialogResult.OK)
            {
                cbPasNombre.Text = form.dgvPasajeros.CurrentRow.Cells["Nombre"].Value.ToString();
                cbPasDNI.Text = form.dgvPasajeros.CurrentRow.Cells["DNI"].Value.ToString();
            }
            RecargarBoletos();
            ActualizarListaPasajeros();
        }
        private void btnVender_Click_1(object sender, EventArgs e)
        {
            if (cbPasNombre.Text != string.Empty)
            {
                if (cbPasDNI.Text != string.Empty)
                {
                    if (cbOrigen.SelectedItem.ToString() != string.Empty && cbDestino.SelectedItem.ToString() != string.Empty)
                    {
                        if (cbOrigen.Enabled && cbDestino.Enabled)
                        {
                            if (cbHoraSalidaIda.SelectedItem.ToString() != string.Empty)
                            {
                                if (tbAsientoIda.Text != string.Empty)
                                {
                                    try
                                    {
                                        using (EntityDataModel db = new EntityDataModel())
                                        {
                                            Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());
                                            DateTime fecha_server = GetDBDateNow(db);

                                            if (viaje != null)
                                            {
                                                Destino origen = GetDBDestino(db, cbOrigen.SelectedItem.ToString());
                                                Destino destino = GetDBDestino(db, cbDestino.SelectedItem.ToString());
                                                Cliente cliente = db.Clientes.Where(c => c.Nombre == cbPasNombre.Text && c.DNI.ToString() == cbPasDNI.Text).FirstOrDefault();
                                                if (cliente != null)
                                                {
                                                    int asiento = Convert.ToInt32(tbAsientoIda.Text);
                                                    DateTime fecha = dtpFechaIda.Value;
                                                    string hora_llegada = dtpHoraLlegadaIda.Value.ToShortTimeString();
                                                    var boleto_comprobacion = db.Boletos.Where(b => b.Recorrido.Nombre == viaje.Nombre && b.Asiento == asiento && b.Fecha == fecha && b.HoraSalida == cbHoraSalidaIda.SelectedItem.ToString() && b.HoraLlegada == hora_llegada).ToList();

                                                    if (boleto_comprobacion.Count <= 0)
                                                    {
                                                        Cuenta cuentaUso = frmDestinos.GetDBCuenta(db, cuenta_id);
                                                        if (cuentaUso != null)
                                                        {
                                                            DateTime tiempo = ObtenerTiempo(viaje, origen.Nombre, destino.Nombre);
                                                            Boleto b = new Boleto(viaje, origen, destino, cliente, Convert.ToInt32(tbAsientoIda.Text), dtpFechaIda.Value.Date, ObtenerPrecio(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString()).ToString(), viaje.Horarios[cbHoraSalidaIda.SelectedIndex].Hora.ToString(), cbHoraSalidaIda.SelectedItem.ToString(), dtpHoraLlegadaIda.Value.ToShortTimeString(), cuentaUso);
                                                            db.Boletos.Add(b);
                                                            db.SaveChanges();
                                                            cbPasNombre.Text = string.Empty;
                                                            cbPasDNI.Text = string.Empty;
                                                            dtpFechaIda.Value = fecha_server;

                                                            frmMetodoDePago frm = new frmMetodoDePago(ObtenerPrecio(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString()), b);
                                                            if (frm.ShowDialog() == DialogResult.OK)
                                                            {
                                                                if (frm.pago != null)
                                                                {
                                                                    b.Estado = "VENDIDO";
                                                                    db.Pagos.Add(frm.pago);
                                                                    b.Pago = frm.pago;
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            RecargarBoletos();

                                                            //MessageBox.Show("Boleto creado correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                        else MessageBox.Show("Hubo un error al intentar encontrar tu cuenta. Probablemente fue eliminada.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                    else MessageBox.Show("Ya hay un boleto con esa información.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else MessageBox.Show("Ese pasajero no se encuentra registrado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else MessageBox.Show("No hay recorridos seleccionados.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    catch (NullReferenceException)
                                    {

                                    }
                                }
                                else MessageBox.Show("No se ha seleccionado una butaca.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else MessageBox.Show("No hay un horario de salida seleccionado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("No se puede vender boletos para ese día.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("No se han completados los datos de origen y destino.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("No se puede vender boletos con algunos campos vacíos." + Environment.NewLine + "Campos requeridos:" + Environment.NewLine + "* Nombre" + Environment.NewLine + "*DNI", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("No se puede vender boletos con algunos campos vacíos." + Environment.NewLine + "Campos requeridos:" + Environment.NewLine + "* Nombre", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void cbOrigen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ShowWaitDialog(new Action(RecargarDestinos), "Actualizando lista de destinos.. por favor espere.");
        }

        private void RecargarDestinos()
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;

                if (cbTrayecto.SelectedIndex >= 0)
                {
                    using (EntityDataModel db = new EntityDataModel())
                    {
                        Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());
                        if (viaje != null)
                        {
                            frmLoading loading = new frmLoading();

                            List<string> siguientes = new List<string>();
                            MostrarSiguientes(viaje, siguientes, cbOrigen.SelectedItem.ToString(), GetViajeDestinoNombre(viaje));
                            cbDestino.Enabled = false;
                            cbDestino.Items.Clear();
                            foreach (var s in siguientes)
                            {
                                cbDestino.Items.Add(s);
                            }
                            cbDestino.Items.Add(GetViajeDestinoNombre(viaje));
                            cbDestino.Enabled = true;

                            //DateTime tiempo_llegada = ObtenerTiempo(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString());

                            RecargarHorarios();
                            tbAsientoIda.Text = string.Empty;

                            if (cbDestino.Items.Count > 0) cbDestino.SelectedIndex = 0;

                            //loading.Close();

                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No hay un recorridos registrados.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTrayecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTrayecto.SelectedIndex >= 0)
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());
                    try
                    {
                        if (viaje != null)
                        {
                            RecargarHorarios();
                            RecargarBoletos();
                            cbOrigen.Enabled = false;
                            cbDestino.Enabled = false;

                            if (cbHoraSalidaIda.Items.Count > 0) cbHoraSalidaIda.SelectedIndex = 0;
                            cbOrigen.Items.Clear();
                            cbDestino.Items.Clear();
                            if (viaje.Arcos.Count > 0) foreach (var a in viaje.Arcos) { cbOrigen.Items.Add(a.Origen.Nombre); cbDestino.Items.Add(a.Origen.Nombre); }
                            cbOrigen.Enabled = true;
                            cbDestino.Enabled = true;

                            if (cbOrigen.Items.Count > 0) cbOrigen.SelectedIndex = cbOrigen.Items.IndexOf(GetViajeOrigenNombre(viaje));
                            if (cbDestino.Items.Count > 0) cbDestino.SelectedIndex = cbDestino.Items.IndexOf(GetViajeDestinoNombre(viaje));
                            
                            
                            dtpFechaIda.Value = GetDBDateNow(db);
                        }
                        else
                        {
                            MessageBox.Show("No hay recorridos registrados.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (NullReferenceException)
                    {

                    }
                }
            }
        }
        private void cbDestino_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());
                    if (viaje != null)
                    {
                        DateTime tiempo = ObtenerTiempo(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString());
                        DateTime hora_ad = DateTime.Parse(cbHoraSalidaIda.SelectedItem.ToString());

                        hora_ad = DateTime.Parse(hora_ad.Add(new TimeSpan(tiempo.Hour, tiempo.Minute, 0)).ToShortTimeString());

                        dtpHoraLlegadaIda.Value = hora_ad;

                        tbAsientoIda.Text = string.Empty;

                        lblPrecio.Text = "Precio: $" + ObtenerPrecio(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString());
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
        }
        private void cbHoraSalidaIda_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());
                if (viaje != null)
                {
                    try
                    {
                        DateTime tiempo = ObtenerTiempo(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString());
                        DateTime hora_ad = DateTime.Parse(cbHoraSalidaIda.SelectedItem.ToString());

                        hora_ad = DateTime.Parse(hora_ad.Add(new TimeSpan(tiempo.Hour, tiempo.Minute, 0)).ToShortTimeString());

                        dtpHoraLlegadaIda.Value = hora_ad;

                        tbAsientoIda.Text = string.Empty;
                    }
                    catch (NullReferenceException)
                    {

                    }
                }
            }
        }
        private void dtpFechaIda_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTrayecto.SelectedItem != null)
                {
                    RecargarHorarios();
                }
            }
            catch (NullReferenceException)
            {

            }
        }



        private void rbFiltroTodos_CheckedChanged(object sender, EventArgs e)
        {
            RecargarBoletos();
        }
        private void rbFiltrosDiaHoy_CheckedChanged(object sender, EventArgs e)
        {
            pagina = 1;
            RecargarBoletos();
        }
        private void rbFiltrosPendientes_CheckedChanged(object sender, EventArgs e)
        {
            pagina = 1;
            RecargarBoletos();
        }
        private void rbFiltrosVendidos_CheckedChanged(object sender, EventArgs e)
        {
            pagina = 1;
            RecargarBoletos();
        }
        private void rbFiltrosRecorrido_CheckedChanged(object sender, EventArgs e)
        {
            pagina = 1;
            RecargarBoletos();
        }
        private void rbFiltrosExpirados_CheckedChanged(object sender, EventArgs e)
        {
            pagina = 1;
            RecargarBoletos();
        }
        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvBoletos.SelectedRows)
                {
                    if (row.Cells["Estado"].Value.ToString() != "VENDIDO")
                    {
                        if (row.Cells["Estado"].Value.ToString() != "EXPIRADO" && row.Cells["Estado"].Value.ToString() != "CANCELADO")
                        {
                            using (EntityDataModel db = new EntityDataModel())
                            {
                                int id = Convert.ToInt32(row.Cells["ID"].Value);
                                Boleto boleto = GetDBBoleto(db, id);
                                Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());
                                Cuenta cuentaUso = frmDestinos.GetDBCuenta(db, cuenta_id);
                                if (viaje != null)
                                {
                                    if (boleto != null)
                                    {
                                        if (cuentaUso != null)
                                        {
                                            if (boleto.Vendedor.Id == cuentaUso.Id)
                                            {
                                                frmMetodoDePago frm = new frmMetodoDePago(ObtenerPrecio(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString()), boleto);
                                                if (frm.ShowDialog() == DialogResult.OK)
                                                {
                                                    if (frm.pago != null)
                                                    {
                                                        boleto.Estado = "VENDIDO";
                                                        db.Pagos.Add(frm.pago);
                                                        boleto.Pago = frm.pago;
                                                        boleto.Pago.Boleto = boleto.ID;
                                                        db.SaveChanges();
                                                        RecargarBoletos();
                                                    }
                                                }
                                            }
                                            else MessageBox.Show("Sólo la boleteria que realizó este boleto puede venderlo.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            break;
                                        }
                                        else MessageBox.Show("Hubo un error al intentar encontrar tu cuenta. Probablemente fue eliminada.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else MessageBox.Show("Error interno.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else MessageBox.Show("No se ha seleccionado ningún recorrido.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else MessageBox.Show("Este boleto ya está expirado o fue cancelado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Ese boleto ya está vendido.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Ocurrió un error inesperado." + Environment.NewLine + "Detalles del error: " + ex.Message, "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvBoletos.SelectedRows)
            {
                if (row.Cells["Estado"].Value.ToString() != "CANCELADO")
                {
                    if (row.Cells["Estado"].Value.ToString() != "EXPIRADO")
                    {
                        if (MessageBox.Show("¿Estás seguro de cancelar este boleto?" + Environment.NewLine + "Tendrás que esperar un tiempo para volver a habilitarlo.", "Dar de baja un boleto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (EntityDataModel db = new EntityDataModel())
                            {
                                int id = Convert.ToInt32(row.Cells["ID"].Value);
                                Boleto boleto = GetDBBoleto(db, id);
                                Cuenta cuentaUso = frmDestinos.GetDBCuenta(db, cuenta_id);
                                if (boleto != null)
                                {
                                    if (cuentaUso != null)
                                    {
                                        if (boleto.Vendedor.Id == cuentaUso.Id || cuentaUso.Tipo == "admin")
                                        {
                                            boleto.Estado = "CANCELADO";
                                            db.SaveChanges();
                                            RecargarBoletos();
                                            MessageBox.Show("El boleto fue cancelado correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            break;
                                        }
                                        else MessageBox.Show("Sólo el que realizó este boleto puede cancelarlo.");
                                    }
                                    else MessageBox.Show("Ocurrió un error al intentar encontrar tu cuenta. Probablemente haya sido eliminada.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else MessageBox.Show("Error interno.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else MessageBox.Show("Este boleto ya expiró.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Ese boleto ya está cancelado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnBuscarPasajeros_Click(object sender, EventArgs e)
        {
            BuscarPasajeros();
        }
        private void cbPasNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarPasajeros();
            }
        }
        private void cbPasDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarPasajeros();
            }
        }
        private void cbPasDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void cbViajeTrayecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDataGridView();
            using (EntityDataModel db = new EntityDataModel())
            {
                Viaje v = GetDBViaje(db, cbViajeTrayecto.SelectedItem.ToString());
                try
                {
                    if (v != null)
                    {
                        cbViajeHoraSalida.Items.Clear();
                        foreach (Horario h in v.Horarios)
                        {
                            if (h.Hora != string.Empty)
                            {
                                cbViajeHoraSalida.Items.Add(h.Hora);
                            }
                        }
                    }
                    if (cbViajeHoraSalida.Items.Count > 0) cbViajeHoraSalida.SelectedIndex = 0;
                    rbPB.Checked = true;
                }
                catch (NullReferenceException)
                {

                }
            }
        }
        private void cbViajeHoraSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                Viaje viaje = GetDBViaje(db, cbViajeTrayecto.SelectedItem.ToString());
                if (viaje != null)
                {
                    Horario h = viaje.Horarios.Find(horario => horario.Hora == cbViajeHoraSalida.SelectedItem.ToString());
                    if (h != null)
                    {
                        for (int i = 0; i < clbViajeFrecuencia.Items.Count; i++)
                        {
                            if (h.Frecuencia.Cells[i].Value == 1) clbViajeFrecuencia.SetItemCheckState(i, CheckState.Checked);
                            else clbViajeFrecuencia.SetItemCheckState(i, CheckState.Unchecked);
                        }
                        DrawDistribution(h.Distribucion);
                        RecargarDataGridView();
                    }
                }
            }
        }
        private void rbViajesHorarios_CheckedChanged(object sender, EventArgs e)
        {
            pnlViajeHorariosTodos.Visible = true;
            ActualizarDataGridView();
            RecargarDataGridView();
        }
        private void rbViajesPrecios_CheckedChanged(object sender, EventArgs e)
        {
            pnlViajeHorariosTodos.Visible = false;
            ActualizarDataGridView();
            RecargarDataGridView();
        }
        private void rbPB_CheckedChanged(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                Viaje viaje = GetDBViaje(db, cbViajeTrayecto.SelectedItem.ToString());
                if (viaje != null)
                {
                    Horario h = viaje.Horarios.Find(horario => horario.Hora == cbViajeHoraSalida.SelectedItem.ToString());
                    if (h != null)
                    {
                        DrawDistribution(h.Distribucion);
                    }
                }
            }
        }
        private void rbPA_CheckedChanged(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                Viaje viaje = GetDBViaje(db, cbViajeTrayecto.SelectedItem.ToString());
                if (viaje != null)
                {
                    Horario h = viaje.Horarios.Find(horario => horario.Hora == cbViajeHoraSalida.SelectedItem.ToString());
                    if (h != null)
                    {
                        DrawDistribution(h.Distribucion);
                    }
                }
            }
        }


        /*
        private void AgregarArcosR(Viaje viaje, List<string> listaR, string destino, string destino_final)
        {
            if (!listaR.Contains(destino)) listaR.Add(destino);
            foreach (Arco a in viaje.Arcos)
            {
                if (a.Origen != null && a.Origen.Nombre != destino_final)
                {
                    AgregarArcosR(viaje, listaR, a.Origen.Nombre, destino_final);
                }
                if (a.Origen.Nombre == destino_final) listaR.Add(destino_final);
                break;
            }
        }
        */
        public static string GetViajeOrigenNombre(Viaje viaje)
        {
            foreach(Arco a in viaje.Arcos)
            {
                if(viaje.Arcos.Find(ar => ar.Destino == a.Origen) == null)
                    return a.Origen.Nombre;   
            }
            return string.Empty;
        }

        public static string GetViajeDestinoNombre(Viaje viaje)
        {
            foreach(Arco a in viaje.Arcos)
            {
                if (viaje.Arcos.Find(ar => ar.Origen == a.Destino) == null)
                    return a.Destino.Nombre;

            }
            return string.Empty;
        }

        public static void MostrarSiguientes(Viaje viaje, List<string> list, string origen, string destino)
        {
            if(viaje != null && origen != destino)
            MostrarSiguientesR(viaje, list, origen, destino);
        }
        static internal void MostrarSiguientesR(Viaje viaje, List<string> list, string origen, string destino)
        {
            Arco arco = viaje.Arcos.Find(a => a.Origen.Nombre == origen);
            if(arco != null)
            {
                if(arco.Destino.Nombre != destino)
                {
                    list.Add(arco.Destino.Nombre);
                    MostrarSiguientesR(viaje, list, arco.Destino.Nombre, destino);
                }
            }
        }
        public static int ObtenerPrecio(Viaje viaje, string origen, string destino)
        {
            int precio = 0;
            List<int> precios = new List<int>();
            if (viaje != null) ObtenerPrecioR(viaje, precios, origen, destino);
            foreach (int var in precios)
            {
                precio += var;
            }
            return precio;
        }
        static internal void ObtenerPrecioR(Viaje viaje, List<int> precio, string origen, string destino)
        {
            Arco arco = viaje.Arcos.Find(a => a.Origen.Nombre == origen);
            if(arco != null)
            {
                if(arco.Destino.Nombre != destino)
                {
                    precio.Add(Convert.ToInt32(arco.Precio));
                    ObtenerPrecioR(viaje, precio, arco.Destino.Nombre, destino);
                }
                else precio.Add(Convert.ToInt32(arco.Precio));
            }
        }
        public static DateTime ObtenerTiempo(Viaje viaje, string origen, string destino)
        {
            DateTime dt = DateTime.MinValue;
            if (origen != destino)
            {
                List<string> list = new List<string>();
                if (viaje != null) ObtenerTiempoR(viaje, list, origen, destino);

                foreach (var a in list)
                {
                    string[] tiempo = a.Split(':');
                    int hora = Convert.ToInt32(tiempo[0]);
                    int minuto = Convert.ToInt32(tiempo[1]);
                    dt = DateTime.Parse(dt.Add(new TimeSpan(hora, minuto, 0)).ToShortTimeString());
                }
            }
            return dt;
        }
        static internal void ObtenerTiempoR(Viaje viaje, List<string> list, string origen, string destino)
        {
            Arco arco = viaje.Arcos.Find(a => a.Origen.Nombre == origen);
            if (arco != null)
            {
                if (arco.Destino.Nombre != destino)
                {
                    list.Add(arco.Demora);
                    ObtenerTiempoR(viaje, list, arco.Destino.Nombre, destino);
                }
                else list.Add(arco.Demora);
            }
        }

        private void RecargarViajes()
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            using (EntityDataModel db = new EntityDataModel())
            {
                cbTrayecto.Items.Clear();
                cbViajeTrayecto.Items.Clear();
                cbInformeTrayecto.Items.Clear();

                if (db.Viajes.Count() > 0)
                {
                    cbTrayecto.Items.AddRange((from v in db.Viajes select v.Nombre).ToArray());
                    if (cbTrayecto.SelectedIndex < 0) cbTrayecto.SelectedIndex = 0;
                    cbViajeTrayecto.Items.AddRange((from v in db.Viajes select v.Nombre).ToArray());
                    if (cbViajeTrayecto.SelectedIndex < 0) cbViajeTrayecto.SelectedIndex = 0;
                    cbInformeTrayecto.Items.AddRange((from v in db.Viajes select v.Nombre).ToArray());
                    if (cbInformeTrayecto.SelectedIndex < 0) cbInformeTrayecto.SelectedIndex = 0;
                }
                Cuenta cuentaUso = frmDestinos.GetDBCuenta(db, cuenta_id);
                if (cuentaUso != null)
                {
                    lblInfo.Text = "Cuenta: " + cuentaUso.Usuario + " | Cuentas: " + db.Cuentas.Count() + " | Trayectos: " + db.Viajes.Count() + " | Boletos: " + db.Boletos.Count() + " | Pagos: " + db.Pagos.Count();

                }
                else
                    MessageBox.Show("Un error ocurrió mientras se intentaba buscar la cuenta asociada." + Environment.NewLine + "Probablemente fue eliminada.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowWaitDialog(Action codeToRun, string title)
        {
            ManualResetEvent dialogLoadedFlag = new ManualResetEvent(false);

            (new Thread(() =>
            {
                Form waitDialog = new Form()
                {
                    Name = "LoadingForm",
                    Text = title,
                    ControlBox = false,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterParent,
                    Width = 300,
                    Height = 50,
                    Enabled = true
                };

                ProgressBar ScrollingBar = new ProgressBar()
                {
                    Style = ProgressBarStyle.Marquee,
                    Parent = waitDialog,
                    Dock = DockStyle.Fill,
                    Enabled = true
                };

                waitDialog.Load += new EventHandler((x, y) =>
                {
                    dialogLoadedFlag.Set();
                });

                waitDialog.Shown += new EventHandler((x, y) =>
                {
                    (new Thread(() =>
                    {
                        codeToRun();
                        this.Invoke((MethodInvoker)(() => waitDialog.Close()));
                    })).Start();
                });

                this.Invoke((MethodInvoker)(() => waitDialog.ShowDialog(this)));
            })).Start();

            while (dialogLoadedFlag.WaitOne(100, true) == false)
                Application.DoEvents(); // note: this will block the main thread once the wait dialog shows
        }



        private int GetDayOfWeekIndex(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return 0;
                case DayOfWeek.Tuesday: return 1;
                case DayOfWeek.Wednesday: return 2;
                case DayOfWeek.Thursday: return 3;
                case DayOfWeek.Friday: return 4;
                case DayOfWeek.Saturday: return 5;
                case DayOfWeek.Sunday: return 6;
                default: return -1;
            }
        }
        private void ActualizarInformacion()
        {
            using (EntityDataModel db = new EntityDataModel())
            {                
                try
                {
                    Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());
                    if (viaje != null)
                    {
                        DateTime tiempo = ObtenerTiempo(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString());
                        DateTime hora_ad = DateTime.Parse(cbHoraSalidaIda.SelectedItem.ToString());

                        hora_ad = DateTime.Parse(hora_ad.Add(new TimeSpan(tiempo.Hour, tiempo.Minute, 0)).ToShortTimeString());

                        dtpHoraLlegadaIda.Value = hora_ad;

                        tbAsientoIda.Text = string.Empty;

                        lblPrecio.Text = "Precio: $" + ObtenerPrecio(viaje, cbOrigen.SelectedItem.ToString(), cbDestino.SelectedItem.ToString());
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }
        private void ActualizarListaPasajeros()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                cbPasNombre.AutoCompleteCustomSource.Clear();
                cbPasDNI.AutoCompleteCustomSource.Clear();
                cbInformePasajero.AutoCompleteCustomSource.Clear();

                if(db.Clientes.Count() > 0)
                {
                    cbPasNombre.AutoCompleteCustomSource.AddRange((from c in db.Clientes select c.Nombre).ToArray());
                    cbPasDNI.AutoCompleteCustomSource.AddRange((from c in db.Clientes select c.DNI.ToString()).ToArray());
                    cbInformePasajero.AutoCompleteCustomSource.AddRange((from c in db.Clientes select c.Nombre).ToArray());
                }
            }
        }
        private void ActualizarDataGridView()
        {
            dgvViajeTrayectos.Rows.Clear();
            dgvViajeTrayectos.Columns.Clear();
            using (EntityDataModel db = new EntityDataModel())
            {

                Viaje viaje = GetDBViaje(db, cbViajeTrayecto.SelectedItem.ToString());
                try
                {
                    if (viaje != null)
                    {
                        if (viaje.Arcos.Count > 0)
                        {
                            List<string> lista = new List<string>();

                            MostrarSiguientes(viaje, lista, GetViajeOrigenNombre(viaje), GetViajeDestinoNombre(viaje));
                            dgvViajeTrayectos.Columns.Add("clmX", "X");
                            dgvViajeTrayectos.Columns.Add("clm" + GetViajeOrigenNombre(viaje), GetViajeOrigenNombre(viaje));
                            if (rbViajesPrecios.Checked)
                            {
                                dgvViajeTrayectos.Rows.Add(GetViajeOrigenNombre(viaje));
                                foreach (string nombre in lista)
                                {
                                    dgvViajeTrayectos.Columns.Add("clm" + nombre, nombre);
                                    dgvViajeTrayectos.Rows.Add(nombre);
                                }
                                dgvViajeTrayectos.Columns.Add("clm" + GetViajeDestinoNombre(viaje), GetViajeDestinoNombre(viaje));
                            }
                            else if (rbViajesHorarios.Checked)
                            {
                                if (!cbViajesHorariosTodos.Checked)
                                {
                                    dgvViajeTrayectos.Rows.Add(GetViajeOrigenNombre(viaje));
                                    cbViajeHoraSalida.Enabled = true;
                                }
                                else
                                {
                                    for (int i = 0; i < viaje.Horarios.Count; i++)
                                    {
                                        dgvViajeTrayectos.Rows.Add(GetViajeOrigenNombre(viaje));
                                    }
                                    cbViajeHoraSalida.Enabled = false;
                                }
                                foreach (string nombre in lista)
                                {
                                    dgvViajeTrayectos.Columns.Add("clm" + nombre, nombre);
                                }
                                dgvViajeTrayectos.Columns.Add("clm" + GetViajeDestinoNombre(viaje), GetViajeDestinoNombre(viaje));
                            }
                        }
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }
        private void RecargarDataGridView()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                Viaje viaje = GetDBViaje(db, cbViajeTrayecto.SelectedItem.ToString());
                if (viaje != null)
                {
                    if (rbViajesPrecios.Checked)
                    {
                        foreach (DataGridViewRow row in dgvViajeTrayectos.Rows)
                        {
                            for (int i = 0; i < dgvViajeTrayectos.Columns.Count; i++)
                            {
                                if (i > 0)
                                {
                                    if (cbViajeHoraSalida.SelectedItem != null)
                                    {
                                        int valor = ObtenerPrecio(viaje, row.Cells[0].Value.ToString(), dgvViajeTrayectos.Columns[row.Cells[i].ColumnIndex].HeaderText);

                                        List<string> siguientes = new List<string>();
                                        siguientes.Clear();

                                        MostrarSiguientes(viaje, siguientes, row.Cells[0].Value.ToString(), GetViajeDestinoNombre(viaje));
                                        siguientes.Add(GetViajeDestinoNombre(viaje));
                                        if (siguientes.Contains(dgvViajeTrayectos.Columns[row.Cells[i].ColumnIndex].HeaderText))
                                        {
                                            if (valor != 0)
                                            {
                                                row.Cells[i].Value = "$" + valor;
                                            }
                                            else row.Cells[i].Value = " - ";
                                        }
                                        else row.Cells[i].Value = " - ";
                                    }
                                }
                            }
                        }
                    }
                    else if (rbViajesHorarios.Checked)
                    {
                        if (!cbViajesHorariosTodos.Checked)
                        {
                            foreach (DataGridViewRow row in dgvViajeTrayectos.Rows)
                            {
                                for (int i = 0; i < dgvViajeTrayectos.Columns.Count; i++)
                                {
                                    if (i > 0)
                                    {
                                        DateTime horarios = DateTime.Parse(cbViajeHoraSalida.SelectedItem.ToString());
                                        DateTime tiempo = ObtenerTiempo(viaje, row.Cells[0].Value.ToString(), dgvViajeTrayectos.Columns[row.Cells[i].ColumnIndex].HeaderText);
                                        horarios = DateTime.Parse(horarios.Add(new TimeSpan(tiempo.Hour, tiempo.Minute, 0)).ToShortTimeString());
                                        string valor = horarios.ToShortTimeString();
                                        row.Cells[i].Value = valor;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int r = 0; r < dgvViajeTrayectos.Rows.Count; r++)
                            {
                                for (int c = 0; c < dgvViajeTrayectos.Columns.Count; c++)
                                {
                                    if (c > 0)
                                    {
                                        DateTime horarios = DateTime.Parse(viaje.Horarios[r].Hora);
                                        DateTime tiempo = ObtenerTiempo(viaje, dgvViajeTrayectos.Rows[r].Cells[0].Value.ToString(), dgvViajeTrayectos.Columns[dgvViajeTrayectos.Rows[r].Cells[c].ColumnIndex].HeaderText);
                                        horarios = DateTime.Parse(horarios.Add(new TimeSpan(tiempo.Hour, tiempo.Minute, 0)).ToShortTimeString());
                                        string valor = horarios.ToShortTimeString();
                                        dgvViajeTrayectos.Rows[r].Cells[c].Value = valor;
                                    }
                                }
                            }
                        }
                    }
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
        private void DrawDistribution(Distribucion distribucion)
        {
            const int ESPACIO_NULL = -1;
            const int ESPACIO_PASILLO = 1;
            const int ESPACIO_BUTACA = 2;
            const int ESPACIO_TV = 3;

            if (rbPB.Checked)
            {
                dgvAsientos.Rows.Clear();
                if (!EsDoblePiso(distribucion)) rbPA.Enabled = false;
                else rbPA.Enabled = true;

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
                ContarAsientos(distribucion);

            }
            else if (rbPA.Checked)
            {
                dgvAsientos.Rows.Clear();
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
                ContarAsientos(distribucion);
            }
        }
        private void ContarAsientos(Distribucion distribucion)
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
        private void RecargarBoletos()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            ActualizarFiltros();
        }

        private void DibujarBoletoDataGridView(Boleto b)        
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    DateTime fecha_server = GetDBDateNow(db);

                    DateTime fecha = Convert.ToDateTime(b.Fecha);
                    DateTime fecha_emision = Convert.ToDateTime(b.FechaEmision);

                    if (fecha_server.Day > fecha.Day && fecha_server.Month >= fecha.Month || fecha.Year > fecha_server.Year)
                    {
                        b.Estado = "EXPIRADO";
                        Boleto boleto_db = db.Boletos.Where(bol => bol.ID == b.ID).First();
                        boleto_db.Estado = "EXPIRADO";
                        db.SaveChanges();
                    }

                    string pago;
                    string pasajero;
                    if (b.Pago == null) pago = "Ninguno";
                    else pago = b.Pago.Tipo;
                    if (b.Pasajero == null) pasajero = "Nadie";
                    else pasajero = b.Pasajero.Nombre;

                    int index = dgvBoletos.Rows.Add(b.ID, b.Recorrido.Nombre, pasajero, b.Vendedor.Usuario, b.FechaEmision, b.Origen.Nombre, b.Destino.Nombre, b.Fecha.ToShortDateString(), b.HoraSalidaAdicional, b.Asiento, b.Estado, pago);
                    DataGridViewRow row = dgvBoletos.Rows[index];
                    switch (row.Cells["Estado"].Value.ToString())
                    {
                        case "PENDIENTE":
                            row.DefaultCellStyle.BackColor = Color.Gold;
                            break;
                        case "VENDIDO":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "EXPIRADO":
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            break;
                        case "CANCELADO":
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            break;
                    }

                }
            }
            catch(NullReferenceException)
            {

            }
            catch(ArgumentNullException)
            {

            }
            catch(ArgumentException)
            {

            }
        }

        private void BuscarPasajeros()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                if (cbPasNombre.Focused)
                {
                    Cliente c = GetDBCliente(db, cbPasNombre.Text);
                    if (c != null)
                    {
                        cbPasNombre.Text = c.Nombre;
                        cbPasDNI.Text = c.DNI.ToString();
                    }
                    else MessageBox.Show("No se encontró ningún pasajero.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (cbPasDNI.Focused)
                {
                    try
                    {
                        Cliente c = GetDBCliente(db, Convert.ToInt32(cbPasDNI.Text));
                        if (c != null)
                        {
                            cbPasNombre.Text = c.Nombre;
                            cbPasDNI.Text = c.DNI.ToString();
                        }
                    }
                    catch(ArgumentException)
                    {
                        MessageBox.Show("El documento del pasajero debe tener únicamente números.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void DisableControls()
        {
            cbOrigen.Enabled = false;
            cbDestino.Enabled = false;
            lblOrigen.Enabled = false;
            lblDestino.Enabled = false;
            lblAsientoIda.Enabled = false;
            btnMasAsientosIda.Enabled = false;
            btnVender.Enabled = false;
            lblHoraSalidaIda.Enabled = false;
            //cbHoraSalidaIda.Enabled = false;
            lblHoraLlegadaIda.Enabled = false;
            dtpHoraLlegadaIda.Value = Convert.ToDateTime("00:00:00");

            ttInfo.UseAnimation = true;
            ttInfo.SetToolTip(gbIda, "No se pueden vender pasajes ese día.");
           
            foreach(Control c in gbIda.Controls)
            {
                ttInfo.SetToolTip(c, "No se pueden vender pasajes ese día.");
                c.Cursor = Cursors.No;
            }
        }
        private void EnableControls()
        {
            cbOrigen.Enabled = true;
            cbDestino.Enabled = true;
            lblOrigen.Enabled = true;
            lblDestino.Enabled = true;
            lblAsientoIda.Enabled = true;
            btnMasAsientosIda.Enabled = true;
            btnVender.Enabled = true;
            lblHoraSalidaIda.Enabled = true;
            cbHoraSalidaIda.Enabled = true;
            lblHoraLlegadaIda.Enabled = true;

            ttInfo.SetToolTip(gbIda, "");
            foreach (Control c in gbIda.Controls)
            {
                ttInfo.SetToolTip(c, "");
                c.Cursor = Cursors.Arrow;
            }
        }

        private void RecargarHorarios()
        {
            try
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    Viaje viaje = GetDBViaje(db, cbTrayecto.SelectedItem.ToString());
                    if (viaje != null)
                    {
                        cbHoraSalidaIda.Items.Clear();

                        horario_valores = new string[viaje.Horarios.Count, 2];

                        foreach (Horario h in viaje.Horarios)
                        {
                            if (h.Hora != string.Empty)
                            {
                                if (viaje.Arcos.Count > 0)
                                {
                                    DayOfWeek dia = dtpFechaIda.Value.DayOfWeek;
                                    DateTime tiempo = ObtenerTiempo(viaje, GetViajeOrigenNombre(viaje), cbOrigen.SelectedItem.ToString());
                                    DateTime horarios = DateTime.MinValue;

                                    if (h.Frecuencia.Cells[GetDayOfWeekIndex(dia)].Value == 1)
                                    {
                                        horarios = DateTime.Parse(h.Hora);
                                        horarios = DateTime.Parse(horarios.Add(new TimeSpan(tiempo.Hour, tiempo.Minute, 0)).ToShortTimeString());

                                        cbHoraSalidaIda.Items.Add(horarios.ToShortTimeString());
                                        horario_valores[viaje.Horarios.IndexOf(h), 0] = h.Hora;
                                        horario_valores[viaje.Horarios.IndexOf(h), 1] = horarios.ToShortTimeString();
                                    }
                                }
                            }
                        }
                        if(cbHoraSalidaIda.SelectedItem == null)
                        {
                            if (cbHoraSalidaIda.Items.Count > 0) cbHoraSalidaIda.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
        }


        private void cbViajesHorariosTodos_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarDataGridView();
            RecargarDataGridView();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                Cuenta cuentaUso = frmDestinos.GetDBCuenta(db, cuenta_id);
                if (cuentaUso != null)
                {
                    frmCuenta form = new frmCuenta(cuentaUso.Id);
                    form.ShowDialog();
                }
                else MessageBox.Show("Se ha producido un error al intentar visualizar la cuenta, probablemente haya sido eliminada.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editorDeRecorridosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                frmDestinos form = new frmDestinos();
                if (form.ShowDialog() != DialogResult.None)
                {
                    try
                    {
                        ShowWaitDialog(new Action(RecargarViajes), "Actualizando recorridos.. porfavor espere");
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error inesperado: No se pudo recargar las modificaciones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void editorDePasajerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPasaje form = new frmPasaje();
            if(form.ShowDialog() != DialogResult.None)
            {
                ActualizarListaPasajeros();
            }
        }

        private void verInfoItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función no implementada.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tpPasajes_Click(object sender, EventArgs e)
        {

        }
        /*
        private void PasajerosFiltros_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is RadioButton && (sender as RadioButton).Checked)
                {
                    if ((sender as RadioButton).Tag != null)
                    {
                        cbBuscarPasajes.AutoCompleteCustomSource.Clear();
                        using (EntityDataModel db = new EntityDataModel())
                        {
                            var boletos = db.Boletos.ToList();
                            Boletos_LoadReferences(ref boletos, db);

                            switch ((sender as RadioButton).Tag.ToString())
                            {
                                case "pasajero":
                                    foreach (Boleto b in boletos) cbBuscarPasajes.AutoCompleteCustomSource.Add(b.Pasajero.Nombre);
                                    break;
                                case "dni":
                                    foreach (Boleto b in boletos) cbBuscarPasajes.AutoCompleteCustomSource.Add(b.Pasajero.DNI.ToString());
                                    break;
                                case "origen":
                                    foreach (Boleto b in boletos) cbBuscarPasajes.AutoCompleteCustomSource.Add(b.Origen.Nombre);
                                    break;
                                case "destino":
                                    foreach (Boleto b in boletos) cbBuscarPasajes.AutoCompleteCustomSource.Add(b.Destino.Nombre);
                                    break;
                                case "fecha":
                                    foreach (Boleto b in boletos) cbBuscarPasajes.AutoCompleteCustomSource.Add(b.Fecha.ToShortDateString());
                                    break;
                            }
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {

            }

        }
        */
        private void BuscarPasajes()
        {
            rbFiltroTodos.Checked = false;
            rbFiltroTodos.Checked = true;

        }

        private void cbPasNombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBuscarPasajes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarPasajes();
            }
        }

        private void apartadosAdministrativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(apartadosAdministrativosToolStripMenuItem.Checked)
            {

            }
            else
            {

            }
        }

        private void cbBuscarPasajes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMostrarTodo_CheckedChanged(object sender, EventArgs e)
        {
            //ShowWaitDialog(new Action(RefreshInfo), "Actualizando datos.. por favor espere.");
            /*
            if (cbMostrarTodo.Checked)
            {
                cbFilas.Enabled = false;
                lblNumeroFilas.Enabled = false;
            }
            else
            {
                cbFilas.Enabled = true;
                lblNumeroFilas.Enabled = true;
            }
            */
        }

        private void RefreshInfo()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            if (!actualizando)
            {
                actualizando = true;          
                ActualizarInformacion(1, 30);
                actualizando = false;
                
            }
        }


        private void cbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (force_reload)
                {
                    ActualizarFiltros();
                }
                else force_reload = true;
            }
            catch (NullReferenceException)
            {

            }
        }

        private void ActualizarInformacion(int start, int end)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                if (!boletos_dibujados.SequenceEqual(ObtenerBoletosFiltrados(db)))
                {
                    boletos_dibujados = ObtenerBoletosFiltrados(db);

                    dgvBoletos.Rows.Clear();

                    try
                    {
                        int paginas = CalcularPaginas();
                        var boletos = boletos_dibujados;
                        if (pagina > paginas || pagina <= 0) pagina = 1;

                        var inicio = (pagina-1) * filasPorPagina;
                        if (boletos_dibujados.Count > filasPorPagina)
                        {
                            boletos = boletos_dibujados.Skip(inicio)
                            .Take(filasPorPagina)
                            .ToList();
                        }
                        tbPagina.Text = "Pagina: " + pagina + "/" + paginas;
                        gbResultados.Text = "Resultados:  " + boletos_dibujados.Count + " encontrados.";

                        if (pagina > 1) btnAnterior.Enabled = true;
                        else if(pagina == 1)
                        {
                            btnAnterior.Enabled = false;
                            btnPrimero.Enabled = false;
                        }
                        if(pagina >= CalcularPaginas())
                        {
                            btnUltimo.Enabled = false;
                            btnSiguiente.Enabled = false;
                        }
                        else
                        {
                            btnUltimo.Enabled = true;
                            btnSiguiente.Enabled = true;
                        }

                        foreach (var boleto in boletos)
                        {
                            DibujarBoletoDataGridView(boleto);
                        }
                    }
                    catch (NullReferenceException)
                    {

                    }
                }
            }
        }

        private int CalcularPaginas()
        {
            decimal f_cant_paginas = Decimal.Divide(boletos_dibujados.Count, Convert.ToInt32(filasPorPagina));
            int t_cant_paginas = boletos_dibujados.Count / Convert.ToInt32(filasPorPagina);
            if (f_cant_paginas > t_cant_paginas)
            {
                t_cant_paginas++;
            }
            return t_cant_paginas;
        }

        private void ActualizarFiltros()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                if (!boletos_dibujados.Equals(ObtenerBoletosFiltrados(db)))
                {
                    ShowWaitDialog(new Action(RefreshInfo), "Actualizando datos.. por favor espere.");
                }
            }
        }

        private List<Boleto> ObtenerBoletosFiltrados(EntityDataModel db)
        {
            List<Boleto> boletos = new List<Boleto>();
            List<Boleto> source = null;

            if (rbFiltroTodos.Checked)
            {
                if(chbBusPasPasajeroNombre.Checked)
                {
                    if(cbPasBusPasajeroNombre.Text != string.Empty)
                    {
                        if (boletos.Count == 0) source = db.Boletos.ToList();
                        else source = boletos;
                        frmDestinos.Boletos_LoadReferences(ref source, db);
                        boletos = source.Where(b => b.Pasajero.Nombre == cbPasBusPasajeroNombre.Text).ToList();
                    }
                }
                if(chbBusPasPasajeroDNI.Checked)
                {
                    if (cbPasBusPasajeroDNI.Text != string.Empty)
                    {
                        if (boletos.Count == 0) source = db.Boletos.ToList();
                        else source = boletos;
                        frmDestinos.Boletos_LoadReferences(ref source, db);
                        try
                        {
                        int dni = Convert.ToInt32(cbPasBusPasajeroDNI.Text);
                        boletos = source.Where(b => b.Pasajero.DNI == dni).ToList();
                        }
                        catch(FormatException)
                        {
                            MessageBox.Show("No pudimos encontrar ese número de documento, ingresa uno válido.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if(chbBusPasOrigen.Checked)
                {
                    if(cbPasBusOrigen.Text != string.Empty)
                    {
                        if (boletos.Count == 0) source = db.Boletos.ToList();
                        else source = boletos;
                        frmDestinos.Boletos_LoadReferences(ref source, db);
                        boletos = source.Where(b => b.Origen.Nombre == cbPasBusOrigen.Text).ToList();
                    }
                }
                if(chbBusPasDestino.Checked)
                {
                    if(cbBusPasDestino.Text != string.Empty)
                    {
                        if (boletos.Count == 0) source = db.Boletos.ToList();
                        else source = boletos;
                        frmDestinos.Boletos_LoadReferences(ref source, db);
                        boletos = source.Where(b => b.Destino.Nombre == cbBusPasDestino.Text).ToList();
                    }
                }
                if(chbBusPasFecha.Checked)
                {
                    if (boletos.Count == 0) source = db.Boletos.ToList();
                    else source = boletos;
                    frmDestinos.Boletos_LoadReferences(ref source, db);
                    boletos = source.Where(b => b.Fecha.Day == dtpBusPasFecha.Value.Day && b.Fecha.Month == dtpBusPasFecha.Value.Month && b.Fecha.Year == dtpBusPasFecha.Value.Year).ToList();
                }

               /*
                if (cbBuscarPasajes.Text != string.Empty)
                {
                    foreach (Control c in gbBuscarPasaje.Controls)
                    {
                        if (c is RadioButton && (c as RadioButton).Checked)
                        {
                            if (c.Tag != null)
                            {
                                switch (c.Tag.ToString())
                                {
                                    case "pasajero":
                                        boletos = db.Boletos.Where(b => b.Pasajero.Nombre == cbBuscarPasajes.SelectedText).ToList();
                                        break;
                                    case "dni":
                                        boletos = db.Boletos.Where(b => b.Pasajero.DNI.ToString() == cbBuscarPasajes.SelectedText).ToList();
                                        break;
                                    case "origen":
                                        boletos = db.Boletos.Where(b => b.Origen.Nombre == cbBuscarPasajes.SelectedText).ToList();
                                        break;
                                    case "destino":
                                        boletos = db.Boletos.Where(b => b.Destino.Nombre == cbBuscarPasajes.SelectedText).ToList();
                                        break;
                                    case "fecha":
                                        try
                                        {
                                            DateTime fecha_boleto = DateTime.Parse(cbBuscarPasajes.SelectedText);

                                            boletos = db.Boletos.Where(b => b.Fecha.Year == fecha_boleto.Year && b.Fecha.Month == fecha_boleto.Month && b.Fecha.Day == fecha_boleto.Day).ToList();
                                        }
                                        catch (FormatException)
                                        {
                                            MessageBox.Show("La fecha introducida es inválida. " + Environment.NewLine + "Formato de fecha: DD/MM/AAAA. Ejemplo: 25/07/2000", "Error en la búsqueda.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        break;
                                }
                            }
                        }
                    }            
                }*/

            }
            else if (rbFiltrosRecorrido.Checked)
            {
                if(cbTrayecto.SelectedItem != null)
                {
                string recorrido = cbTrayecto.SelectedItem.ToString();
                boletos = db.Boletos.Where(b => b.Recorrido.Nombre == recorrido).OrderByDescending(b => b.ID).ToList();
                }
            }
            else if (rbFiltrosDiaHoy.Checked)
            {
                DateTime fecha_server = GetDBDateNow(db);
                boletos = db.Boletos.Where(b => b.FechaEmision.Year == fecha_server.Year && b.FechaEmision.Month == fecha_server.Month && b.FechaEmision.Day == fecha_server.Day).OrderByDescending(b => b.ID).ToList();
            }
            else if (rbFiltrosVendidos.Checked)
            {
                boletos = db.Boletos.Where(b => b.Estado == "VENDIDO").OrderByDescending(b => b.ID).ToList();
            }
            else if (rbFiltrosPendientes.Checked)
            {
                boletos = db.Boletos.Where(b => b.Estado == "PENDIENTE").OrderByDescending(b => b.ID).ToList();
            }
            else if (rbFiltrosExpirados.Checked)
            {
                boletos = db.Boletos.Where(b => b.Estado == "EXPIRADO").OrderByDescending(b => b.ID).ToList();
            }
            Boletos_LoadReferences(ref boletos, db);

            return boletos;
        }


        private void tcHoraServer_Load(object sender, EventArgs e)
        {

        }

        private void chbBusPasPasajeroNombre_CheckedChanged(object sender, EventArgs e)
        {
            if(chbBusPasPasajeroNombre.Checked)
            {
                cbPasBusPasajeroNombre.Enabled = true;
                using (EntityDataModel db = new EntityDataModel())
                {
                    cbPasBusPasajeroNombre.AutoCompleteCustomSource.Clear();
                    cbPasBusPasajeroNombre.AutoCompleteCustomSource.AddRange((from c in db.Clientes select c.Nombre).ToArray());
                }
            }
            else
            {
                cbPasBusPasajeroNombre.Text = string.Empty;
                cbPasBusPasajeroNombre.Enabled = false;
            }
        }

        private void chbBusPasPasajeroDNI_CheckedChanged(object sender, EventArgs e)
        {
            if(chbBusPasPasajeroDNI.Checked)
            {
                cbPasBusPasajeroDNI.Enabled = true;
                using (EntityDataModel db = new EntityDataModel())
                {
                cbPasBusPasajeroDNI.AutoCompleteCustomSource.Clear();
                cbPasBusPasajeroDNI.AutoCompleteCustomSource.AddRange((from c in db.Clientes select c.DNI.ToString()).ToArray());
                }
            }
            else
            {
                cbPasBusPasajeroDNI.Text = string.Empty;
                cbPasBusPasajeroDNI.Enabled = false;
            }
        }

        private void chbBusPasOrigen_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBusPasOrigen.Checked)
            {
                cbPasBusOrigen.Enabled = true;
                using (EntityDataModel db = new EntityDataModel())
                {
                    cbPasBusOrigen.AutoCompleteCustomSource.Clear();
                    cbPasBusOrigen.AutoCompleteCustomSource.AddRange((from d in db.Destinos select d.Nombre).ToArray());
                }
            }
            else
            {
                cbPasBusOrigen.Text = string.Empty;
                cbPasBusOrigen.Enabled = false;
            }
        }

        private void chbBusPasDestino_CheckedChanged(object sender, EventArgs e)
        {
            if(chbBusPasDestino.Checked)
            {
                cbBusPasDestino.Enabled = true;
                using (EntityDataModel db = new EntityDataModel())
                {
                    cbBusPasDestino.AutoCompleteCustomSource.Clear();
                    cbBusPasDestino.AutoCompleteCustomSource.AddRange((from d in db.Destinos select d.Nombre).ToArray());
                }
            }
            else
            {
                cbBusPasDestino.Text = string.Empty;
                cbBusPasDestino.Enabled = false;
            }
        }

        private void chbBusPasFecha_CheckedChanged(object sender, EventArgs e)
        {
            if(chbBusPasFecha.Checked)
            {
                dtpBusPasFecha.Enabled = true;
            }
            else
            {
                dtpBusPasFecha.Value = DateTime.Now;
                dtpBusPasFecha.Enabled = false;
            }
        }

        private void btnDistrCrear_Click(object sender, EventArgs e)
        {
            BuscarPasajes();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            pagina++;
            ActualizarFiltros();
            if(pagina >= CalcularPaginas())
            {
                btnSiguiente.Enabled = false;
                btnUltimo.Enabled = false;

                btnAnterior.Enabled = true;
                btnPrimero.Enabled = true;
            }
            else
            {
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            pagina--;
            if (pagina <= 1)
            {
                btnAnterior.Enabled = false;
                btnPrimero.Enabled = false;
                if(CalcularPaginas() > 1)
                {
                    btnSiguiente.Enabled = true;
                    btnUltimo.Enabled = true;
                }
            }
            else
            {
                btnPrimero.Enabled = true;
                btnPrimero.Enabled = true;
            }
            ActualizarFiltros();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            pagina = CalcularPaginas();
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;
            ActualizarFiltros();
            if(CalcularPaginas() > 1)
            {
                btnAnterior.Enabled = true;
                btnPrimero.Enabled = true;
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            pagina = 1;
            btnPrimero.Enabled = false;
            btnAnterior.Enabled = false;
            if(CalcularPaginas() > 1)
            {
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }
            ActualizarFiltros();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    if (rbInformeRecorrido.Checked)
                    {

                        Viaje viaje = GetDBViaje(db, cbInformeTrayecto.SelectedItem.ToString());
                        if (viaje != null)
                        {
                            frmReporteBoletos frmReporte = new frmReporteBoletos(viaje.Nombre);
                            frmReporte.ShowDialog();
                        }
                        else MessageBox.Show("Hubo un error al intentar recuperar el viaje desde la base de datos.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (rbInformePasajero.Checked)
                    {
                        Cliente cliente = GetDBCliente(db, cbInformePasajero.Text);
                        if (cliente != null)
                        {
                            frmReportePasajero frmReporte = new frmReportePasajero(cliente.Nombre);
                            frmReporte.ShowDialog();
                        }
                        else MessageBox.Show("No se encontró ese pasajero.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No se encontró información con esos datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tpReportes_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
