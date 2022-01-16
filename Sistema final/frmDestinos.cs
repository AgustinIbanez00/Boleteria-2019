using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Boleteria.Core.Models;
using Boleteria.Models;
using Geocoding;
using Geocoding.Google;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Boleteria
{
    public partial class FrmDestinos : Form
    {
        Distribucion distribucion;

        PointLatLng punto_temp = PointLatLng.Empty;
        const int ESTADO_EDITANDO_C = 2;
        const int ESTADO_EDITANDO = 3;

        GMarkerGoogle marker;
        readonly GMapOverlay markerOverlay = new("Marcador");
        readonly GMapOverlay mOverlayViaje = new("Viajes");
        readonly GMapOverlay mOverlayRutas = new("Rutas");

        int estado;
        int count_tick = 0;
        bool time_wait = false;
        IEnumerable<Address> addresses;

        public FrmDestinos()
        {
            InitializeComponent();
        }
        private void FrmDestinos_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = Program.Configuration["Google-Api-Key"];
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMPMapa.CacheLocation = @"cache";

            marker = new GMarkerGoogle(new PointLatLng(0, 0), GMarkerGoogleType.blue_small);

            gMPMapa.DragButton = MouseButtons.Left;
            gMPMapa.CanDragMap = true;
            gMPMapa.MapProvider = GMapProviders.GoogleMap;
            gMPMapa.MinZoom = 0;
            gMPMapa.MaxZoom = 24;
            gMPMapa.Zoom = 9;
            gMPMapa.AutoScroll = true;
            gMPMapa.ShowCenter = false;
            gMPMapa.SetPositionByKeywords("Argentina");
            gMPMapa.Overlays.Add(mOverlayRutas);
            gMPMapa.Overlays.Add(markerOverlay);
            gMPMapa.Overlays.Add(mOverlayViaje);
            

            RecargarDestinos();
            RecargarViajes();

            tbLugarNombre.Enabled = false;
            btnLugarUbicacion.Enabled = false;

            nudDistrCantidad.Value = nudDistrCantidad.Minimum + 5;

            distribucion = new Distribucion(30, 30);
            rbPB.Checked = true;
            DrawDistribution();

            RecargarDistribuciones();
            EnableRadioButtons();



        }
        private void BtnCrearD_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text != string.Empty)
            {
                //if (!punto.IsEmpty)
                //{
                using (EntityDataModel db = new EntityDataModel())
                {
                    if (GetDBDestino(db, tbNombre.Text) == null)
                    {
                        if(addresses != null)
                        {
                            if(addresses.Any())
                            {
                                Address address = addresses.FirstOrDefault(ad => ad.FormattedAddress == tbNombre.Text);
                                if(address != null)
                                {

                                }
                            }
                        }


                        Destino dest_temp = new Destino(tbNombre.Text, punto_temp.Lat, punto_temp.Lng);
                        db.Destinos.Add(dest_temp);
                        db.SaveChanges();
                        tbNombre.Text = string.Empty;
                        lblUbicacion.Text = "Ubicación: 0; 0;";
                        RecargarDestinos();
                        RecargarViajes();
                        ActualizarDataGridView();
                        
                    }
                    else MessageBox.Show("No se pueden ingresar destinos iguales.");
                    //}
                    //else MessageBox.Show("El destino debe tener una ubicación en el mapa.", "Error de sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("El destino debe tener un nombre.", "Error de sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pnlMapa_MouseMove(object sender, MouseEventArgs e)
        {
            switch (estado)
            {
                case ESTADO_EDITANDO:
                    lblUbicacion.Text = "Ubicación: " + PointToClient(MousePosition).X + ";" + PointToClient(MousePosition).Y + ";";
                    break;
                case ESTADO_EDITANDO_C:
                    lblLugarUbicacion.Text = "Ubicación: " + PointToClient(MousePosition).X + ";" + PointToClient(MousePosition).Y + ";";
                    break;
            }
            //lblTestMouse.Text = "Mouse: " + PointToClient(MousePosition).X + ";" + PointToClient(MousePosition).Y + ";";
        }
        private void BtnConectarD_Click(object sender, EventArgs e)
        {
            CrearConexion();
        }


        private void cbOrigen_SelectedValueChanged(object sender, EventArgs e)
        {
            cbConexDestino.Invalidate();

        }
        private void cbLugar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void tbLugarNombre_TextChanged(object sender, EventArgs e)
        {
            if (tbLugarNombre.Text != cbLugar.SelectedItem?.ToString())
            {
                btnLugarGuardar.Enabled = true;
            }
            else btnLugarGuardar.Enabled = false;
        }
        private void pnlMapa_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void btnLugarUbicacion_Click(object sender, EventArgs e)
        {
        }
        private void btnLugarGuardar_Click(object sender, EventArgs e)
        {
            GuardarLugar();
        }
        private void pnlMapa_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
            }
        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {/*
            using (EntityDataModel db = new EntityDataModel())
            {
                if (sender != null)
                {
                    if ((sender as RadioButton).Checked)
                    {
                        foreach (Control c in pnlMapa.Controls)
                        {
                            if (c is RadioButton)
                            {
                                (c as RadioButton).Text = string.Empty;
                                (c as RadioButton).Size = new Size(15, 15);
                            }
                        }
                        Destino destino = BuscarDestino((sender as RadioButton));
                        if (destino != null)
                        {
                            (sender as RadioButton).Text = destino.Nombre;
                            (sender as RadioButton).Size = new Size(120, 20);
                            if (cbLugar.SelectedIndex != cbLugar.Items.IndexOf(destino.Nombre))
                                cbLugar.SelectedIndex = cbLugar.Items.IndexOf(destino.Nombre);
                        }
                    }
                }
            }*/
        }
        private void btnDestinoEliminar_Click(object sender, EventArgs e)
        {
            if (markerOverlay.Markers.Contains(marker))
            {
                markerOverlay.Markers.Remove(marker);
                btnDestinoEliminar.Visible = false;
            }
            else MessageBox.Show("El marcador temporal ya fue eliminado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void pnlMapa_Paint(object sender, PaintEventArgs e)
        {/*
            try
            {
                Graphics g = e.Graphics;
                //g.Clear(Color.White);
                Pen lapiz = new Pen(Color.Blue, 4);
                string text = string.Empty;
                switch (tcAdmin.SelectedIndex)
                {
                    case 0:
                        if (rbViajeModificar.Checked || rbViajeEliminar.Checked)
                            text = cbViajeTrayecto.SelectedItem?.ToString();
                        else
                            text = cbConexTrayecto.SelectedItem?.ToString();
                        break;
                    case 1:
                        text = cbHorTrayecto.SelectedItem?.ToString();
                        break;
                    case 2:
                        text = cbDestinosTrayecto.SelectedItem?.ToString();
                        break;
                    default:
                        break;
                }
                using (EntityDataModel db = new EntityDataModel())
                {
                    Viaje viaje = GetDBViaje(db, text);
                    if (viaje != null)
                    {
                        foreach (Arco a in viaje.Arcos)
                        {
                            g.DrawLine(lapiz, a.Origen.Latitud, a.Origen.Longitud, a.Destino.Latitud, a.Destino.Longitud);
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
            }*/
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                try
                {
                    Viaje viaje = GetDBViaje(db, cbDestinosTrayecto.SelectedItem?.ToString());
                    int count = 0;
                    if (viaje != null)
                    {
                        foreach (DataGridViewRow data in dgvConexiones.SelectedRows)
                        {
                            Arco arco = viaje.Arcos.Find(a => a.Origen.Nombre == data.Cells["Origen"].Value.ToString() && a.Destino.Nombre == data.Cells["Destino"].Value.ToString());
                            if (arco != null) viaje.Arcos.Remove(arco);
                            count++;
                            break;
                        }
                        MessageBox.Show("Se eliminaron " + count + " conexiones.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.SaveChanges();
                        RecargarMarcadores();
                        ActualizarDataGridView();
                    }
                    else MessageBox.Show("No hay ningún recorrido seleccionado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Ocurrió un error interno mientras se intentaba mostrar los datos.", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnViajeCrear_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                if (rbViajeCrear.Checked)
                {
                    if (dtpViajeHoraSalida.Value.ToShortTimeString() != dtpViajeHoraSalida.MinDate.ToShortTimeString())
                    {
                        if (cbViajeDistribucion.SelectedItem != null)
                        {
                            if (cbViajeDistribucion.SelectedItem?.ToString() != string.Empty)
                            {
                                if (tbViajeNombre.Text != string.Empty && !db.Viajes.ToList().Exists(v => v.Nombre == tbViajeNombre.Text))
                                {
                                    if (clbViajeFrecuencia.CheckedItems.Count > 0)
                                    {
                                        if (IsValidFileName(tbViajeNombre.Text))
                                        {
                                            Viaje viaje = GetDBViaje(db, tbViajeNombre.Text);
                                           
                                            if (viaje == null)
                                            {
                                                Distribucion d = GetDBDistribucion(db, cbViajeDistribucion.SelectedItem?.ToString());
                                                if (d != null)
                                                {
                                                    Fila frecuencia = new Fila();
                                                    frecuencia.Cells = new List<Celda>();
                                                    for (int i = 0; i < 7; i++) frecuencia.Cells.Add(new Celda() { Value = 0, FechaRegistro = DateTime.Now });
                                                    for (int i = 0; i < clbViajeFrecuencia.CheckedItems.Count; i++) frecuencia.Cells[clbViajeFrecuencia.CheckedIndices[i]].Value = 1;

                                                    Viaje vi = new(tbViajeNombre.Text);
                                                    vi.Horarios = new List<Horario>();
                                                    vi.Horarios.Add(new Horario() { Hora = dtpViajeHoraSalida.Value.ToShortTimeString(), Frecuencia = frecuencia, Distribucion = d });
                                                    vi.Arcos = new List<Arco>();
                                                    db.Viajes.Add(vi);
                                                    db.SaveChanges();
                                                    RecargarViajes();
                                                }
                                                else MessageBox.Show("Error interno: Distribución inválida.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else MessageBox.Show("No se pueden repetir los recorridos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            char[] carateres_invalidos = Path.GetInvalidFileNameChars();
                                            string string_invalidos = string.Empty;
                                            foreach (char c in carateres_invalidos)
                                            {
                                                string_invalidos += c.ToString() + ", ";
                                            }
                                            string_invalidos.TrimEnd(',');

                                            MessageBox.Show("No puedes ingresar estos caracteres:" + Environment.NewLine + string_invalidos, "Error de sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else MessageBox.Show("No hay dias seleccionados.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else MessageBox.Show("Este recorrido ya existe o no es válido.", "Error al crear.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else MessageBox.Show("El recorrido debe tener una distribución de asientos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("No se ha creado ninguna distribución de asientos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("No se ha especificado el horario de salida para ese recorrido.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (rbViajeModificar.Checked)
                {
                    try
                    {
                        Viaje viaje = GetDBViaje(db, cbViajeTrayecto.SelectedItem?.ToString());
                        if (viaje != null)
                        {
                            if (!db.Viajes.ToList().Exists(viaje_t => viaje_t.Nombre == tbViajeNombre.Text && viaje_t != viaje))
                            {
                                if (IsValidFileName(tbViajeNombre.Text))
                                {
                                    viaje.Nombre = tbViajeNombre.Text;
                                    db.SaveChanges();
                                    RecargarDestinos();
                                    RecargarViajes();
                                    ActualizarDataGridView();
                                }
                                else
                                {
                                    char[] carateres_invalidos = Path.GetInvalidFileNameChars();
                                    string string_invalidos = string.Empty;
                                    foreach (char c in carateres_invalidos)
                                    {
                                        string_invalidos += c.ToString() + ", ";
                                    }
                                    string_invalidos.TrimEnd(',');

                                    MessageBox.Show("No puedes ingresar estos caracteres:" + Environment.NewLine + string_invalidos, "Error de sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else MessageBox.Show("No puede haber dos recorridos con el mismo nombre.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Los datos ingresados no son correctos o son inválidos.", "Error inesperado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbViajeEliminar.Checked)
                {
                    if (MessageBox.Show("Eliminar un recorrido puede causar errores en los boletos que se hayan hecho en base al mismo." + Environment.NewLine + "¿Está seguro que desea eliminar este recorrido, sus conexiones y horarios?" + Environment.NewLine + Environment.NewLine + "Esta acción no se puede deshacer.", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Viaje v = GetDBViaje(db, cbViajeTrayecto.SelectedItem?.ToString());
                            if (v != null)
                            {
                                db.Viajes.Remove(v);
                                db.SaveChanges();
                                RecargarViajes();
                                MessageBox.Show("El recorrido fue eliminado correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EnableRadioButtons();
                            }
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Ocurrió un error interno al intentar eliminar un viaje.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void rbCrearRecorrido_CheckedChanged(object sender, EventArgs e)
        {
            if (rbViajeCrear.Checked)
            {
                foreach (Control c in gbCrearViajes.Controls)
                {
                    if (c.Tag != null)
                    {
                        if (c.Tag.ToString() == "viaje_modificables" || c.Tag.ToString() == "viaje_creables")
                        {
                            c.Enabled = true;
                        }
                        else c.Enabled = false;
                    }
                }
                btnViajeCrear.Text = "Crear";
                if (cbViajeDistribucion.Items.Count > 0) cbViajeDistribucion.SelectedIndex = 0;
                tbViajeNombre.Text = string.Empty;
                dtpViajeHoraSalida.Value = Convert.ToDateTime(DateTime.MinValue.ToShortTimeString());

                for (int i = 0; i < clbViajeFrecuencia.Items.Count; i++)
                {
                    clbViajeFrecuencia.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }
        private void rbModificarRecorrido_CheckedChanged(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                try
                {
                    if (rbViajeModificar.Checked)
                    {
                        foreach (Control c in gbCrearViajes.Controls)
                        {
                            if (c.Tag != null)
                            {
                                if (c.Tag.ToString() == "viaje_creables")
                                {
                                    c.Enabled = false;
                                }
                                else c.Enabled = true;
                            }
                        }
                        btnViajeCrear.Text = "Modificar";

                        Viaje v = GetDBViaje(db, cbViajeTrayecto.SelectedItem?.ToString());
                        if (v != null)
                        {
                            if (cbViajeTrayecto.Items.Count > 0) cbViajeTrayecto.SelectedIndex = cbViajeTrayecto.SelectedIndex;
                        }
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }
        private void rbViajeEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbViajeEliminar.Checked)
            {
                foreach (Control c in gbCrearViajes.Controls)
                {
                    if (c.Tag != null)
                    {
                        if (c.Tag.ToString() == "no_modificables")
                        {
                            c.Enabled = true;
                        }
                        else c.Enabled = false;
                    }
                }
                btnViajeCrear.Text = "Eliminar";
            }
        }
        private void rbCrearConexion_CheckedChanged(object sender, EventArgs e)
        {
            lblConexConexion.Enabled = false;
            cbConexConexion.Enabled = false;
            btnConexConectar.Text = "Conectar";
        }
        private void rbModificarConexion_CheckedChanged(object sender, EventArgs e)
        {
            lblConexConexion.Enabled = true;
            cbConexConexion.Enabled = true;
            btnConexConectar.Text = "Modificar";
        }
        private void cbDestinosTrayecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecargarMarcadores();
            ActualizarDataGridView();
            cbConexTrayecto.SelectedIndex = cbDestinosTrayecto.SelectedIndex;
        }
        private void tcAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecargarMarcadores();
        }
        private void cbViajeTrayecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                try
                {
                    Viaje v = GetDBViaje(db, cbViajeTrayecto.SelectedItem?.ToString());
                    if (v != null)
                    {
                        if (rbViajeModificar.Checked) tbViajeNombre.Text = v.Nombre;
                        RecargarMarcadores();
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }
        private void rbHorCrear_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHorCrear.Checked)
            {
                btnHorCrear.Text = rbHorCrear.Text;
                foreach (Control c in gbHorControl.Controls)
                {
                    if (c.Tag != null)
                    {
                        if (c.Tag.ToString() == "horario_modificable")
                        {
                            c.Enabled = false;
                        }
                        else c.Enabled = true;
                    }
                }
            }
        }
        private void rbHorModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHorModificar.Checked)
            {
                btnHorCrear.Text = rbHorModificar.Text;
                foreach (Control c in gbHorControl.Controls)
                {
                    if (c.Tag != null)
                    {
                        if (c.Tag.ToString() == "horario_modificable")
                        {
                            c.Enabled = true;
                        }
                        else c.Enabled = true;
                    }
                }
                cbHorHorarios.SelectedIndex = 0;
            }
        }
        private void rbHorEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHorEliminar.Checked)
            {
                btnHorCrear.Text = rbHorModificar.Text;
                foreach (Control c in gbHorControl.Controls)
                {
                    if (c.Tag != null)
                    {
                        if (c.Tag.ToString() == "horario_modificable")
                        {
                            c.Enabled = true;
                        }
                        else c.Enabled = false;
                    }
                }
            }
        }
        private void cbHorTrayecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecargarHorarios();
            RecargarMarcadores();
        }
        private void cbHorHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbHorModificar.Checked)
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    try
                    {
                        Viaje viaje = GetDBViaje(db, cbHorTrayecto.SelectedItem?.ToString());
                        if (viaje != null)
                        {
                            Horario h = viaje.Horarios.Find(horario => horario.Hora == cbHorHorarios.SelectedItem?.ToString());
                            if (h != null)
                            {
                                dtpHorHora.Value = DateTime.Parse(h.Hora);
                                for (int i = 0; i < clbHorFrecuencia.Items.Count; i++)
                                {
                                    if (h.Frecuencia.Cells[i].Value == 1) clbHorFrecuencia.SetItemCheckState(i, CheckState.Checked);
                                }
                                cbHorDistr.SelectedIndex = cbHorDistr.Items.IndexOf(h.Distribucion.Nota);
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {

                    }
                }
            }
        }
        private void cbConexTrayecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                try
                {
                    Viaje viaje = GetDBViaje(db, cbConexTrayecto.SelectedItem?.ToString());
                    if (viaje != null)
                    {
                        cbConexConexion.Items.Clear();
                        foreach (Arco a in viaje.Arcos)
                        {
                            cbConexConexion.Items.Add(a.Origen.Nombre + " - " + a.Destino.Nombre);
                            cbConexConexion.SelectedIndex = 0;
                        }
                    }
                    RecargarMarcadores();
                }
                catch (NullReferenceException)
                {

                }
            }
        }
        private void cbConexConexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbConexModificar.Checked)
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    try
                    {
                        Viaje viaje = GetDBViaje(db, cbConexTrayecto.SelectedItem?.ToString());
                        if (viaje != null)
                        {
                            string[] conexion = cbConexConexion.SelectedItem?.ToString().Split(new[] { " - " }, StringSplitOptions.None);
                            string origen = conexion[0];
                            string destino = conexion[1];
                            cbConexOrigen.SelectedIndex = cbConexOrigen.Items.IndexOf(origen);
                            cbConexDestino.SelectedIndex = cbConexDestino.Items.IndexOf(destino);

                            Arco a = viaje.Arcos.Find(arco => arco.Origen.Nombre == origen && arco.Destino.Nombre == destino);
                            if (a != null)
                            {
                                dtpConexDemora.Value = DateTime.Parse(a.Demora);
                                nudConexPrecio.Value = Convert.ToDecimal(a.Precio);
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {

                    }
                }
            }
        }
        private void btnHorDistr_Click(object sender, EventArgs e)
        {

        }
        private void btnHorCrear_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                if (cbHorTrayecto.SelectedItem != null)
                {
                    Viaje viaje = GetDBViaje(db, cbHorTrayecto.SelectedItem?.ToString());
                    if (viaje != null)
                    {
                        if (rbHorCrear.Checked)
                        {
                            if (dtpHorHora.Value.ToShortTimeString() != dtpHorHora.MinDate.ToShortTimeString())
                            {
                                if (clbHorFrecuencia.CheckedItems.Count > 0)
                                {
                                    if (cbHorDistr.SelectedItem != null)
                                    {
                                        if (cbHorDistr.SelectedItem?.ToString() != string.Empty)
                                        {
                                            if (!viaje.Horarios.Exists(horario => horario.Hora == dtpHorHora.Value.ToShortTimeString()))
                                            {
                                                Fila frecuencia = new Fila();
                                                frecuencia.Cells = new List<Celda>();
                                                for (int i = 0; i < 7; i++) frecuencia.Cells.Add(new Celda() { Value = 0, FechaRegistro = DateTime.Now });

                                                for (int i = 0; i < clbHorFrecuencia.CheckedItems.Count; i++)
                                                {
                                                    frecuencia.Cells[clbHorFrecuencia.CheckedIndices[i]].Value = 1;
                                                }

                                                Distribucion d = GetDBDistribucion(db, cbHorDistr.SelectedItem?.ToString());
                                                if (d != null)
                                                {
                                                    viaje.Horarios.Add(new Horario() { Frecuencia = frecuencia, Distribucion = d, Hora = dtpHorHora.Value.ToShortTimeString() });
                                                    MessageBox.Show("Horario agregado correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    db.SaveChanges();
                                                    RecargarHorarios();
                                                }
                                                else MessageBox.Show("Error inesperado: No se logró encontrar la distribución seleccionada.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else MessageBox.Show("No se puede crear dos horarios iguales.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else MessageBox.Show("No se ha seleccionado ninguna distribución de asientos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else MessageBox.Show("Debe haber como minimo un día seleccionado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else MessageBox.Show("No se ha especificado una hora.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (rbHorModificar.Checked)
                        {
                            if (dtpHorHora.Value.ToShortTimeString() != "00:00:00")
                            {
                                if (clbHorFrecuencia.CheckedItems.Count > 0)
                                {
                                    if (cbHorDistr.SelectedItem != null)
                                    {
                                        if (cbHorDistr.SelectedItem?.ToString() != string.Empty)
                                        {
                                            try
                                            {
                                                Horario h = viaje.Horarios.Find(horario => horario.Hora == cbHorHorarios.SelectedItem?.ToString());
                                                if (h != null)
                                                {
                                                    Distribucion d = GetDBDistribucion(db, cbHorDistr.SelectedItem?.ToString());
                                                    for (int i = 0; i < 7; i++) h.Frecuencia.Cells[i].Value = 0;
                                                    for (int i = 0; i < clbHorFrecuencia.CheckedItems.Count; i++) h.Frecuencia.Cells[clbHorFrecuencia.CheckedIndices[i]].Value = 1;

                                                    if (d != null)
                                                    {
                                                        h.Hora = dtpHorHora.Value.ToShortTimeString();
                                                        h.Distribucion = d;

                                                        db.SaveChanges();
                                                        RecargarHorarios();
                                                        MessageBox.Show("Horario modificado correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else MessageBox.Show("Error inesperado: No se logró encontrar la distribución seleccionada.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else MessageBox.Show("Error inesperado: No se pudo encontrar en la lista el horario seleccionado.", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            catch (NullReferenceException)
                                            {

                                            }
                                        }
                                    }
                                    else MessageBox.Show("No se ha seleccionado ninguna distribución de asientos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else MessageBox.Show("Debe haber como minimo un día seleccionado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else MessageBox.Show("No se ha especificado una hora.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (rbHorEliminar.Checked)
                        {
                            if (cbHorHorarios.SelectedItem != null)
                            {
                                if (cbHorHorarios.SelectedItem?.ToString() != string.Empty)
                                {
                                    Horario h = viaje.Horarios.Find(horario => horario.Hora == cbHorHorarios.SelectedItem?.ToString());
                                    if (h != null)
                                    {
                                        if (MessageBox.Show("Eliminar horarios puede provocar errores en los boletos que se hayan creado con ese horario." + Environment.NewLine + "¿Está seguro que quiere eliminar este horario?" + Environment.NewLine + Environment.NewLine + "Esta acción no se puede deshacer.", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            viaje.Horarios.Remove(h);
                                            db.SaveChanges();
                                            RecargarHorarios();
                                            MessageBox.Show("El horario fue eliminado correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else MessageBox.Show("Error inesperado: No se pudo encontrar el horario especificado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else MessageBox.Show("Error inesperado: No se pudo encontrar ese viaje.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("No hay ningun recorrido seleccionado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModEGuardar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewButtonCell d in dgvAsientos.SelectedCells)
            {
                if (rbPBModEAsiento.Checked)
                {
                    d.FlatStyle = FlatStyle.Flat;
                    d.Tag = "A";
                }
                else if (rbPBModEPasillo.Checked)
                {
                    d.FlatStyle = FlatStyle.Flat;
                    d.Tag = "P";
                }
                else if (rbPBModENinguno.Checked)
                {
                    d.FlatStyle = FlatStyle.Flat;
                    d.Tag = "N";
                }
                else if (rbPBModETelevision.Checked)
                {
                    d.FlatStyle = FlatStyle.Flat;
                    d.Tag = "T";
                }
                d.Value = string.Empty;
            }
            ContarAsientos();
            Guardar();
        }
        private void dgvAsientos_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            gbPBModEspacio.Enabled = true;

            if (dgvAsientos.SelectedCells.Count == 1)
            {
                foreach (DataGridViewButtonCell c in dgvAsientos.SelectedCells)
                {
                    switch (c.Tag)
                    {
                        case "A":
                            rbPBModEAsiento.Checked = true;
                            break;
                        case "P":
                            rbPBModEPasillo.Checked = true;
                            break;
                        case "T":
                            rbPBModETelevision.Checked = true;
                            break;
                        case "N":
                            rbPBModENinguno.Checked = true;
                            break;
                    }
                    break;
                }
            }
            else
            {
                foreach (Control c in gbDistrTipos.Controls) if (c is RadioButton) { (c as RadioButton).Checked = false; }
            }
        }
        private void nudDistrCantidad_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int valor = (int)nudDistrCantidad.Value / 5;
                List<Fila> matriz_list = null;
                int rows = -1;
                string matriz_name = string.Empty;

                if (rbPA.Checked)
                {
                    matriz_list = distribucion.Matriz_PA;
                    matriz_name = "PA";
                    rows = distribucion.Matriz_PA.Count;
                }
                else if (rbPB.Checked)
                {
                    matriz_list = distribucion.Matriz_PB;
                    matriz_name = "PB";
                    rows = distribucion.Matriz_PB.Count;
                }

                if (nudDistrCantidad.Value != rows * 5)
                {
                    if (nudDistrCantidad.Value < rows * 5)
                    {
                        dgvAsientos.Rows.RemoveAt(dgvAsientos.Rows.GetLastRow(DataGridViewElementStates.Visible));
                        distribucion.RemoveRowCells(matriz_name, 1);
                    }
                    else
                    {
                        distribucion.AddRowCells(matriz_name, valor - rows);
                    }

                    Guardar();
                    DrawDistribution();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ocurrió un error al mostrar los datos.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cbDistrPisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDistrPisos.SelectedIndex)
            {
                case 0:
                    rbPB.Checked = true;
                    rbPA.Enabled = false;
                    if (distribucion != null)
                        distribucion.UnPiso = true;
                    //DrawDistribution();
                    break;
                case 1:
                    rbPB.Checked = true;
                    rbPA.Enabled = true;
                    if (distribucion != null)
                        distribucion.UnPiso = false;
                    //DrawDistribution();
                    break;
            }
        }
        private void btnDistrCrear_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                if (rbDistrCrear.Checked)
                {
                    if (distribucion.ContarAsientos() > 10)
                    {
                        if (tbNota.Text != string.Empty)
                        {
                            if (GetDBDistribucion(db, tbNota.Text) == null)
                            {
                                distribucion.Nota = tbNota.Text;
                                Distribucion d = new()
                                {
                                    Nota = tbNota.Text,
                                    UnPiso = distribucion.UnPiso,
                                    Matriz_PA = new List<Fila>(),
                                    Matriz_PB = new List<Fila>()
                                };

                                d.Matriz_PB.Clear();
                                d.AddRowCells("PB", distribucion.Matriz_PB.Count);

                                foreach (Fila row in distribucion.Matriz_PB)
                                {
                                    int row_index = distribucion.Matriz_PB.IndexOf(row);
                                    foreach (Celda cell in row.Cells)
                                    {
                                        int cell_index = row.Cells.IndexOf(cell);
                                        d.Matriz_PB[row_index].Cells[cell_index].Value = distribucion.Matriz_PB[row_index].Cells[cell_index].Value;
                                    }
                                }

                                d.Matriz_PA.Clear();
                                d.AddRowCells("PA", distribucion.Matriz_PA.Count);

                                foreach (Fila row in distribucion.Matriz_PA)
                                {
                                    int row_index = distribucion.Matriz_PA.IndexOf(row);
                                    foreach (Celda cell in row.Cells)
                                    {
                                        int cell_index = row.Cells.IndexOf(cell);
                                        d.Matriz_PA[row_index].Cells[cell_index].Value = distribucion.Matriz_PA[row_index].Cells[cell_index].Value;
                                    }
                                }

                                db.Distribuciones.Add(d);
                                db.SaveChanges();
                                distribucion = new Distribucion(30, 30);
                                DrawDistribution();
                                RecargarDistribuciones();

                                MessageBox.Show("La distribución se ha creado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else MessageBox.Show("Ya existe una distribución con esa nota.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("Es necesario escribir una nota.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("No se pueden crear distribuciones con tan pocos asientos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (rbDistrMod.Checked)
                {
                    Distribucion d = GetDBDistribucion(db, cbDistrDistribucion.SelectedItem?.ToString());
                    if (d != null)
                    {
                        if (!db.Distribuciones.Any(distr => distr.Nota == tbNota.Text && distr.Id != d.Id))
                        {
                            distribucion.Nota = tbNota.Text;
                            if (cbDistrPisos.SelectedIndex == 0) distribucion.UnPiso = true;
                            else distribucion.UnPiso = false;

                            if (d.Matriz_PB.Count != distribucion.Matriz_PB.Count)
                            {
                                if (distribucion.Matriz_PB.Count > d.Matriz_PB.Count)
                                {
                                    d.AddRowCells("PB", distribucion.Matriz_PB.Count - d.Matriz_PB.Count);
                                }
                                else
                                {
                                    d.RemoveRowCells("PB", d.Matriz_PB.Count - distribucion.Matriz_PB.Count);
                                }
                            }

                            if (d.Matriz_PA.Count != distribucion.Matriz_PA.Count)
                            {
                                if (distribucion.Matriz_PA.Count > d.Matriz_PA.Count)
                                {
                                    d.AddRowCells("PA", distribucion.Matriz_PA.Count - d.Matriz_PA.Count);
                                }
                                else
                                {
                                    d.RemoveRowCells("PA", d.Matriz_PA.Count - distribucion.Matriz_PA.Count);
                                }
                            }

                            foreach (Fila row in distribucion.Matriz_PB)
                            {
                                int row_index = distribucion.Matriz_PB.IndexOf(row);
                                foreach (Celda cell in row.Cells)
                                {
                                    int cell_index = row.Cells.IndexOf(cell);
                                    d.Matriz_PB[row_index].Cells[cell_index].Value = distribucion.Matriz_PB[row_index].Cells[cell_index].Value;
                                }
                            }

                            foreach (Fila row in distribucion.Matriz_PA)
                            {
                                int row_index = distribucion.Matriz_PA.IndexOf(row);
                                foreach (Celda cell in row.Cells)
                                {
                                    int cell_index = row.Cells.IndexOf(cell);
                                    d.Matriz_PA[row_index].Cells[cell_index].Value = distribucion.Matriz_PA[row_index].Cells[cell_index].Value;
                                }
                            }

                            d.Nota = distribucion.Nota;
                            db.SaveChanges();

                            DrawDistribution();
                            RecargarDistribuciones();
                            MessageBox.Show("Los cambios se han guardado correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Esa nota ya está en uso.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Error interno.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void rbPA_CheckedChanged(object sender, EventArgs e)
        {
            DrawDistribution();
        }
        private void rbPB_CheckedChanged(object sender, EventArgs e)
        {
            DrawDistribution();
        }
        private void rbDistrMod_CheckedChanged(object sender, EventArgs e)
        {
            cbDistrDistribucion.Enabled = true;
            lblDistr.Enabled = true;
            btnDistrCrear.Text = "Modificar";
            if (cbDistrDistribucion.Items.Count > 0) cbDistrDistribucion.SelectedIndex = 0;
        }
        private void cbDistrDistribucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbDistrMod.Checked)
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    Distribucion d = GetDBDistribucion(db, cbDistrDistribucion.SelectedItem?.ToString());
                    if (d != null)
                    {
                        distribucion.Nota = d.Nota;
                        distribucion.UnPiso = d.UnPiso;
                        distribucion.Matriz_PA = d.Matriz_PA;
                        distribucion.Matriz_PB = d.Matriz_PB;

                        tbNota.Text = distribucion.Nota;
                        DrawDistribution();
                        if (EsDoblePiso(distribucion))
                        {
                            cbDistrPisos.SelectedIndex = 1;
                        }
                        else cbDistrPisos.SelectedIndex = 0;
                    }
                }
            }
        }
        private void rbDistrCrear_CheckedChanged(object sender, EventArgs e)
        {
            btnDistrCrear.Text = "Crear";
            cbDistrDistribucion.Enabled = false;
            lblDistr.Enabled = false;
            tbNota.Text = string.Empty;
            distribucion = new Distribucion(30, 30);
            DrawDistribution();
        }

        private string GetDayStringFromIndex(int i)
        {
            return i switch
            {
                0 => "Lun",
                1 => "Mar",
                2 => "Mie",
                3 => "Jue",
                4 => "Vie",
                5 => "Sab",
                6 => " Dom",
                _ => "Error.",
            };
        }
        /*
        private Distribucion CurrentDistribucion(string text)
        {
            using (EntityDataModel db = new EntityDataModel())
            {               
                var distribuciones = db.Distribuciones.ToList();
                return distribuciones.Find(distr => distr.Nota == text);
            }
        }
        */
        private void ActualizarDataGridView()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                try
                {
                    Viaje viaje = GetDBViaje(db, cbDestinosTrayecto.SelectedItem?.ToString());
                    dgvConexiones.Rows.Clear();
                    if (viaje != null)
                    {
                        foreach (Arco a in viaje.Arcos)
                        {
                            dgvConexiones.Rows.Add(a.Origen.Nombre, a.Destino.Nombre, a.Demora, a.Precio, "UP", "DOWN");
                        }
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }
        private bool EsDoblePiso(Distribucion distribucion)
        {
            if (distribucion != null && distribucion.Matriz_PA != null)
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
        private void RecargarDistribuciones()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var distribuciones = db.Distribuciones.ToList();
                SyncComboBoxItems_Distribucion(cbHorDistr, distribuciones);
                SyncComboBoxItems_Distribucion(cbViajeDistribucion, distribuciones);
                SyncComboBoxItems_Distribucion(cbDistrDistribucion, distribuciones);

                if (distribuciones.Count > 0)
                    rbDistrMod.Enabled = true;
            }
        }

        public void SyncComboBoxItems_Destino(ComboBox comboBox, List<Destino> list)
        {
            if (list.Count > 0)
            {
                if (!list.Equals(comboBox.Items))
                {
                    foreach (Destino d in list)
                    {
                        if (!comboBox.Items.Contains(d.Nombre))
                        {
                            comboBox.Items.Add(d.Nombre);
                        }
                    }
                    List<string> list_remove = new List<string>();
                    foreach (string item in comboBox.Items)
                    {
                        if (!list.Exists(d => d.Nombre == item))
                        {
                            list_remove.Add(item);
                        }
                    }
                    foreach (var item in list_remove)
                        comboBox.Items.Remove(item);

                    if (comboBox.SelectedIndex < 0 && comboBox.Items.Count >= 0)
                    {
                        comboBox.SelectedIndex = 0;
                        if (!comboBox.Enabled) comboBox.Enabled = true;
                    }
                }
            }
        }


        public void SyncComboBoxItems_Distribucion(ComboBox comboBox, List<Distribucion> list)
        {
            if (list.Count > 0)
            {
                if (list.Count != comboBox.Items.Count)
                {
                    foreach (Distribucion d in list)
                    {
                        if (!comboBox.Items.Contains(d.Nota))
                            comboBox.Items.Add(d.Nota);
                    }
                    foreach (string item in comboBox.Items)
                    {
                        if (!list.Exists(d => d.Nota == item))
                        {
                            comboBox.Items.Remove(item);
                        }
                    }
                    if (comboBox.SelectedIndex < 0 && comboBox.Items.Count >= 0)
                    {
                        comboBox.SelectedIndex = 0;
                    }
                }
            }
        }

        public void SyncComboBoxItems_Viaje(ComboBox comboBox, List<Viaje> list)
        {
            if (list.Count > 0)
            {
                if (list.Count != comboBox.Items.Count)
                {
                    foreach (Viaje d in list)
                    {
                        if (!comboBox.Items.Contains(d.Nombre))
                            comboBox.Items.Add(d.Nombre);
                    }

                    foreach (string item in comboBox.Items)
                    {
                        if (!list.Exists(d => d.Nombre == item))
                        {
                            comboBox.Items.Remove(item);
                        }
                    }
                    if (comboBox.SelectedIndex < 0 && comboBox.Items.Count >= 0)
                    {
                        comboBox.SelectedIndex = 0;
                    }
                }
            }
        }


        private void Guardar()
        {
            if (rbPA.Checked)
            {
                foreach (DataGridViewRow row in dgvAsientos.Rows)
                {
                    foreach (DataGridViewButtonCell cell in row.Cells)
                    {
                        switch (cell.Tag)
                        {
                            case "A":
                                distribucion.AgregarButacaPA(cell.RowIndex, cell.ColumnIndex);
                                break;
                            case "P":
                                distribucion.AgregarPasilloPA(cell.RowIndex, cell.ColumnIndex);
                                break;
                            case "T":
                                distribucion.AgregarTVPA(cell.RowIndex, cell.ColumnIndex);
                                break;
                            case "N":
                                distribucion.RemoverPA(cell.RowIndex, cell.ColumnIndex);
                                break;
                            default:
                                distribucion.SetCellContent("PA", cell.RowIndex, cell.ColumnIndex, 0);
                                break;
                        }
                    }
                }
            }
            else if (rbPB.Checked)
            {
                foreach (DataGridViewRow row in dgvAsientos.Rows)
                {
                    foreach (DataGridViewButtonCell cell in row.Cells)
                    {
                        switch (cell.Tag)
                        {
                            case "A":
                                distribucion.AgregarButacaPB(cell.RowIndex, cell.ColumnIndex);
                                break;
                            case "P":
                                distribucion.AgregarPasilloPB(cell.RowIndex, cell.ColumnIndex);
                                break;
                            case "T":
                                distribucion.AgregarTVPB(cell.RowIndex, cell.ColumnIndex);
                                break;
                            case "N":
                                distribucion.RemoverPB(cell.RowIndex, cell.ColumnIndex);
                                break;
                            default:
                                distribucion.SetCellContent("PB", cell.RowIndex, cell.ColumnIndex, 0);
                                break;
                        }
                    }
                }
            }
        }
        private void ContarAsientos()
        {
            int i = 0;
            List<Fila> matriz_list = null;
            int rows = -1;
            if (rbPA.Checked)
                matriz_list = distribucion.Matriz_PA;
            else
                matriz_list = distribucion.Matriz_PB;


            rows = matriz_list.Count;

            i = 1;
            /*
            for (int j = 0; j < matriz_list.Count; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (distribucion.GetCellContent("PB", j, k) == 2)
                        i++;
                }
            }
            */
            foreach (DataGridViewRow d in dgvAsientos.Rows)
            {
                foreach (DataGridViewButtonCell c in d.Cells)
                {
                    switch (c.Tag)
                    {
                        case "A":
                            c.Value = i.ToString();
                            c.ToolTipText = "Butaca";
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
                        default:
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
        private void DrawDistribution()
        {
            const int ESPACIO_NULL = -1;
            const int ESPACIO_PASILLO = 1;
            const int ESPACIO_BUTACA = 2;
            const int ESPACIO_TV = 3;

            List<Fila> matriz_list = null;
            string matriz_name = string.Empty;

            if (rbPB.Checked)
            {
                matriz_list = distribucion.Matriz_PB;
                matriz_name = "PB";
            }
            else if (rbPA.Checked)
            {
                matriz_list = distribucion.Matriz_PA;
                matriz_name = "PA";
            }

            dgvAsientos.Rows.Clear();

            if (matriz_list != null)
            {


                try
                {
                    nudDistrCantidad.Value = matriz_list.Count * 5;
                }
                catch (ArgumentOutOfRangeException)
                {

                }

                DataGridViewButtonCell c;
                for (int i = 0; i < matriz_list.Count; i++)
                {
                    dgvAsientos.Rows.Add();
                    for (int j = 0; j < 5; j++)
                    {
                        switch (distribucion.GetCellContent(matriz_name, i, j))
                        {
                            case ESPACIO_BUTACA:
                                c = new DataGridViewButtonCell
                                {
                                    Tag = "A"
                                };
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_PASILLO:
                                c = new DataGridViewButtonCell
                                {
                                    Tag = "P"
                                };
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_TV:
                                c = new DataGridViewButtonCell
                                {
                                    Tag = "T"
                                };
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            case ESPACIO_NULL:
                                c = new DataGridViewButtonCell
                                {
                                    Tag = "N"
                                };
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                            default:
                                c = new DataGridViewButtonCell
                                {
                                    Tag = "E"
                                };
                                dgvAsientos.Rows[i].Cells[j] = c;
                                break;
                        }
                    }
                }
                ContarAsientos();
            }
        }

        /*
        private Viaje CurrentViaje(string text)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var viajes = db.Viajes.ToList();                
                foreach (Viaje v in viajes) if (v.Nombre == text) return v;                         
                return null;
            }
        }
        */

        private void CrearConexion()
        {
            if (cbConexOrigen.SelectedIndex >= 0 && cbConexDestino.SelectedIndex >= 0)
            {
                if (dtpConexDemora.Value.Hour != 0 || dtpConexDemora.Value.Minute != 0 || dtpConexDemora.Value.Second != 0)
                {
                    using (EntityDataModel db = new EntityDataModel())
                    {
                        Viaje viaje = GetDBViaje(db, cbConexTrayecto.SelectedItem?.ToString());
                        try
                        {
                            if (cbConexTrayecto.SelectedItem?.ToString() != string.Empty)
                            {
                                if (!cbConexOrigen.SelectedItem.Equals(cbConexDestino.SelectedItem))
                                {
                                    if (rbConexCrear.Checked)
                                    {
                                        if (viaje != null)
                                        {
                                            if (!viaje.Arcos.Exists(a => a.Origen.Nombre == cbConexOrigen.SelectedItem?.ToString() && a.Destino.Nombre == cbConexDestino.SelectedItem?.ToString()))
                                            {
                                                Destino origen = GetDBDestino(db, cbConexOrigen.SelectedItem?.ToString());
                                                Destino destino = GetDBDestino(db, cbConexDestino.SelectedItem?.ToString());
                                                viaje.Arcos.Add(new Arco() { Origen = origen, Destino = destino, Demora = dtpConexDemora.Value.ToShortTimeString(), Precio = Convert.ToDouble(nudConexPrecio.Value) });
                                                if (cbConexOrigen.Items.Count > 0) cbConexOrigen.SelectedIndex = 0;
                                                if (cbConexDestino.Items.Count > 0) cbConexDestino.SelectedIndex = 0;
                                                dtpConexDemora.Value = DateTime.Today.Add(new TimeSpan(0, 0, 0));
                                                nudConexPrecio.Value = 0;
                                                RecargarMarcadores();
                                                ActualizarDataGridView();
                                                db.SaveChanges();
                                                MessageBox.Show("Conexión creada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else MessageBox.Show("No se pueden repetir las conexiones entre destinos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else MessageBox.Show("Error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else if (rbConexModificar.Checked)
                                    {
                                        if (viaje != null)
                                        {
                                            if (cbConexConexion.SelectedItem?.ToString() != string.Empty)
                                            {

                                            }
                                            else MessageBox.Show("No se ha seleccionado una conexión.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else MessageBox.Show("No pueden ser iguales los dos destinos.", "Error de sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else MessageBox.Show("No hay trayectos seleccionados.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (NullReferenceException ex)
                        {
                            MessageBox.Show("No se pudo ejecutar la acción." + Environment.NewLine + "Detalles: " + ex.Message, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else MessageBox.Show("El destino debe tener un tiempo de demora.");
            }
            else MessageBox.Show("Debe seleccionar un origen y destino.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void RecargarViajes()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var viajes = db.Viajes.ToList();
                Viajes_LoadReferences(ref viajes, db);

                SyncComboBoxItems_Viaje(cbViajeTrayecto, viajes);
                SyncComboBoxItems_Viaje(cbConexTrayecto, viajes);
                SyncComboBoxItems_Viaje(cbDestinosTrayecto, viajes);
                SyncComboBoxItems_Viaje(cbHorTrayecto, viajes);

                if (viajes.Count <= 0)
                {
                    rbViajeModificar.Enabled = false;
                    rbViajeCrear.Checked = true;
                    gbConexionDestinos.Enabled = false;
                    gbHorControl.Enabled = false;
                    gbHorHorarios.Enabled = false;
                    gbHorRecorridos.Enabled = false;
                }
                else
                {
                    rbConexModificar.Enabled = true;
                    gbConexionDestinos.Enabled = true;
                    gbHorControl.Enabled = true;
                    gbHorHorarios.Enabled = true;
                    gbHorRecorridos.Enabled = true;
                }
            }
        }
        private void RecargarDestinos()
        {
            try
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    var destinos = db.Destinos.ToList();

                    if (destinos != null)
                    {
                        SyncComboBoxItems_Destino(cbConexOrigen, destinos);
                        SyncComboBoxItems_Destino(cbConexDestino, destinos);
                        SyncComboBoxItems_Destino(cbLugar, destinos);
                    }

                    if (cbConexDestino.Items.Count >= 1) cbConexDestino.SelectedIndex = 0;
                    if (cbViajeDistribucion.Items.Count > 0) cbViajeDistribucion.SelectedIndex = 0;

                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error al cargar los destinos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RecargarMarcadores()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                string text = string.Empty;
                switch (tcAdmin.SelectedIndex)
                {
                    case 0:
                        if (rbViajeModificar.Checked || rbViajeEliminar.Checked)
                            text = cbViajeTrayecto.SelectedItem?.ToString();
                        else
                            text = cbConexTrayecto.SelectedItem?.ToString();
                        break;
                    case 1:
                        text = cbHorTrayecto.SelectedItem?.ToString();
                        break;
                    case 2:
                        text = cbDestinosTrayecto.SelectedItem?.ToString();
                        break;
                    default:
                        break;
                }


                var viaje = GetDBViaje(db, text);
                if (viaje != null)
                {   
                    mOverlayViaje.Markers.Clear();
                    mOverlayRutas.Routes.Clear();
                    foreach (var arco in viaje.Arcos)
                    {
                        GMarkerGoogle gMarker = new GMarkerGoogle(new PointLatLng(arco.Origen.Latitud, arco.Origen.Longitud), GMarkerGoogleType.red_dot);
                        mOverlayViaje.Markers.Add(gMarker);

                        gMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        gMarker.ToolTipText = "Lugar: " + arco.Origen.Nombre + Environment.NewLine + "Próximo destino: " + arco.Destino.Nombre;
                        gMarker.ToolTip.TextPadding = new Size(10, 10);
                        try
                        {
                            PointLatLng start = new PointLatLng(arco.Origen.Latitud, arco.Origen.Longitud);
                            PointLatLng end = new PointLatLng(arco.Destino.Latitud, arco.Destino.Longitud);

                            var route = GoogleMapProvider.Instance.GetRoute(start, end, false, false, 14);
                            GMapRoute r = new(route.Points, "Ruta") { Stroke = new Pen(Color.MediumBlue, 4) };

                            mOverlayRutas.Routes.Add(r);
                        }
                        catch(NullReferenceException)
                        {
                            lblTestMouse.Text = "La información de las rutas no fue tomada correctamente.";
                        }
                        gMPMapa.Zoom = gMPMapa.Zoom++;
                        gMPMapa.Zoom = gMPMapa.Zoom--;
                        if (arco == viaje.Arcos.Last())
                        {
                            gMarker = new GMarkerGoogle(new PointLatLng(arco.Destino.Latitud, arco.Destino.Longitud), GMarkerGoogleType.red);
                            mOverlayViaje.Markers.Add(gMarker);

                            gMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            gMarker.ToolTipText = "ültimo lugar: " + arco.Origen.Nombre + Environment.NewLine;
                            gMarker.ToolTip.TextPadding = new Size(10, 10);
                        }
                    }
                    gMPMapa.ZoomAndCenterRoutes("Rutas");
                }
            }
        }


        private void CrearMarcador(Destino destino)
        {

        }


        private void GuardarLugar()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var boletos = db.Boletos.ToList();
                var destinos = db.Destinos.ToList();

                try
                {
                    string text = cbLugar.SelectedItem?.ToString();

                    Destino d = null;

                    d = destinos.Find(dest => dest.Nombre == text);

                    if (d != null)
                    {
                        Destino destino_temp = destinos.Find(dest => dest.Nombre == tbLugarNombre.Text && dest.Nombre != text);
                        if (destino_temp == null)
                        {
                            d.Nombre = tbLugarNombre.Text;
                            d.Latitud = punto_temp.Lat;
                            d.Longitud = punto_temp.Lng;
                            db.SaveChanges();

                            RecargarDestinos();
                            RecargarViajes();
                            ActualizarDataGridView();
                            btnLugarGuardar.Enabled = false;
                        }
                        else MessageBox.Show("No se puede usar un nombre ya existente.", "Error de sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Error inesperado.", "Error fatal. (Error-NRE)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RecargarHorarios()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                try
                {
                    Viaje viaje = GetDBViaje(db, cbHorTrayecto.SelectedItem?.ToString());
                    if (viaje != null)
                    {
                        cbHorHorarios.Items.Clear();
                        dgvHorHorarios.Rows.Clear();
                        foreach (Horario h in viaje.Horarios)
                        {
                            if (h.Hora != string.Empty)
                            {
                                cbHorHorarios.Items.Add(h.Hora);
                                cbHorHorarios.SelectedIndex = 0;
                                string dias = "";
                                for (int i = 0; i < 7; i++)
                                {
                                    if (h.Frecuencia.Cells[i].Value == 1) dias += GetDayStringFromIndex(i) + " - ";
                                }

                                dgvHorHorarios.Rows.Add(h.Hora + " hs.", h.Distribucion.Nota, dias);
                            }
                        }
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }/*
        private RadioButton BuscarBoton(Destino destino)
        {
            foreach (Control c in pnlMapa.Controls)
            {
                if (c is RadioButton)
                {
                    if ((c as RadioButton).Tag != null)
                    {
                        if ((c as RadioButton).Tag.ToString() == destino.Id.ToString())
                        {
                            return (RadioButton)c;
                        }
                    }
                }
            }
            return null;
        }
        */
        private Destino BuscarDestino(RadioButton button)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var destinos = db.Destinos.ToList();

                foreach (Destino destino in destinos)
                {
                    if (button.Tag.ToString() == destino.Id.ToString())
                    {
                        return destino;
                    }
                }
                return null;
            }

        }


        private void EnableRadioButtons()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var viajes = db.Viajes.ToList();
                Viajes_LoadReferences(ref viajes, db);


                if (viajes.Count > 0)
                {
                    rbViajeCrear.Enabled = true;
                    rbViajeModificar.Enabled = true;
                    rbViajeEliminar.Enabled = true;
                }
                else
                {
                    rbViajeCrear.Enabled = true;
                    rbViajeEliminar.Enabled = false;
                    rbViajeModificar.Enabled = false;
                    rbViajeCrear.Checked = true;
                }
            }
        }
        private bool IsValidFileName(string file_name)
        {
            char[] carateres_invalidos = Path.GetInvalidFileNameChars();
            foreach (char c in carateres_invalidos)
            {
                if (file_name.Contains(c)) return false;
            }
            return true;
        }

        public static void Viajes_LoadReferences(ref List<Viaje> viajes, EntityDataModel db)
        {
            foreach (Viaje viaje in viajes)
            {
                Viaje_LoadReferences(viaje, db);
            }
        }

        public static void Viaje_LoadReferences(Viaje viaje, EntityDataModel db)
        {
            if (viaje != null)
            {
                string[] ref_viaje = { "Horarios", "Arcos" };
                foreach (string referencia in ref_viaje) if (!db.Entry(viaje).Collection(referencia).IsLoaded) db.Entry(viaje).Collection(referencia).Load();

                foreach (Arco a in viaje.Arcos)
                {
                    string[] ref_arco = { "Origen", "Destino" };
                    foreach (string referencia in ref_arco) if (!db.Entry(a).Reference(referencia).IsLoaded) db.Entry(a).Reference(referencia).Load();
                }

                foreach (Horario h in viaje.Horarios)
                {
                    string[] ref_horario = { "Distribucion", "Frecuencia" };
                    foreach (string referencia in ref_horario) if (!db.Entry(h).Reference(referencia).IsLoaded) db.Entry(h).Reference(referencia).Load();

                    Distribucion_LoadReferences(h.Distribucion, db);
                    if (!db.Entry(h.Frecuencia).Collection("Cells").IsLoaded) db.Entry(h.Frecuencia).Collection("Cells").Load();
                }
            }
        }

        public static void Boletos_LoadReferences(ref List<Boleto> boletos, EntityDataModel db)
        {
            foreach (Boleto boleto_temp in boletos)
            {
                Boleto_LoadReferences(boleto_temp, db);
            }
        }

        public static void Boleto_LoadReferences(Boleto boleto, EntityDataModel db)
        {
            string[] referencias = { "Destino", "Origen", "Recorrido", "Pago", "Pasajero", "Vendedor" };
            foreach (string referencia in referencias) if (!db.Entry(boleto).Reference(referencia).IsLoaded) db.Entry(boleto).Reference(referencia).Load();
        }


        public static void Distribucion_LoadReferences(Distribucion distribucion, EntityDataModel db)
        {
            if (distribucion != null)
            {
                string[] ref_distribucion = { "Matriz_PB", "Matriz_PA" };
                foreach (string referencia in ref_distribucion) if (!db.Entry(distribucion).Collection(referencia).IsLoaded) db.Entry(distribucion).Collection(referencia).Load();

                foreach (Fila row in distribucion.Matriz_PA) db.Entry(row).Collection("Cells").Load();
                foreach (Fila row in distribucion.Matriz_PB) db.Entry(row).Collection("Cells").Load();
            }
        }


        public static Viaje GetDBViaje(EntityDataModel db, string nombre_viaje)
        {
            IQueryable<Viaje> viaje = (from v in db.Viajes where v.Nombre == nombre_viaje select v);
            if (viaje.Any())
            {
                Viaje_LoadReferences(viaje.First(), db);
                return viaje.First();
            }
            else return null;
        }

        public static Distribucion GetDBDistribucion(EntityDataModel db, string nota)
        {
            IQueryable<Distribucion> distribucion = (from d in db.Distribuciones where d.Nota == nota select d);
            if (distribucion.Any())
            {
                Distribucion_LoadReferences(distribucion.First(), db);
                return distribucion.First();
            }
            else return null;
        }

        public static Boleto GetDBBoleto(EntityDataModel db, int id)
        {
            IQueryable<Boleto> boleto = (from b in db.Boletos where b.ID == id select b);
            if (boleto.Any())
            {
                Boleto_LoadReferences(boleto.First(), db);
                return boleto.First();
            }
            else return null;
        }

        public static Destino GetDBDestino(EntityDataModel db, string nombre_destino)
        {
            IQueryable<Destino> destino = (from d in db.Destinos where d.Nombre == nombre_destino select d);
            if(destino.Any())
            {
                return destino.First();
            }
            else return null;
        }

        public static Cliente GetDBCliente(EntityDataModel db, string nombre_cliente)
        {
            IQueryable<Cliente> cliente = (from c in db.Clientes where c.Nombre == nombre_cliente select c);
            if(cliente.Any())
            {
                return cliente.First();
            }
            else return null;
        }

        public static Cliente GetDBCliente(EntityDataModel db, long dni_cliente)
        {
            IQueryable<Cliente> cliente = (from c in db.Clientes where c.DNI == dni_cliente select c);
            if(cliente.Any())
            {
                return cliente.First();
            }
            else return null;
        }

        public static Cuenta GetDBCuenta(EntityDataModel db, string usuario)
        {
            IQueryable<Cuenta> cuenta = (from c in db.Cuentas where c.Usuario == usuario select c);
            if (cuenta.Any())
            {
                return cuenta.First();
            }
            else return null;
        }

        public static Cuenta GetDBCuenta(EntityDataModel db, int cuenta_id)
        {
            IQueryable<Cuenta> cuenta = (from c in db.Cuentas where c.Id == cuenta_id select c);
            if (cuenta.Count() != 0)
            {
                return cuenta.First();
            }
            else return null;
        }

        public static DateTime GetDBDateNow(EntityDataModel db)
        {
            if (db != null)
                return DateTime.Now;
                //return db.Database.SqlQuery<DateTime>("SELECT GetDate()").First();
            else return new DateTime();
        }





        private void tbViajeNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbViajeDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbPBModEAsiento_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblConexTrayecto_Click(object sender, EventArgs e)
        {

        }

        private void lblConexConexion_Click(object sender, EventArgs e)
        {

        }

        private void lblConexHrs_Click(object sender, EventArgs e)
        {

        }

        private void cbConexDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblConexDestino_Click(object sender, EventArgs e)
        {

        }

        private void lblConexOrigen_Click(object sender, EventArgs e)
        {

        }

        private void lblConexDemora_Click(object sender, EventArgs e)
        {

        }

        private void cbConexOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpConexDemora_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblConexPrecio_Click(object sender, EventArgs e)
        {

        }

        private void nudConexPrecio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmsOpciones_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    RadioButton button = (RadioButton)((ContextMenuStrip)(sender as ToolStripMenuItem).Owner).SourceControl;

                    Destino origen = GetDBDestino(db, cbLugar.SelectedItem?.ToString());
                    Destino destino = (from d in db.Destinos where d.Id.ToString() == button.Tag.ToString() select d).FirstOrDefault();

                    cbConexOrigen.SelectedItem = origen.Nombre;
                    cbConexDestino.SelectedItem = destino.Nombre;

                    CrearConexion();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Se produjo un error al intentar buscar los destinos para conectar.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    RadioButton button = (RadioButton)((ContextMenuStrip)(sender as ToolStripMenuItem).Owner).SourceControl;

                    Destino origen = GetDBDestino(db, cbLugar.SelectedItem?.ToString());
                    Destino destino = (from d in db.Destinos where d.Id.ToString() == button.Tag.ToString() select d).FirstOrDefault();

                    cbConexOrigen.SelectedItem = origen.Nombre;
                    cbConexDestino.SelectedItem = destino.Nombre;

                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Se produjo un error al intentar buscar los destinos para conectar.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsRadioConnect_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                RadioButton button = (RadioButton)(sender as ContextMenuStrip).SourceControl;

                Destino origen = GetDBDestino(db, cbLugar.SelectedItem?.ToString());
                Destino destino = (from d in db.Destinos where d.Id.ToString() == button.Tag.ToString() select d).FirstOrDefault();

                if (destino != null)
                {
                    cmsRadioConnect.Items["seleccionarToolStripMenuItem"].Text = "Seleccionar '" + destino.Nombre + "'";
                    cmsRadioConnect.Items["conectarToolStripMenuItem"].Text = "Conectar con '" +  origen.Nombre + "'";
                }
            }
        }

        private void gMPMapa_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void gMPMapa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double lat = gMPMapa.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMPMapa.FromLocalToLatLng(e.X, e.Y).Lng;
                punto_temp.Lat = lat;
                punto_temp.Lng = lng;

                marker.Position = punto_temp;
                lblUbicacion.Text = "Ubicación: " + Math.Round(lat, 4) + "; " + Math.Round(lng, 4) + ";";
                btnDestinoEliminar.Visible = true;
                
            }
            if(!markerOverlay.Markers.Contains(marker))
            {
                markerOverlay.Markers.Add(marker);
                
            }
        }

        private void btnGeoPlace_ClickAsync(object sender, EventArgs e)
        {



            
            //Console.WriteLine("Formatted: " + addresses.First().FormattedAddress); //Formatted: 1600 Pennsylvania Ave SE, Washington, DC 20003, USA
            //Console.WriteLine(); //Coordinates: 38.8791981, -76.9818437
        }


        private void tDelayQuery_Tick(object sender, EventArgs e)
        {
            if(time_wait)
            {
                try
                {
                    IGeocoder geocoder = new GoogleGeocoder() { ApiKey = Program.Configuration["Google-Api-Key"] };
                    addresses = geocoder.Geocode(tbNombre.Text);
                    if (addresses != null)
                    {
                        if (addresses.ToList().Count > 0)
                        {
                            tbNombre.AutoCompleteCustomSource.Clear();
                            foreach (var adress in addresses)
                            {
                                tbNombre.AutoCompleteCustomSource.Add(adress.FormattedAddress);
                            }
                        }
                    }


                    //MessageBox.Show("Formatted: " + addresses.First().FormattedAddress + Environment.NewLine + "Coordinates: " + addresses.First().Coordinates.Latitude + ", " + addresses.First().Coordinates.Longitude, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception)
                {
                    lblTestMouse.Text = "Ocurrió una excepción.";
                }

                lblTestMouse.Text = "Tick ejecutado. " + count_tick++;
                tDelayQuery.Enabled = false;
                time_wait = false;
            }
        }

        private void tbAutDestNombre_TextChanged(object sender, EventArgs e)
        {
            if (!time_wait)
            {
                tDelayQuery.Enabled = true;
                time_wait = true;
            }
        }
    }
}
