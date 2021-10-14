using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_final
{
    public partial class frmReportePasajero : Form
    {
        string nombre;

        public frmReportePasajero(string nombre)
        {
            this.nombre = nombre;
            InitializeComponent();
        }

        private void frmReportePasajero_Load(object sender, EventArgs e)
        {
            ReporteBoletoPasajero reporteBoleto = new ReporteBoletoPasajero();
            reporteBoleto.SetParameterValue("@nombre", nombre);
            crvReportePasajeros.ReportSource = reporteBoleto;
        }
    }
}
