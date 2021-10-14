namespace Sistema_final
{
    partial class frmReporteBoletos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteBoletos));
            this.crReporteBoletos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReporteBoleto2 = new Sistema_final.ReporteBoleto();
            this.ReporteBoleto1 = new Sistema_final.ReporteBoleto();
            this.SuspendLayout();
            // 
            // crReporteBoletos
            // 
            this.crReporteBoletos.ActiveViewIndex = 0;
            this.crReporteBoletos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crReporteBoletos.Cursor = System.Windows.Forms.Cursors.Default;
            this.crReporteBoletos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crReporteBoletos.Location = new System.Drawing.Point(0, 0);
            this.crReporteBoletos.Name = "crReporteBoletos";
            this.crReporteBoletos.ReportSource = this.ReporteBoleto2;
            this.crReporteBoletos.Size = new System.Drawing.Size(1085, 500);
            this.crReporteBoletos.TabIndex = 0;
            this.crReporteBoletos.Load += new System.EventHandler(this.crReporteBoletos_Load);
            // 
            // ReporteBoleto2
            // 
            this.ReporteBoleto2.InitReport += new System.EventHandler(this.ReporteBoleto2_InitReport);
            // 
            // ReporteBoleto1
            // 
            this.ReporteBoleto1.InitReport += new System.EventHandler(this.ReporteBoleto1_InitReport);
            // 
            // frmReporteBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 500);
            this.Controls.Add(this.crReporteBoletos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteBoletos";
            this.Text = "Boletería - Reporte de boletos";
            this.Load += new System.EventHandler(this.frmReporteBoletos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crReporteBoletos;
        private ReporteBoleto ReporteBoleto1;
        private ReporteBoleto ReporteBoleto2;
    }
}