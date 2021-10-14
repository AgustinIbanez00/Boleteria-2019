using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_final.Models;

namespace Sistema_final
{
    public partial class frmLogin : Form
    {    
        public frmLogin()
        {
            InitializeComponent();
            ttMensajes.UseAnimation = true;
            using (EntityDataModel db = new EntityDataModel())
            {
                lblCuentas.Text = "Cuentas: " + db.Cuentas.Count();
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        { 
            if(btnRegistrarse.Text == "Crear cuenta")
            {
                lblRContraseña.Visible = true;
                tbRContraseña.Visible = true;
                lblCorreo.Visible = true;
                tbCorreo.Visible = true;
                tbRContraseña.Visible = true;
                lblFechaNac.Visible = true;
                dtpFechaNac.Visible = true;
                lblSexo.Visible = true;
                cbSexo.Visible = true;
                cbSexo.TabIndex = 1;
                lblFechaRegistro.Visible = true;
                lblFechaRegistro.Text = "Fecha de registro: " + DateTime.Now.ToString();
                btnIngresar.Text = "Registrarse";
                btnRegistrarse.Text = "Volver";
                tbUsuario.Text = string.Empty;
                tbContraseña.Text = string.Empty;
                tbUsuario.Focus();
            }
            else
            {
                lblRContraseña.Visible = false;
                tbRContraseña.Visible = false;
                lblCorreo.Visible = false;
                tbCorreo.Visible = false;
                tbRContraseña.Visible = false;
                lblFechaNac.Visible = false;
                dtpFechaNac.Visible = false;
                lblSexo.Visible = false;
                cbSexo.Visible = false;
                cbSexo.TabIndex = 1;
                lblFechaRegistro.Visible = false;
                lblFechaRegistro.Text = "Fecha de registro: " + DateTime.Now.ToString();
                btnIngresar.Text = "Iniciar sesión";
                btnRegistrarse.Text = "Crear cuenta";
                tbUsuario.Text = string.Empty;
                tbContraseña.Text = string.Empty;
                tbUsuario.Focus();
            }

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool log = false;
            if (btnIngresar.Text == "Iniciar sesión")
            {
                IniciarSesion(log);
            }
            else
            {
                using (EntityDataModel db = new EntityDataModel())
                {
                    if (tbUsuario.Text != string.Empty)
                    {
                        if (db.Cuentas.Where(c => c.Usuario == tbUsuario.Text).Count() == 0)
                        {
                            if (tbContraseña.Text != string.Empty)
                            {
                                if (tbRContraseña.Text != string.Empty)
                                {
                                    if (tbContraseña.Text == tbRContraseña.Text)
                                    {
                                        if (tbCorreo.Text != string.Empty)
                                        {
                                            if (tbCorreo.Text.Contains("@"))
                                            {
                                                if (cbSexo.SelectedItem != null)
                                                {
                                                    string hashPassword = SecurePasswordHasher.Hash(tbContraseña.Text);

                                                    Cuenta c = new Cuenta(tbUsuario.Text, hashPassword, tbCorreo.Text, dtpFechaNac.Value.Date, frmDestinos.GetDBDateNow(db), cbSexo.Items[cbSexo.SelectedIndex].ToString(), "boleteria");
                                                    db.Cuentas.Add(c);
                                                    db.SaveChanges();
                                                   
                                                    MessageBox.Show("Cuenta creada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    lblRContraseña.Visible = false;
                                                    tbRContraseña.Visible = false;
                                                    lblCorreo.Visible = false;
                                                    tbCorreo.Visible = false;
                                                    tbRContraseña.Visible = false;
                                                    lblFechaNac.Visible = false;
                                                    dtpFechaNac.Visible = false;
                                                    lblSexo.Visible = false;
                                                    cbSexo.Visible = false;
                                                    cbSexo.TabIndex = 1;
                                                    lblFechaRegistro.Visible = false;
                                                    lblFechaRegistro.Text = "Fecha de registro: " + DateTime.Now.ToString();
                                                    btnIngresar.Text = "Iniciar sesión";
                                                    btnRegistrarse.Text = "Crear cuenta";
                                                    tbUsuario.Text = string.Empty;
                                                    tbContraseña.Text = string.Empty;
                                                    tbUsuario.Focus();

                                                }
                                                else MessageBox.Show("Faltó seleccionar el sexo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else MessageBox.Show("Debe ingresar un correo válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else MessageBox.Show("Debe ingresar un correo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else MessageBox.Show("Las contraseñas no coinciden.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else MessageBox.Show("Faltó confirmar la contraseña.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else MessageBox.Show("Falta ingresar una contraseña", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Ese nombre de usuario ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Debe ingresar un nombre de usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tbContraseña_TextChanged(object sender, EventArgs e)
        {
            if (tbContraseña.Text != string.Empty)
            {
                if (btnRegistrarse.Visible == false)
                {
                    if (tbContraseña.Text.Length >= 8)
                    {
                        pbVerErrorContraseña.Visible = false;
                        pbVerContraseña.Visible = true;
                    }
                    else
                    {
                        pbVerErrorContraseña.Visible = true;
                        pbVerContraseña.Visible = false;
                    }
                }
                btnMostrarC.Visible = true;
            }
            else btnMostrarC.Visible = false;
        }

        private void btnMostrarC_MouseHover(object sender, EventArgs e)
        {
            tbContraseña.UseSystemPasswordChar = false;
            tbRContraseña.UseSystemPasswordChar = false;
      
        }

        private void btnMostrarC_MouseLeave(object sender, EventArgs e)
        {
            tbContraseña.UseSystemPasswordChar = true;
            tbRContraseña.UseSystemPasswordChar = true;
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            if (tbUsuario.Text != string.Empty)
            {
                if (btnRegistrarse.Visible == false)
                {
                    pbVerErrorUsuario.Visible = true;
                    using (EntityDataModel db = new EntityDataModel())
                    {
                        var cuenta = db.Cuentas.Where(c => c.Usuario == tbUsuario.Text).First();
                        if (cuenta != null)
                        {
                            pbVerErrorUsuario.Visible = true;
                            pbVerUsuario.Visible = false;
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                pbVerErrorUsuario.Visible = false;
                pbVerUsuario.Visible = false;
            }
        }
        private void pbVerErrorContraseña_Click(object sender, EventArgs e) { }

        private void pnlCuentas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void pbVerErrorUsuario_Click(object sender, EventArgs e)
        {
            pbVerContraseña.Load();
        }

        private void tbContraseña_Enter(object sender, EventArgs e)
        {
        }


        private void IniciarSesion(bool log)
        {
            if (tbUsuario.Text != string.Empty)
            {
                if (tbContraseña.Text != string.Empty)
                {
                    using (EntityDataModel db = new EntityDataModel())
                    {
                        if (db.Cuentas.Count(cuenta => cuenta.Usuario == tbUsuario.Text) == 1)
                        {
                            Cuenta cuentaUso = db.Cuentas.Where(cuenta => cuenta.Usuario == tbUsuario.Text).First();
                            if (cuentaUso != null)
                            {
                                if (SecurePasswordHasher.Verify(tbContraseña.Text, cuentaUso.Contraseña))
                                {
                                    frmPrincipal form = new frmPrincipal(cuentaUso.Id);
                                    this.Hide();
                                    form.ShowDialog();
                                    this.Close();
                                    /*
                                    form.ShowDialog();
                                    */
                                }
                                else
                                {
                                    MessageBox.Show("Contraseña incorrecta.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No existen usuarios registrados con ese nombre.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbContraseña.Text = string.Empty;
                        }
                    }
                }
                else MessageBox.Show("Ingrese una contraseña.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Ingrese un nombre de usuario.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tbContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void tbContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (btnIngresar.Text == "Iniciar sesión" && tbContraseña.Text != string.Empty)
                {
                    IniciarSesion(false);
                }
            }

        }

        private void lblCuentas_MouseEnter(object sender, EventArgs e)
        {
            if (!lblCuentas.Visible)
            {
                lblCuentas.Visible = true;

                using (EntityDataModel db = new EntityDataModel())
                {
                    lblCuentas.Text = "Cuentas: " + db.Cuentas.Count();
                }
            }
        }

        private void lblCuentas_MouseLeave(object sender, EventArgs e)
        {
            lblCuentas.Visible = false;
        }
    }
}
