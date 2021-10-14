namespace Sistema_final
{
    partial class frmReportePasajero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportePasajero));
            this.crvReportePasajeros = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReporteBoletoPasajero1 = new Sistema_final.ReporteBoletoPasajero();
            this.SuspendLayout();
            // 
            // crvReportePasajeros
            // 
            this.crvReportePasajeros.ActiveViewIndex = 0;
            this.crvReportePasajeros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReportePasajeros.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReportePasajeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReportePasajeros.Location = new System.Drawing.Point(0, 0);
            this.crvReportePasajeros.Name = "crvReportePasajeros";
            this.crvReportePasajeros.ReportSource = this.ReporteBoletoPasajero1;
            this.crvReportePasajeros.Size = new System.Drawing.Size(800, 450);
            this.crvReportePasajeros.TabIndex = 0;
            // 
            // frmReportePasajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvReportePasajeros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportePasajero";
            this.Text = "Boleteria - Reporte de boletos";
            this.Load += new System.EventHandler(this.frmReportePasajero_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportePasajeros;
        private ReporteBoletoPasajero ReporteBoletoPasajero1;
    }
}