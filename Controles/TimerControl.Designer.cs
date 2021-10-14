namespace Controles
{
    partial class TimerControl
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHoraServer = new System.Windows.Forms.Label();
            this.TimerHora = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblHoraServer
            // 
            this.lblHoraServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoraServer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraServer.Location = new System.Drawing.Point(0, 0);
            this.lblHoraServer.Name = "lblHoraServer";
            this.lblHoraServer.Size = new System.Drawing.Size(330, 51);
            this.lblHoraServer.TabIndex = 0;
            this.lblHoraServer.Text = "Hora del servidor: ";
            this.lblHoraServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHoraServer.Click += new System.EventHandler(this.lblHoraServer_Click);
            // 
            // TimerHora
            // 
            this.TimerHora.Tick += new System.EventHandler(this.TimerHora_Tick);
            // 
            // TimerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblHoraServer);
            this.Name = "TimerControl";
            this.Size = new System.Drawing.Size(330, 51);
            this.Load += new System.EventHandler(this.TimerControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHoraServer;
        private System.Windows.Forms.Timer TimerHora;
    }
}
