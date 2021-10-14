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
    public partial class frmReporteBoletos : Form
    {
        string viaje = "";

        public frmReporteBoletos(string viaje)
        {
            this.viaje = viaje;
            InitializeComponent();
        }

        private void ReporteBoleto1_InitReport(object sender, EventArgs e)
        {

        }

        private void frmReporteBoletos_Load(object sender, EventArgs e)
        {
            ReporteBoleto reporteBoleto = new ReporteBoleto();
            reporteBoleto.SetParameterValue("@viaje", viaje);
            crReporteBoletos.ReportSource = reporteBoleto;

        }

        private void ReporteBoleto2_InitReport(object sender, EventArgs e)
        {

        }

        private void crReporteBoletos_Load(object sender, EventArgs e)
        {

        }
    }
}
