using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles
{
    public partial class TimerControl: UserControl
    {
        DateTime date = new DateTime();

        public TimerControl()
        {
            InitializeComponent();
        }

        public TimerControl(DateTime date)
        {
            InitializeComponent();
            this.date = date;
        }

        public DateTime Date { get => date; set => date = value; }

        private void lblHoraServer_Click(object sender, EventArgs e)
        {

        }

        private void TimerControl_Load(object sender, EventArgs e)
        {
            TimerHora.Enabled = true;
            TimerHora.Interval = 1000;
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            date = date.AddSeconds(1);
            lblHoraServer.Text = "Hora del servidor: " + date.ToLongTimeString();
        }
    }
}
