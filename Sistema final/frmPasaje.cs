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
    public partial class frmPasaje : Form
    {
        public frmPasaje()
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
        public static Cliente GetDBCliente(EntityDataModel db, int dni_cliente) { return FrmDestinos.GetDBCliente(db, dni_cliente); }
        public static DateTime GetDBDateNow(EntityDataModel db) { return FrmDestinos.GetDBDateNow(db); }

        #endregion

    
        private void frmPasajeros_Load(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var clientes = db.Clientes.ToList();

                if (clientes.Count > 0)
                {   
                    cbNombre.AutoCompleteCustomSource.Clear();
                    cbDNI.AutoCompleteCustomSource.Clear();
                    foreach (Cliente c in clientes)
                    {
                        cbNombre.AutoCompleteCustomSource.Add(c.Nombre);
                        cbDNI.AutoCompleteCustomSource.Add(c.DNI.ToString());
                    }
                    ActualizarFiltros();
                }
                DateTime fecha_servidor = GetDBDateNow(db);
                cbGenero.SelectedIndex = 0;

                dtpFechaNac.MinDate = fecha_servidor.Subtract(new TimeSpan(100 * 365, 0, 0, 0, 0));
                dtpFechaNac.MaxDate = fecha_servidor.Subtract(new TimeSpan(5*365, 0, 0, 0, 0));
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                DateTime fecha_servidor = GetDBDateNow(db);

                if (rbRegistrar.Checked)
                {
                    if (cbNombre.Text != string.Empty)
                    {
                        if (cbDNI.Text != string.Empty)
                        {
                            if (dtpFechaNac.Value != dtpFechaNac.MinDate)
                            {
                                if (cbNacionalidad.Text != string.Empty)
                                {
                                    if (cbGenero.SelectedItem != null)
                                    {
                                        if (cbGenero.SelectedIndex >= 0)
                                        {
                                            if (!db.Clientes.Any(cf => cf.DNI.ToString() == cbDNI.Text))
                                            {
                                                Cliente c = new Cliente(cbNombre.Text, Convert.ToInt32(cbDNI.Text), cbNacionalidad.Text, cbGenero.Text, dtpFechaNac.Value.Date, GetDBDateNow(db));
                                                db.Clientes.Add(c);
                                                db.SaveChanges();
                                                cbNombre.Text = string.Empty;
                                                cbDNI.Text = string.Empty;
                                                cbNacionalidad.Text = string.Empty;
                                                cbGenero.SelectedIndex = 0;
                                                cbNombre.Focus();
                                                MessageBox.Show("Pasajero registrado correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else MessageBox.Show("El documento de identidad debe ser único.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else MessageBox.Show("Es obligatorio registrar el género del pasajero.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else MessageBox.Show("Ingrese la nacionalidad del pasajero.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else MessageBox.Show("Ingrese una fecha de nacimiento válida.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Para registrar un cliente se necesita un DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Para registrar un cliente se necesita un nombre.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbEditar.Checked)
                {
                    if (cbNombre.Text != string.Empty)
                    {
                        if (cbDNI.Text != string.Empty)
                        {
                            if (cbNacionalidad.Text != string.Empty)
                            {
                                if (cbGenero.SelectedItem != null)
                                {
                                    if (cbGenero.SelectedIndex >= 0)
                                    {
                                        string dni = dgvPasajeros.CurrentRow.Cells["DNI"].Value.ToString();
                                        if (!db.Clientes.Any(c => c.DNI.ToString() == cbDNI.Text && c.DNI.ToString() != dni))
                                        {
                                            Cliente cliente = GetDBCliente(db, Convert.ToInt32(dgvPasajeros.CurrentRow.Cells["DNI"].Value));
                                            if (cliente != null)
                                            {
                                                cliente.DNI = Convert.ToInt32(cbDNI.Text);
                                                cliente.Nombre = cbNombre.Text;
                                                cliente.FechaNac = dtpFechaNac.Value;
                                                cliente.Nacionalidad = cbNacionalidad.Text;
                                                cliente.Genero = cbGenero.SelectedItem?.ToString();

                                                db.SaveChanges();
                                                cbNombre.Text = string.Empty;
                                                cbDNI.Text = string.Empty;
                                                cbNacionalidad.Text = string.Empty;
                                                cbGenero.SelectedIndex = 0;
                                                cbNombre.Focus();
                                                MessageBox.Show("Los cambios se guardaron correctamente.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else MessageBox.Show("Error inválido: El pasajero no se encuentra registrado en la lista.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else MessageBox.Show("El documento de identidad debe ser único.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else MessageBox.Show("Es obligatorio registrar el género del pasajero.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else MessageBox.Show("Es obligatorio que el pasajero tenga una nacionalidad.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Para registrar un cliente se necesita un DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Para registrar un cliente se necesita un nombre.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbEliminar.Checked)
                {
                    Cliente cliente = GetDBCliente(db, dgvPasajeros.CurrentRow.Cells["DNI"].Value.ToString());
                    if (cliente != null)
                    {
                        int count = db.Boletos.Count(bol => bol.Pasajero.DNI == cliente.DNI);
                        if (count == 0)
                        {
                            db.Clientes.Remove(cliente);
                            db.SaveChanges();
                            MessageBox.Show("El cliente se eliminó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualizarInformacion((Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())) - Convert.ToInt32(cbFilas.SelectedItem?.ToString()), (Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())));
                        }
                        else
                        {
                            if (MessageBox.Show("Hay " + count + " boletos a nombre de este pasajero, al eliminarlo se eliminarán los boletos a su nombre." + Environment.NewLine + "¿Está seguro que desea eliminar este pasajero?", "Advertencia.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                db.Boletos.RemoveRange(db.Boletos.Where(b => b.Pasajero.DNI == cliente.DNI));
                                db.Clientes.Remove(cliente);
                                db.SaveChanges();
                                ActualizarInformacion((Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())) - Convert.ToInt32(cbFilas.SelectedItem?.ToString()), (Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())));
                                MessageBox.Show("Se eliminaron " + count + " boletos correctamente.", "Acción realizada correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else MessageBox.Show("Error inesperado: No se pudo encontrar el pasajero en la lista.", "Error fatal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    ActualizarInformacion((Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())) - Convert.ToInt32(cbFilas.SelectedItem?.ToString()), (Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())));
                }
                catch(ArgumentException)
                {

                }
                catch(NullReferenceException)
                {

                }
            }
        }   
        private void cbDNI_KeyPress(object sender, KeyPressEventArgs e)
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
        private void rbRegistrar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbRegistrar.Checked)
                {
                    cbNombre.Enabled = true;
                    cbDNI.Enabled = true;
                    dtpFechaNac.Enabled = true;
                    cbNacionalidad.Enabled = true;
                    cbGenero.Enabled = true;

                    //chbNombre.CheckState = CheckState.Indeterminate;
                    btnOperar.Enabled = true;
                    btnOperar.Text = "Registrar";
                    cbNombre.Text = string.Empty;
                    cbDNI.Text = string.Empty;
                    dtpFechaNac.Value = dtpFechaNac.MinDate;
                    cbNacionalidad.Text = string.Empty;
                    cbNombre.AutoCompleteMode = AutoCompleteMode.None;
                    cbDNI.AutoCompleteMode = AutoCompleteMode.None;
                }
            }     
            catch(NullReferenceException)
            {
            }
        }
        private void rbEditar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbEditar.Checked)
                {
                    cbNombre.Enabled = true;
                    cbDNI.Enabled = true;
                    dtpFechaNac.Enabled = true;
                    cbNacionalidad.Enabled = true;
                    cbGenero.Enabled = true;

                    btnOperar.Enabled = false;
                    btnOperar.Text = "Guardar";
                    cbNombre.Text = dgvPasajeros.CurrentRow.Cells["Nombre"].Value.ToString();
                    cbDNI.Text = dgvPasajeros.CurrentRow.Cells["DNI"].Value.ToString();
                    dtpFechaNac.Value = Convert.ToDateTime(dgvPasajeros.CurrentRow.Cells["FechaNac"].Value.ToString());
                    cbNacionalidad.Text = dgvPasajeros.CurrentRow.Cells["Nacionalidad"].Value.ToString();
                    cbGenero.SelectedItem = dgvPasajeros.CurrentRow.Cells["Genero"].Value.ToString();
                    cbNombre.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cbDNI.AutoCompleteMode = AutoCompleteMode.Suggest;
                }
            }
            catch (NullReferenceException)
            {
            }
        }    
        private void RbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbEliminar.Checked)
                {
                    cbNombre.Enabled = false;
                    cbDNI.Enabled = false;
                    dtpFechaNac.Enabled = false;
                    cbNacionalidad.Enabled = false;
                    cbGenero.Enabled = false;

                    btnOperar.Enabled = true;
                    btnOperar.Text = "Eliminar";
                    cbNombre.Text = dgvPasajeros.CurrentRow.Cells["Nombre"].Value.ToString();
                    cbDNI.Text = dgvPasajeros.CurrentRow.Cells["DNI"].Value.ToString();
                    dtpFechaNac.Value = Convert.ToDateTime(dgvPasajeros.CurrentRow.Cells["FechaNac"].Value.ToString());
                    cbNacionalidad.Text = dgvPasajeros.CurrentRow.Cells["Nacionalidad"].Value.ToString();
                    cbGenero.SelectedItem = dgvPasajeros.CurrentRow.Cells["Genero"].Value.ToString();
                    cbNombre.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cbDNI.AutoCompleteMode = AutoCompleteMode.Suggest;
                }
            }
            catch (NullReferenceException)
            {
            }
        }
        private void CbMostrarTodo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarInformacion((Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())) - Convert.ToInt32(cbFilas.SelectedItem?.ToString()), (Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())));
            if(cbMostrarTodo.Checked)
            {
                cbFilas.Enabled = false;
                lblNumeroFilas.Enabled = false;
            }
            else
            {
                cbFilas.Enabled = true;
                lblNumeroFilas.Enabled = true;
            }
        }
        private void CbNombre_TextChanged(object sender, EventArgs e)
        {
            if(rbEditar.Checked)
            {
                EnableSaveButton();
            }
            cbNombre.Text = cbNombre.Text.ToUpper();
        }
        private void CbDNI_TextChanged(object sender, EventArgs e)
        {
            if (rbEditar.Checked)
            {
                EnableSaveButton();
            }
            /*
            Char[] texto = cbDNI.Text.ToCharArray();
            List<char> no_numbers = new List<char>();
            foreach (Char letter in texto)
            {
                if (!Char.IsNumber(letter))
                {
                    no_numbers.Add(letter);
                }
            }
            if (no_numbers.Count > 0)
            {
                var text = cbDNI.Text.ToList();
                for (int i = 0; i < (no_numbers.Count - 1); i++)
                {

                    text.Remove(no_numbers[i]);
                }

                cbDNI.Text = text.ToString();
            }
    */        

        }
        private void DtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            if (rbEditar.Checked)
            {
                EnableSaveButton();
            }
            lblEdad.Text = "Edad: " + CalculateAge(dtpFechaNac.Value.Date).ToString();
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age--;

            return age;
        }

        private void dgvPasajeros_SelectionChanged(object sender, EventArgs e)
        {
            if (rbEditar.Checked || rbEliminar.Checked)
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    var clientes = db.Clientes.ToList();

                    Cliente c = clientes.Find(cliente => cliente.DNI.ToString() == dgvPasajeros.CurrentRow.Cells["DNI"].Value.ToString());
                    if (c != null)
                    {
                        cbNombre.Text = c.Nombre;
                        cbDNI.Text = c.DNI.ToString();
                        dtpFechaNac.Value = Convert.ToDateTime(c.FechaNac);
                        cbNacionalidad.Text = c.Nacionalidad;
                        cbGenero.SelectedItem = c.Genero;
                    }
                    else MessageBox.Show("Error inesperado: Ese pasajero ya no se encuentra en la lista.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cbDNI_KeyPress_1(object sender, KeyPressEventArgs e)
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
        private void dgvPasajeros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void cbFilas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarFiltros();

            }
            catch (NullReferenceException)
            {

            }

        }    
        private void cbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarInformacion((Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())) - Convert.ToInt32(cbFilas.SelectedItem?.ToString()), (Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())));

            }
            catch (NullReferenceException)
            {

            }
        }

        private void ActualizarInformacion(int start, int end)
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var clientes = db.Clientes.ToList();

                int index = 1;
                if (cbMostrarTodo.Checked)
                {
                    dgvPasajeros.Rows.Clear();
                    foreach (Cliente c in clientes)
                    {
                        dgvPasajeros.Rows.Add(index, c.Nombre, c.DNI, c.Nacionalidad, c.Genero, c.FechaNac);
                        index++;
                    }
                }
                else
                {
                    dgvPasajeros.Rows.Clear();
                    for (int i = start; i < end; i++)
                    {
                        if (i < clientes.Count)
                        {
                            if (clientes[i] != null)
                            {
                                dgvPasajeros.Rows.Add(index, clientes[i].Nombre, clientes[i].DNI, clientes[i].Nacionalidad, clientes[i].Genero, clientes[i].FechaNac);
                                index++;
                            }
                        }
                    }

                }
            }
        }
        private void EnableSaveButton()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var clientes = db.Clientes.ToList();

                Cliente c = clientes.Find(cliente => cliente.DNI.ToString() == dgvPasajeros.CurrentRow.Cells["DNI"].Value.ToString());
                if (c != null)
                {
                    if (cbNombre.Text != c.Nombre || cbDNI.Text != c.DNI.ToString() || dtpFechaNac.Value != c.FechaNac || cbNacionalidad.Text != c.Nacionalidad)
                    {
                        btnOperar.Enabled = true;
                    }
                    else btnOperar.Enabled = false;
                }
                else MessageBox.Show("Error inesperado: El pasajero ya no se encuentra registrado en la lista.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarFiltros()
        {
            using (EntityDataModel db = new EntityDataModel())
            {
                var clientes = db.Clientes.ToList();

                cbPagina.Items.Clear();
                cbPagina.Items.Add("1");
                if (cbFilas.SelectedItem == null) cbFilas.SelectedIndex = 0;
                if (cbPagina.SelectedItem == null) cbPagina.SelectedItem = "1";
                for (int i = 1; i < clientes.Count / Convert.ToInt32(cbFilas.SelectedItem?.ToString()); i++)
                {
                    cbPagina.Items.Add((i + 1).ToString());
                }
                if (clientes.Count < Convert.ToInt32(cbFilas.Items[0].ToString()))
                {
                    cbMostrarTodo.Visible = true;
                }
                else cbMostrarTodo.Visible = false;
                ActualizarInformacion((Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())) - Convert.ToInt32(cbFilas.SelectedItem?.ToString()), (Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())));
            }
        }

        private void cbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void dgvPasajeros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void chbNombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        public class ReadOnlyCheckBox : CheckBox
        {
            private bool readOnly;

            protected override void OnClick(EventArgs e)
            {
                if (!ReadOnly) base.OnClick(e);
            }

            public bool ReadOnly
            {
                get { return readOnly; }
                set { readOnly = value; }
            }
        }
    }
}
